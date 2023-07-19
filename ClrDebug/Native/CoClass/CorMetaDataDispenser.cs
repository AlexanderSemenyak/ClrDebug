﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.CoClass
{
    [Guid("E5CB7A31-7512-11d2-89CE-0080C792E5D8")]
    [ClassInterface(ClassInterfaceType.None)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComClass]
#endif
    public partial class CorMetaDataDispenser : IMetaDataDispenser
    {
        [PreserveSig]
        public virtual extern HRESULT DefineScope(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid rclsid,
            [In] int dwCreateFlags,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppIUnk);

        [PreserveSig]
        public virtual extern HRESULT OpenScope(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szScope,
            [In] CorOpenFlags dwOpenFlags,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppIUnk);

        [PreserveSig]
        public virtual extern HRESULT OpenScopeOnMemory(
            [In] IntPtr pData,
            [In] int cbData,
            [In] CorOpenFlags dwOpenFlags,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppIUnk);
    }
}
