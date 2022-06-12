using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods for participating in the scheduling of threads that would otherwise be blocked for a garbage collection.
    /// </summary>
    public class GCThreadControl : ComObject<IGCThreadControl>
    {
        public GCThreadControl(IGCThreadControl raw) : base(raw)
        {
        }

        #region IGCThreadControl
        #region ThreadIsBlockingForSuspension

        /// <summary>
        /// Notifies the host that the thread that is making the call is about to block, perhaps for a garbage collection or other suspension.
        /// </summary>
        /// <remarks>
        /// The host may choose within the ThreadIsBlockingForSuspension callback whether to reschedule a thread.
        /// </remarks>
        public void ThreadIsBlockingForSuspension()
        {
            HRESULT hr;

            if ((hr = TryThreadIsBlockingForSuspension()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the host that the thread that is making the call is about to block, perhaps for a garbage collection or other suspension.
        /// </summary>
        /// <remarks>
        /// The host may choose within the ThreadIsBlockingForSuspension callback whether to reschedule a thread.
        /// </remarks>
        public HRESULT TryThreadIsBlockingForSuspension()
        {
            /*HRESULT ThreadIsBlockingForSuspension();*/
            return Raw.ThreadIsBlockingForSuspension();
        }

        #endregion
        #region SuspensionStarting

        /// <summary>
        /// Notifies the host that the runtime is beginning a thread suspension for a garbage collection or other suspension.
        /// </summary>
        /// <remarks>
        /// Do not reschedule any threads during the SuspensionStarting callback.
        /// </remarks>
        public void SuspensionStarting()
        {
            HRESULT hr;

            if ((hr = TrySuspensionStarting()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the host that the runtime is beginning a thread suspension for a garbage collection or other suspension.
        /// </summary>
        /// <remarks>
        /// Do not reschedule any threads during the SuspensionStarting callback.
        /// </remarks>
        public HRESULT TrySuspensionStarting()
        {
            /*HRESULT SuspensionStarting();*/
            return Raw.SuspensionStarting();
        }

        #endregion
        #region SuspensionEnding

        /// <summary>
        /// Notifies the host that the runtime is resuming threads after a garbage collection or other suspension.
        /// </summary>
        /// <param name="generation">[in] The generation on which a garbage collection has been performed.</param>
        /// <remarks>
        /// Do not reschedule any threads during the SuspensionEnding callback.
        /// </remarks>
        public void SuspensionEnding(uint generation)
        {
            HRESULT hr;

            if ((hr = TrySuspensionEnding(generation)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the host that the runtime is resuming threads after a garbage collection or other suspension.
        /// </summary>
        /// <param name="generation">[in] The generation on which a garbage collection has been performed.</param>
        /// <remarks>
        /// Do not reschedule any threads during the SuspensionEnding callback.
        /// </remarks>
        public HRESULT TrySuspensionEnding(uint generation)
        {
            /*HRESULT SuspensionEnding(uint Generation);*/
            return Raw.SuspensionEnding(generation);
        }

        #endregion
        #endregion
    }
}