﻿namespace ClrDebug.DIA
{
    /// <summary>
    /// Specifies the stack frame type.
    /// </summary>
    /// <remarks>
    /// The values in this enumeration are returned by a call to the <see cref="IDiaStackFrame.get_type"/> method.
    /// </remarks>
    public enum StackFrameTypeEnum
    {
        /// <summary>
        /// Frame pointer omitted; FPO info available.
        /// </summary>
        FrameTypeFPO,

        /// <summary>
        /// Kernel Trap frame.
        /// </summary>
        FrameTypeTrap,

        /// <summary>
        /// Kernel Trap frame.
        /// </summary>
        FrameTypeTSS,

        /// <summary>
        /// Standard EBP stack frame.
        /// </summary>
        FrameTypeStandard,

        /// <summary>
        /// Frame pointer omitted; Frame data info available.
        /// </summary>
        FrameTypeFrameData,

        /// <summary>
        /// Frame that does not have any debug info.
        /// </summary>
        FrameTypeUnknown = -1,
    }
}
