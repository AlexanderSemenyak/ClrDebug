﻿using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("ModulePtr = {ModulePtr.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DacpGetModuleAddress
    {
        public CLRDATA_ADDRESS ModulePtr;

        public HRESULT Request(IXCLRDataModule pDataModule)
        {
            IntPtr outBuffer;

            var hr = pDataModule.Request(
                (uint) DACDATAMODULEPRIV_REQUEST.GET_MODULEPTR,
                0,
                IntPtr.Zero,
                Marshal.SizeOf(this),
                out outBuffer
            );

            if (hr == HRESULT.S_OK)
                Marshal.PtrToStructure(outBuffer, this);

            return hr;
        }
    }
}