﻿using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("11206399-4B66-4EDB-98EA-85654E59AD45")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISOSDacInterface6
    {
        [PreserveSig]
        HRESULT GetMethodTableCollectibleData(
            CLRDATA_ADDRESS mt,
            out DacpMethodTableCollectibleData data);
    }
}