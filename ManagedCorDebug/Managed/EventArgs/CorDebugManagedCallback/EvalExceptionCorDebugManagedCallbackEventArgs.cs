using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the arguments that were passed to the <see cref="ICorDebugManagedCallback.EvalException"/> method.
    /// </summary>
    public class EvalExceptionCorDebugManagedCallbackEventArgs : CorDebugManagedCallbackEventArgs
    {
        /// <summary>
        /// Gets the type of callback event that occurred.
        /// </summary>
        public override CorDebugManagedCallbackKind Kind => CorDebugManagedCallbackKind.EvalException;

        #region AppDomain

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugAppDomain rawAppDomain;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugAppDomain appDomain;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain in which the evaluation terminated.
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
        /// A pointer to an <see cref="ICorDebugThread"/> object that represents the thread in which the evaluation terminated.
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
        #region Eval

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ICorDebugEval rawEval;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CorDebugEval eval;

        /// <summary>
        /// A pointer to an <see cref="ICorDebugEval"/> object that represents the code that performed the evaluation.
        /// </summary>
        public CorDebugEval Eval
        {
            get
            {
                if (eval == null && rawEval != null)
                    eval = new CorDebugEval(rawEval);

                return eval;
            }
        }

        #endregion
        
        /// <summary>
        /// Notifies the debugger that an evaluation has terminated with an unhandled exception.
        /// </summary>
        /// <param name="pAppDomain">A pointer to an <see cref="ICorDebugAppDomain"/> object that represents the application domain in which the evaluation terminated.</param>
        /// <param name="pThread">A pointer to an <see cref="ICorDebugThread"/> object that represents the thread in which the evaluation terminated.</param>
        /// <param name="pEval">A pointer to an <see cref="ICorDebugEval"/> object that represents the code that performed the evaluation.</param>
        public EvalExceptionCorDebugManagedCallbackEventArgs(ICorDebugAppDomain pAppDomain, ICorDebugThread pThread, ICorDebugEval pEval)
        {
            rawAppDomain = pAppDomain;
            rawThread = pThread;
            rawEval = pEval;
        }
    }
}