﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// A subclass of "ICorDebugHeapValue" that represents a boxed value class object.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("CC7BCAFC-8A68-11D2-983C-0000F808342D")]
    [ComImport]
    public interface ICorDebugBoxValue : ICorDebugHeapValue
    {
#if !GENERATED_MARSHALLING
        /// <summary>
        /// Gets the primitive type of this "ICorDebugValue" object.
        /// </summary>
        /// <param name="pType">[out] A pointer to a value of the "CorElementType" enumeration that indicates the value's type.</param>
        /// <remarks>
        /// If the object is a complex run-time type, that type may be examined through the appropriate subclasses of the <see cref="ICorDebugValue"/>
        /// interface. For example, "ICorDebugObjectValue", which inherits from <see cref="ICorDebugValue"/>, represents a complex type.
        /// The GetType and <see cref="ICorDebugObjectValue.GetClass"/> methods each return information about the type of a
        /// value. They are both superseded by the generics-aware <see cref="ICorDebugValue2.GetExactType"/> method.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetType(
            [Out] out CorElementType pType);

        /// <summary>
        /// Gets the size, in bytes, of this "ICorDebugValue" object.
        /// </summary>
        /// <param name="pSize">[out] The size, in bytes, of this value object.</param>
        /// <remarks>
        /// If the value's type is a reference type, this method returns the size of the pointer rather than the size of the
        /// object. The <see cref="ICorDebugValue.GetSize"/> method returns COR_E_OVERFLOW for objects that are larger than 4 GB on 64-bit
        /// platforms. Use the <see cref="ICorDebugValue3.GetSize64"/> method instead for objects that are larger than 4 GB.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetSize(
            [Out] out int pSize);

        /// <summary>
        /// Gets the address of this "ICorDebugValue" object, which is in the process of being debugged.
        /// </summary>
        /// <param name="pAddress">[out] Pointer to a <see cref="CORDB_ADDRESS"/> object that specifies the address of this value object.</param>
        /// <remarks>
        /// If the value is unavailable, 0 (zero) is returned. This could happen if the value is at least partly in registers
        /// or stored in a garbage collector handle (GCHandle).
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetAddress(
            [Out] out CORDB_ADDRESS pAddress);

        /// <summary>
        /// The CreateBreakpoint method is currently not implemented.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT CreateBreakpoint(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValueBreakpoint ppBreakpoint);

        /// <summary>
        /// Gets a value that indicates whether the object represented by this <see cref="ICorDebugHeapValue"/> is valid. This method has been deprecated in the .NET Framework version 2.0.
        /// </summary>
        /// <param name="pbValid">[out] A pointer to a Boolean value that indicates whether this value on the heap is valid.</param>
        /// <remarks>
        /// The value is invalid if it has been reclaimed by the garbage collector. This method has been deprecated. In the
        /// .NET Framework 2.0, all values are valid until <see cref="ICorDebugController.Continue"/> is called, at which time
        /// the values are invalidated.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT IsValid(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbValid);

        /// <summary>
        /// This method is not implemented in the current version of the .NET Framework.
        /// </summary>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT CreateRelocBreakpoint(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugValueBreakpoint ppBreakpoint);
#endif

        /// <summary>
        /// Gets the boxed value.
        /// </summary>
        /// <param name="ppObject">[out] A pointer to the address of an <see cref="ICorDebugObjectValue"/> object that represents the boxed value.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetObject(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugObjectValue ppObject);
    }
}
