﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("B4CE6286-2A6B-3712-A3B7-1EE1DAD467B5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISymUnmanagedReader
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ISymUnmanagedDocument GetDocument(
            [In] ref ushort url,
            [In] Guid language,
            [In] Guid languageVendor,
            [In] Guid documentType);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetDocuments([In] uint cDocs, out uint pcDocs, [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedReader pDocs);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetUserEntryPoint();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ISymUnmanagedMethod GetMethod([In] uint token);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ISymUnmanagedMethod GetMethodByVersion([In] uint token, [In] int version);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetVariables([In] uint parent, [In] uint cVars, out uint pcVars, [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedReader pVars);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetGlobalVariables([In] uint cVars, out uint pcVars, [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedReader pVars);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.Interface)]
        ISymUnmanagedMethod GetMethodFromDocumentPosition(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            [In] uint line,
            [In] uint column);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSymAttribute(
            [In] uint parent,
            [In] ref ushort name,
            [In] uint cBuffer,
            out uint pcBuffer,
            [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedReader buffer);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetNamespaces([In] uint cNameSpaces, out uint pcNameSpaces, [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedReader namespaces);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Initialize([MarshalAs(UnmanagedType.IUnknown), In]
            object importer, [In] ref ushort filename, [In] ref ushort searchPath,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT UpdateSymbolStore([In] ref ushort filename, [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ReplaceSymbolStore([In] ref ushort filename, [MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetSymbolStoreFileName([In] uint cchName, out uint pcchName, [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedReader szName);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetMethodsFromDocumentPosition(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            [In] uint line,
            [In] uint column,
            [In] uint cMethod,
            out uint pcMethod,
            [MarshalAs(UnmanagedType.Interface), Out]
            ISymUnmanagedReader pRetVal);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetDocumentVersion([MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument pDoc, out int version, out int pbCurrent);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetMethodVersion([MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedMethod pMethod, out int version);
    }
}