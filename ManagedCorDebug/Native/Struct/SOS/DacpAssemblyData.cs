using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential)]
	public struct DacpAssemblyData
	{
		public CLRDATA_ADDRESS AssemblyPtr;
		public CLRDATA_ADDRESS ClassLoader;
		public CLRDATA_ADDRESS ParentDomain;
		public CLRDATA_ADDRESS BaseDomainPtr;
		public CLRDATA_ADDRESS AssemblySecDesc;
		public int isDynamic;
		public int ModuleCount;
		public int LoadContext;
		public int isDomainNeutral;
		public int dwLocationFlags;

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr, CLRDATA_ADDRESS baseDomainPtr)
        {
            return sos.GetAssemblyData(baseDomainPtr, addr, out this);
        }

        public HRESULT Request(ISOSDacInterface sos, CLRDATA_ADDRESS addr)
        {
            return Request(sos, addr, default(CLRDATA_ADDRESS));
        }
    }
}
