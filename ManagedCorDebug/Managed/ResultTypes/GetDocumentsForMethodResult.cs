using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymENCUnmanagedMethod.GetDocumentsForMethod"/> method.
    /// </summary>
    public struct GetDocumentsForMethodResult
    {
        /// <summary>
        /// [out] A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the documents.
        /// </summary>
        public int pcDocs { get; }

        /// <summary>
        /// [in] The buffer that contains the documents.
        /// </summary>
        public IntPtr documents { get; }

        public GetDocumentsForMethodResult(int pcDocs, IntPtr documents)
        {
            this.pcDocs = pcDocs;
            this.documents = documents;
        }
    }
}