using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumParams"/> method.
    /// </summary>
    public struct EnumParamsResult
    {
        /// <summary>
        /// [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// [out] The array used to store the ParamDef tokens.
        /// </summary>
        public mdParamDef[] rParams { get; }

        /// <summary>
        /// [out] The number of ParamDef tokens returned in rParams.
        /// </summary>
        public int pcTokens { get; }

        public EnumParamsResult(IntPtr phEnum, mdParamDef[] rParams, int pcTokens)
        {
            this.phEnum = phEnum;
            this.rParams = rParams;
            this.pcTokens = pcTokens;
        }
    }
}