using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.EnumTypeRefs"/> method.
    /// </summary>
    [DebuggerDisplay("phEnum = {phEnum}, rTypeRefs = {rTypeRefs}, pcTypeRefs = {pcTypeRefs}")]
    public struct EnumTypeRefsResult
    {
        /// <summary>
        /// A pointer to the enumerator. This must be NULL for the first call of this method.
        /// </summary>
        public IntPtr phEnum { get; }

        /// <summary>
        /// The array used to store the TypeRef tokens.
        /// </summary>
        public mdTypeRef[] rTypeRefs { get; }

        /// <summary>
        /// A pointer to the number of TypeRef tokens returned in rTypeRefs.
        /// </summary>
        public int pcTypeRefs { get; }

        public EnumTypeRefsResult(IntPtr phEnum, mdTypeRef[] rTypeRefs, int pcTypeRefs)
        {
            this.phEnum = phEnum;
            this.rTypeRefs = rTypeRefs;
            this.pcTypeRefs = pcTypeRefs;
        }
    }
}