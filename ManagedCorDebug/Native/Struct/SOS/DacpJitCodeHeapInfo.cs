﻿using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Explicit)]
    public struct DacpJitCodeHeapInfo
	{
        [FieldOffset(0)]
		public int codeHeapType;

        //if CODEHEAP_LOADER

        [FieldOffset(4)]
        public CLRDATA_ADDRESS LoaderHeap;

        //if CODEHEAP_HOST

        [FieldOffset(4)]
        public CLRDATA_ADDRESS baseAddr;

        [FieldOffset(8)]
        public CLRDATA_ADDRESS currentAddr;
	};
}