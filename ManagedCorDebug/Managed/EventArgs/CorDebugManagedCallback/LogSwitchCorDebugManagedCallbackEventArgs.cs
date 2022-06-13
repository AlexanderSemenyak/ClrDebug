using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback.LogSwitch"/> method.
    /// </summary>
    public class LogSwitchCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.LogSwitch;

        #region AppDomain

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugAppDomain rawAppDomain;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugAppDomain appDomain;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the managed thread that created, modified, or deleted a debugging/tracing switch.
        /// </summary>
        public CorDebugAppDomain AppDomain
        {
            get
            {
                if (appDomain == null && rawAppDomain != null)
                    appDomain = new CorDebugAppDomain(rawAppDomain);

                return appDomain;
            }
        }

        #endregion
        #region Thread

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugThread rawThread;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugThread thread;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugThread"/> object that represents the managed thread.
        /// </summary>
        public CorDebugThread Thread
        {
            get
            {
                if (thread == null && rawThread != null)
                    thread = new CorDebugThread(rawThread);

                return thread;
            }
        }

        #endregion
        
        /// <summary>
        /// A value that indicates the severity level of the descriptive message that was written to the event log.
        /// </summary>
        public int LLevel { get; }

        /// <summary>
        /// A value of the <see cref="LogSwitchCallReason"/> enumeration that indicates the operation performed on the debugging/tracing switch.
        /// </summary>
        public LogSwitchCallReason UlReason { get; }

        /// <summary>
        /// A pointer to the name of the debugging/tracing switch.
        /// </summary>
        public string LogSwitchName { get; }

        /// <summary>
        /// A pointer to the name of the parent of the debugging/tracing switch.
        /// </summary>
        public string ParentName { get; }

        /// <summary>
        /// Notifies the debugger that a common language runtime (CLR) managed thread has called a method in the <see cref="Switch"/> class to create, modify, or delete a debugging/tracing switch.
        /// </summary>
        /// <param name="pAppDomain">A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain containing the managed thread that created, modified, or deleted a debugging/tracing switch.</param>
        /// <param name="pThread">A pointer to an <see cref="ICorDebugThread"/> object that represents the managed thread.</param>
        /// <param name="lLevel">A value that indicates the severity level of the descriptive message that was written to the event log.</param>
        /// <param name="ulReason">A value of the <see cref="LogSwitchCallReason"/> enumeration that indicates the operation performed on the debugging/tracing switch.</param>
        /// <param name="pLogSwitchName">A pointer to the name of the debugging/tracing switch.</param>
        /// <param name="pParentName">A pointer to the name of the parent of the debugging/tracing switch.</param>
        public LogSwitchCorDebugManagedCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, int lLevel, LogSwitchCallReason ulReason, string pLogSwitchName, string pParentName)
        {
            rawAppDomain = pAppDomain;
            rawThread = pThread;
            LLevel = lLevel;
            UlReason = ulReason;
            LogSwitchName = pLogSwitchName;
            ParentName = pParentName;
        }
    }
}