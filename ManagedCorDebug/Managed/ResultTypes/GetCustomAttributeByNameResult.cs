using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetCustomAttributeByName"/> method.
    /// </summary>
    public struct GetCustomAttributeByNameResult
    {
        /// <summary>
        /// [out] A pointer to an array of data that is the value of the custom attribute.
        /// </summary>
        public IntPtr ppData { get; }

        /// <summary>
        /// [out] The size in bytes of the data returned in *ppData.
        /// </summary>
        public int pcbData { get; }

        public GetCustomAttributeByNameResult(IntPtr ppData, int pcbData)
        {
            this.ppData = ppData;
            this.pcbData = pcbData;
        }
    }
}