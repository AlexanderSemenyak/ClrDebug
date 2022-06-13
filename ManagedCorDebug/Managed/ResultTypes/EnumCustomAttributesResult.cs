using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumCustomAttributes"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rCustomAttributes = {rCustomAttributes}, pcCustomAttributes = {pcCustomAttributes}")]
    public struct EnumCustomAttributesResult
    {
        /// <summary>
        /// A pointer to the returned enumerator.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// An array of custom attribute tokens.
        /// </summary>
        public mdCustomAttribute[] rCustomAttributes { get; }

        /// <summary>
        /// [out, optional] The actual number of token values returned in rCustomAttributes.
        /// </summary>
        public int pcCustomAttributes { get; }

        public EnumCustomAttributesResult(IntPtr phEnum, mdCustomAttribute[] rCustomAttributes, int pcCustomAttributes)
        {
            this.phEnum = phEnum;
            this.rCustomAttributes = rCustomAttributes;
            this.pcCustomAttributes = pcCustomAttributes;
        }
    }
}