using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpObjectData
	{
		public CLRDATA_ADDRESS MethodTable;
		public DacpObjectType ObjectType;
		public long Size;
		public CLRDATA_ADDRESS ElementTypeHandle;
		public CorElementType ElementType;
		public int dwRank;
		public long dwNumComponents;
		public long dwComponentSize;
		public CLRDATA_ADDRESS ArrayDataPtr;
		public CLRDATA_ADDRESS ArrayBoundsPtr;
		public CLRDATA_ADDRESS ArrayLowerBoundsPtr;
		public CLRDATA_ADDRESS RCW;
		public CLRDATA_ADDRESS CCW;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr)
        {
            return sos.GetObjectData(addr, out this);
        }
    }
}
