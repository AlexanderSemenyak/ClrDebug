﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    [Generator]
    public class StructSourceGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
#if DEBUG
            if (!Debugger.IsAttached)
            {
                //Debugger.Launch();
            }
#endif

            var syntaxTrees = GetSyntaxTrees();

            var structs = syntaxTrees.SelectMany(s => s.GetCompilationUnitRoot().DescendantNodes().OfType<StructDeclarationSyntax>()).ToArray();

            var structsToMonitor = new List<string>();

            foreach (var @struct in @structs)
            {
                var analysis = new StructSyntaxInfo(@struct);

                if (analysis.RequiresMarshalling)
                    structsToMonitor.Add(@struct.Identifier.ToString());
            }

            context.RegisterPostInitializationOutput(ctx =>
            {
                foreach (var @struct in structs)
                {
                    var info = new StructSyntaxInfo(@struct);

                    if (info.RequiresMarshalling)
                    {
                        var builder = new StringBuilder();

                        builder.AppendLine("#pragma warning disable CS0649 //Field is never assigned to, and will always have its default value");
                        builder.AppendLine(GenerateCompilationUnit(info).ToFullString());
                        builder.AppendLine("#pragma warning restore CS0649 //Field is never assigned to, and will always have its default value");

                        ctx.AddSource($"{info.Name}.g.cs", builder.ToString());
                    }
                }
            });

            var items = context.SyntaxProvider.CreateSyntaxProvider((syntax, _) => syntax is StructDeclarationSyntax s && structsToMonitor.Contains(s.Identifier.ToString()), (ctx, _) => (StructDeclarationSyntax) ctx.Node).Where(v => v != null);

            context.RegisterSourceOutput(items, (ctx, syntax) =>
            {
                var info = new StructSyntaxInfo(syntax);

                if (info.RequiresMarshalling && !info.HasPartial)
                {
                    var descriptor = new DiagnosticDescriptor(
                        "CLRDEBUG001",
                        "Structs requiring custom marshalling must be partial",
                        "Structs requiring custom marshalling must be partial",
                        "ClrDebug",
                        DiagnosticSeverity.Error,
                        true
                    );
                    var location = syntax.GetLocation();

                    var diagnostic = Diagnostic.Create(
                        descriptor,
                        location
                    );

                    ctx.ReportDiagnostic(diagnostic);
                }
            });
        }

        #region Generation

        private CompilationUnitSyntax GenerateCompilationUnit(StructSyntaxInfo info)
        {
            var marshallerType = GenerateMarshallerType(info);
            var nativeType = GenerateNativeStructType(info);

            var outerType = GenerateOuterStructType(info, marshallerType, nativeType);

            var usings = info.Syntax.SyntaxTree.GetCompilationUnitRoot().Usings.Select(v => v.WithoutTrivia()).ToList();

            if (!usings.Any(u => u.Name.ToString() == "System.Runtime.InteropServices.Marshalling"))
                usings.Add(UsingDirective(IdentifierName("System.Runtime.InteropServices.Marshalling")));

            var ns = info.Syntax.SyntaxTree.GetRoot().DescendantNodes().OfType<NamespaceDeclarationSyntax>().First();

            var syntax = CompilationUnit()
                .WithUsings(List(usings))
                .AddMembers(
                    NamespaceDeclaration(ns.Name).AddMembers(outerType)
                 );

            return syntax.NormalizeWhitespace();
        }

        #region Marshaller

        private ClassDeclarationSyntax GenerateMarshallerType(StructSyntaxInfo info)
        {
            var customMarshallerAttribute = Attribute(
                IdentifierName("CustomMarshaller"),
                AttributeArgumentList().AddArguments(
                    AttributeArgument(TypeOfExpression(IdentifierName(info.Name))),
                    AttributeArgument(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName("MarshalMode"), IdentifierName("Default"))),
                    AttributeArgument(TypeOfExpression(IdentifierName("Marshaller")))
                )
            );

            var marshaller = ClassDeclaration("Marshaller")
                .WithModifiers(TokenList(Token(SyntaxKind.InternalKeyword), Token(SyntaxKind.StaticKeyword)))
                .AddMembers(GenerateConvertToUnmanaged(info), GenerateConvertToManaged(info))
                .AddAttributeLists(AttributeList().AddAttributes(customMarshallerAttribute));

            return marshaller;
        }

        private MethodDeclarationSyntax GenerateConvertToUnmanaged(StructSyntaxInfo info)
        {
            return GenerateMarshallerMethod(
                inputType: info.Name,
                inputName: "managed",
                outputType: info.NativeName,
                outputName: "unmanaged",
                methodName: "ConvertToUnmanaged",
                fields: info.Fields,
                f => f.Marshaller.ToUnmanaged("managed")
            );
        }

        private MethodDeclarationSyntax GenerateConvertToManaged(StructSyntaxInfo info)
        {
            return GenerateMarshallerMethod(
                inputType: info.NativeName,
                inputName: "unmanaged",
                outputType: info.Name,
                outputName: "managed",
                methodName: "ConvertToManaged",
                fields: info.Fields,
                f => f.Marshaller.ToManaged("unmanaged")
            );
        }

        private static MethodDeclarationSyntax GenerateMarshallerMethod(
            string inputType,
            string inputName,
            string outputType,
            string outputName,
            string methodName,
            FieldSyntaxInfo[] fields,
            Func<FieldSyntaxInfo, ExpressionSyntax> marshaller)
        {
            var method = MethodDeclaration(IdentifierName(outputType), methodName)
                .AddModifiers(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.StaticKeyword))
                .AddParameterListParameters(Parameter(Identifier(inputName)).WithType(IdentifierName(inputType)));

            var outputVariable = LocalDeclarationStatement(VariableDeclaration(IdentifierName(outputType)).AddVariables(VariableDeclarator(
                Identifier(outputName)
            ).WithInitializer(EqualsValueClause(ObjectCreationExpression(IdentifierName(outputType)).AddArgumentListArguments()))));

            var statements = new List<StatementSyntax>
            {
                outputVariable
            };

            foreach (var field in fields)
            {
                var statement = ExpressionStatement(
                    AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression,
                        MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            IdentifierName(outputName),
                            IdentifierName(field.Name)
                        ),
                        marshaller(field)
                    )
                );

                statements.Add(statement);
            }

            statements.Add(ReturnStatement(IdentifierName(outputName)));

            method = method.WithBody(Block(List(statements)));

            return method;
        }

        #endregion

        private StructDeclarationSyntax GenerateNativeStructType(StructSyntaxInfo info)
        {
            var nativeTypeModifiers = info.Syntax.Modifiers.Where(m => !m.IsKind(SyntaxKind.PublicKeyword) && !m.IsKind(SyntaxKind.PartialKeyword)).ToList();
            nativeTypeModifiers.Insert(0, Token(SyntaxKind.InternalKeyword));

            var nativeType = StructDeclaration(info.NativeName).WithModifiers(TokenList(nativeTypeModifiers)).WithMembers(
                List(
                    info.Fields.Select(
                        f => (MemberDeclarationSyntax)FieldDeclaration(
                            VariableDeclaration(
                                IdentifierName(f.Marshaller.UnmanagedType)
                            ).AddVariables(
                                VariableDeclarator(f.Name)
                            )
                        ).WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword)))
                    )
                )
            );

            return nativeType;
        }

        private StructDeclarationSyntax GenerateOuterStructType(StructSyntaxInfo info, ClassDeclarationSyntax marshaller, StructDeclarationSyntax nativeType)
        {
            var nativeMarshallingAttribute = Attribute(
                IdentifierName("NativeMarshalling"),
                AttributeArgumentList(
                    SingletonSeparatedList(
                        AttributeArgument(
                            TypeOfExpression(IdentifierName("Marshaller"))
                        )
                    )
                )
            );

            var outerStruct = StructDeclaration(info.Name)
                .WithModifiers(info.Syntax.Modifiers)
                .WithoutLeadingTrivia()
                .AddMembers(marshaller, nativeType)
                .AddAttributeLists(AttributeList().AddAttributes(nativeMarshallingAttribute));

            return outerStruct;
        }

        #endregion

        private SyntaxTree[] GetSyntaxTrees()
        {
            var dll = typeof(StructSourceGenerator).Assembly.Location;
            var solution = FileVersionInfo.GetVersionInfo(dll).FileDescription;
            var structDir = Path.Combine(solution, "ClrDebug", "Native", "Struct");

            var files = Directory.EnumerateFiles(structDir, "*.cs", SearchOption.AllDirectories).ToArray();

            var trees = files.Select(f => CSharpSyntaxTree.ParseText(File.ReadAllText(f), CSharpParseOptions.Default.WithPreprocessorSymbols("GENERATED_MARSHALLING"))).ToArray();

            return trees;
        }
    }
}
