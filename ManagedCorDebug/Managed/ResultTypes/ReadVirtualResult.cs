using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRDataTarget.ReadVirtual"/> method.
    /// </summary>
    [DebuggerDisplay("buffer = {buffer}, bytesRead = {bytesRead}")]
    public struct ReadVirtualResult
    {
        /// <summary>
        /// A pointer to a buffer that receives the data.
        /// </summary>
        public IntPtr buffer { get; }

        /// <summary>
        /// A pointer to the number of bytes returned.
        /// </summary>
        public int bytesRead { get; }

        public ReadVirtualResult(IntPtr buffer, int bytesRead)
        {
            this.buffer = buffer;
            this.bytesRead = bytesRead;
        }
    }
}