namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRRuntimeInfo.IsStarted"/> property.
    /// </summary>
    public struct IsStartedResult
    {
        /// <summary>
        /// [out] true if this runtime is started; otherwise, false.
        /// </summary>
        public int pbStarted { get; }

        /// <summary>
        /// [out] Returns the flags that were used to start the runtime.
        /// </summary>
        public int pdwStartupFlags { get; }

        public IsStartedResult(int pbStarted, int pdwStartupFlags)
        {
            this.pbStarted = pbStarted;
            this.pdwStartupFlags = pdwStartupFlags;
        }
    }
}