﻿namespace ClrDebug.DbgEng
{
    /// <summary>
    /// EndSession flags.
    /// </summary>
    public enum DEBUG_END : uint
    {
        /// <summary>
        /// Perform cleanup for the session.
        /// </summary>
        PASSIVE = 0,

        /// <summary>
        /// Actively terminate the session and then perform cleanup.
        /// </summary>
        ACTIVE_TERMINATE = 1,

        /// <summary>
        /// If possible, detach from all processes and then perform cleanup.
        /// </summary>
        ACTIVE_DETACH = 2,

        /// <summary>
        /// Perform whatever cleanup is possible that doesn't require acquiring any locks.<para/>
        /// This is useful for situations where a thread is currently using the engine but the
        /// application needs to exit and still wants to give the engine the opportunity to clean
        /// up as much as possible. This may leave the engine in an indeterminate state so further
        /// engine calls should not be made. When making a reentrant EndSession call from a remote
        /// client it is the callers responsibility to ensure that the server can process the request.
        /// It is best to avoid making such calls.
        /// </summary>
        END_REENTRANT = 3,

        /// <summary>
        /// Notify a server that a remote client is disconnecting. This isnt required but if it isnt
        /// called then no disconnect messages will be generated by the server.
        /// </summary>
        END_DISCONNECT = 4,
    }
}
