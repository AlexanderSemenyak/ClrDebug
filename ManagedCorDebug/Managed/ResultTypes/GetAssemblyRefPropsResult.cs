using System;

namespace ManagedCorDebug
{
    public struct GetAssemblyRefPropsResult
    {
        public IntPtr PpbPublicKeyOrToken { get; }

        public uint PcbPublicKeyOrToken { get; }

        public string SzName { get; }

        public ASSEMBLYMETADATA PMetaData { get; }

        public IntPtr PpbHashValue { get; }

        public uint PcbHashValue { get; }

        public CorAssemblyFlags PdwAssemblyFlags { get; }

        public GetAssemblyRefPropsResult(IntPtr ppbPublicKeyOrToken, uint pcbPublicKeyOrToken, string szName, ASSEMBLYMETADATA pMetaData, IntPtr ppbHashValue, uint pcbHashValue, CorAssemblyFlags pdwAssemblyFlags)
        {
            PpbPublicKeyOrToken = ppbPublicKeyOrToken;
            PcbPublicKeyOrToken = pcbPublicKeyOrToken;
            SzName = szName;
            PMetaData = pMetaData;
            PpbHashValue = ppbHashValue;
            PcbHashValue = pcbHashValue;
            PdwAssemblyFlags = pdwAssemblyFlags;
        }
    }
}