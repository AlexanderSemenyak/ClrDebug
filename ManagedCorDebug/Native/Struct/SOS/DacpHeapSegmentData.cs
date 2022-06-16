using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpHeapSegmentData
	{
		public CLRDATA_ADDRESS segmentAddr;
		public CLRDATA_ADDRESS allocated;
		public CLRDATA_ADDRESS committed;
		public CLRDATA_ADDRESS reserved;
		public CLRDATA_ADDRESS used;
		public CLRDATA_ADDRESS mem;
		public CLRDATA_ADDRESS next;
		public CLRDATA_ADDRESS gc_heap;
		public CLRDATA_ADDRESS highAllocMark;
		public long flags;
		public CLRDATA_ADDRESS background_allocated;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr, DacpGcHeapDetails heap)
        {
            highAllocMark = 0;

            var hr = sos.GetHeapSegmentData(addr, out this);

            if (hr == HRESULT.S_OK && highAllocMark == 0)
            {
                if (segmentAddr == heap.ephemeral_heap_segment)
                    highAllocMark = heap.alloc_allocated;
                else
                    highAllocMark = allocated;
            }

            return hr;
        }
    }
}
