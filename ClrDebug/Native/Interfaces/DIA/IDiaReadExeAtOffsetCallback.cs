﻿using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    /// <summary>
    /// Enables a client application to supply bytes of an executable file as specified by file position.
    /// </summary>
    /// <remarks>
    /// The client application implements this interface in order to provide the bytes of the executable using an absolute
    /// offset into the executable's file. To use a relative virtual address, implement the <see cref="IDiaReadExeAtRVACallback"/>
    /// interface. This method is implemented by the client application and passed to the <see cref="IDiaDataSource.loadDataForExe"/>
    /// method as an alternative method for reading the file.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("587A461C-B80B-4F54-9194-5032589A6319")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaReadExeAtOffsetCallback
    {
        /// <summary>
        /// Reads the specified number of bytes starting at the specified offset from an executable file.
        /// </summary>
        /// <param name="fileOffset">[in] The offset in the executable file to begin reading.</param>
        /// <param name="cbData">[in] Number of bytes to read.</param>
        /// <param name="pcbData">[out] Returns the number of bytes read.</param>
        /// <param name="pbData">[in, out] An array that is filled in with bytes read from file.</param>
        /// <remarks>
        /// This method is called by the DIA support code to load data bytes from an executable using an absolute file offset.
        /// This method is called in support of the <see cref="IDiaDataSource.loadDataForExe"/> method.
        /// </remarks>
        [PreserveSig]
        HRESULT ReadExecutableAt(
            [In] long fileOffset,
            [In] int cbData,
            [Out] out int pcbData,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] byte[] pbData);
    }
}
