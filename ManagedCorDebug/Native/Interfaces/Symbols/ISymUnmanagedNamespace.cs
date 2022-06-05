﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a namespace.
    /// </summary>
    [Guid("0DFF7289-54F8-11D3-BD28-0000F80849BD")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISymUnmanagedNamespace
    {
        /// <summary>
        /// Gets the name of this namespace.
        /// </summary>
        /// <param name="cchName">[in] A ULONG32 that indicates the size of the szName buffer.</param>
        /// <param name="pcchName">[out] A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the namespace name, including the null termination.</param>
        /// <param name="szName">[out] A pointer to a buffer that contains the namespace name.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetName([In] uint cchName, out uint pcchName, [Out] StringBuilder szName);

        /// <summary>
        /// Gets the children of this namespace.
        /// </summary>
        /// <param name="cNameSpaces">[in] A ULONG32 that indicates the size of the namespaces array.</param>
        /// <param name="pcNameSpaces">[out] A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the namespaces.</param>
        /// <param name="namespaces">[out] A pointer to the buffer that contains the namespaces.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetNamespaces([In] uint cNameSpaces, out uint pcNameSpaces, [MarshalAs(UnmanagedType.Interface), Out]
            IntPtr namespaces); //ISymUnmanagedNamespace

        /// <summary>
        /// Returns all variables defined at global scope within this namespace.
        /// </summary>
        /// <param name="cVars">[in] A ULONG32 that indicates the size of the pVars array.</param>
        /// <param name="pcVars">[out] A pointer to a ULONG32 that receives the size of the buffer required to contain the namespaces.</param>
        /// <param name="pVars">[out] A pointer to a buffer that contains the namespaces.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetVariables([In] uint cVars, out uint pcVars, [MarshalAs(UnmanagedType.Interface), Out]
            IntPtr pVars); //ISymUnmanagedVariable
    }
}