namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedReaderSymbolSearchInfo.GetSymbolSearchInfo"/> method.
    /// </summary>
    public struct GetSymbolSearchInfoResult
    {
        /// <summary>
        /// [out] A pointer to a ULONG32 that receives the size of the buffer required to contain the search information.
        /// </summary>
        public int pcSearchInfo { get; }

        /// <summary>
        /// [out] A pointer that is set to the returned <see cref="ISymUnmanagedSymbolSearchInfo"/> interface.
        /// </summary>
        public SymUnmanagedSymbolSearchInfo rgpSearchInfo { get; }

        public GetSymbolSearchInfoResult(int pcSearchInfo, SymUnmanagedSymbolSearchInfo rgpSearchInfo)
        {
            this.pcSearchInfo = pcSearchInfo;
            this.rgpSearchInfo = rgpSearchInfo;
        }
    }
}