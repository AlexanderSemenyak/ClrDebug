﻿using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    class FieldMarshaller
    {
        public string Name { get; }

        public string ManagedType { get; }

        public string UnmanagedType { get; }

        public FieldMarshaller(string name, string managedType, string unmanagedType)
        {
            Name = name;
            ManagedType = managedType;
            UnmanagedType = unmanagedType;
        }

        public virtual ExpressionSyntax ToUnmanaged(string inputName) =>
            MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName(inputName), IdentifierName(Name));

        public virtual ExpressionSyntax ToManaged(string inputName) =>
            MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName(inputName), IdentifierName(Name));
    }
}
