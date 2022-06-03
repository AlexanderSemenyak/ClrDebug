﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("6D05FAE3-189C-4630-A6DC-1C251E1C01AB")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICLRDataTarget2 : ICLRDataTarget
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetMachineType(out uint machineType);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetPointerSize(out uint pointerSize);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetImageBase([MarshalAs(UnmanagedType.LPWStr), In] string imagePath, out ulong baseAddress);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT ReadVirtual([In] ulong address, out byte buffer, [In] uint bytesRequested, out uint bytesRead);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT WriteVirtual(
            [In] ulong address,
            [In] ref byte buffer,
            [In] uint bytesRequested,
            out uint bytesWritten);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetTLSValue([In] uint threadID, [In] uint index, out ulong value);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT SetTLSValue([In] uint threadID, [In] uint index, [In] ulong value);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetCurrentThreadID(out uint threadID);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetThreadContext(
            [In] uint threadID,
            [In] uint contextFlags,
            [In] uint contextSize,
            out byte context);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT SetThreadContext([In] uint threadID, [In] uint contextSize, [In] ref byte context);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Request(
            [In] uint reqCode,
            [In] uint inBufferSize,
            [In] ref byte inBuffer,
            [In] uint outBufferSize,
            out byte outBuffer);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT AllocVirtual([In] ulong addr, [In] uint size, [In] uint typeFlags, [In] uint protectFlags, out ulong virt);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT FreeVirtual([In] ulong addr, [In] uint size, [In] uint typeFlags);
    }
}