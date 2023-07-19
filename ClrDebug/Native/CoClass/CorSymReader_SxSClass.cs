﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.CoClass
{
    [Guid("0A3976C5-4529-4EF8-B0B0-42EED37082CD")]
    [ClassInterface(ClassInterfaceType.None)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComClass]
#endif
    public partial class CorSymReader_SxSClass : ISymUnmanagedReader, CorSymReader_SxS
    {
        [PreserveSig]
        public virtual extern HRESULT GetDocument(
            [In, MarshalAs(UnmanagedType.LPWStr)] string url,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid language,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid languageVendor,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid documentType,
#else
            [MarshalUsing(typeof(GuidMarshaller))] in Guid language,
            [MarshalUsing(typeof(GuidMarshaller))] in Guid languageVendor,
            [MarshalUsing(typeof(GuidMarshaller))] in Guid documentType,
#endif
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedDocument pRetVal);

        [PreserveSig]
        public virtual extern HRESULT GetDocuments([In] int cDocs, [Out] out int pcDocs,
            [Out, MarshalAs(UnmanagedType.LPArray)] ISymUnmanagedDocument[] pDocs);

        [PreserveSig]
        public virtual extern HRESULT GetUserEntryPoint([Out] out mdMethodDef pToken);

        [PreserveSig]
        public virtual extern HRESULT GetMethod([In] mdMethodDef token, [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedMethod pRetVal);

        [PreserveSig]
        public virtual extern HRESULT GetMethodByVersion(
            [In] mdMethodDef token,
            [In] int version,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedMethod pRetVal);

        [PreserveSig]
        public virtual extern HRESULT GetVariables(
            [In] int parent,
            [In] int cVars,
            [Out] out int pcVars,
            [Out, MarshalAs(UnmanagedType.LPArray)] ISymUnmanagedVariable[] pVars);

        [PreserveSig]
        public virtual extern HRESULT GetGlobalVariables(
            [In] int cVars,
            [Out] out int pcVars,
            [Out, MarshalAs(UnmanagedType.LPArray)] ISymUnmanagedVariable[] pVars);

        [PreserveSig]
        public virtual extern HRESULT GetMethodFromDocumentPosition(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            [In] int line,
            [In] int column,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedMethod pRetVal);

        [PreserveSig]
        public virtual extern HRESULT GetSymAttribute(
            [In] int parent,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [In] int cBuffer,
            [Out] out int pcBuffer,
            [Out] IntPtr buffer);

        [PreserveSig]
        public virtual extern HRESULT GetNamespaces(
            [In] int cNameSpaces,
            [Out] out int pcNameSpaces,
            [Out, MarshalAs(UnmanagedType.LPArray)] ISymUnmanagedNamespace[] namespaces);

        [PreserveSig]
        public virtual extern HRESULT Initialize(
            [MarshalAs(UnmanagedType.Interface), In] IMetaDataImport importer,
            [In, MarshalAs(UnmanagedType.LPWStr)] string filename,
            [In, MarshalAs(UnmanagedType.LPWStr)] string searchPath,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);

        [PreserveSig]
        public virtual extern HRESULT UpdateSymbolStore([In, MarshalAs(UnmanagedType.LPWStr)] string filename, [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);

        [PreserveSig]
        public virtual extern HRESULT ReplaceSymbolStore([In, MarshalAs(UnmanagedType.LPWStr)] string filename, [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);

        [PreserveSig]
        public virtual extern HRESULT GetSymbolStoreFileName(
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2)] char[] szName);

        [PreserveSig]
        public virtual extern HRESULT GetMethodsFromDocumentPosition(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            [In] int line,
            [In] int column,
            [In] int cMethod,
            [Out] out int pcMethod,
            [Out, MarshalAs(UnmanagedType.LPArray)] ISymUnmanagedMethod[] pRetVal);

        [PreserveSig]
        public virtual extern HRESULT GetDocumentVersion(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument pDoc,
            [Out] out int version,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbCurrent);

        [PreserveSig]
        public virtual extern HRESULT GetMethodVersion([MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedMethod pMethod, [Out] out int version);
    }
}
