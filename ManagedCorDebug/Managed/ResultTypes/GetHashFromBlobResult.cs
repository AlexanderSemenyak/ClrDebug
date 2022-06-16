using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRStrongName.GetHashFromBlob"/> method.
    /// </summary>
    [DebuggerDisplay("piHashAlg = {piHashAlg}, pbHash = {pbHash}, pchHash = {pchHash}")]
    public struct GetHashFromBlobResult
    {
        /// <summary>
        /// A constant that specifies the hash algorithm. Use zero for the default algorithm.
        /// </summary>
        public int piHashAlg { get; }

        /// <summary>
        /// The returned hash buffer.
        /// </summary>
        public IntPtr pbHash { get; }

        /// <summary>
        /// The size, in bytes, of the returned pbHash.
        /// </summary>
        public int pchHash { get; }

        public GetHashFromBlobResult(int piHashAlg, IntPtr pbHash, int pchHash)
        {
            this.piHashAlg = piHashAlg;
            this.pbHash = pbHash;
            this.pchHash = pchHash;
        }
    }
}