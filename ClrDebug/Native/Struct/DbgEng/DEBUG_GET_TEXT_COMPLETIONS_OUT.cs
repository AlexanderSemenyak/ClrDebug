﻿using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines information about text completions to get.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_GET_TEXT_COMPLETIONS_OUT
    {
        /// <summary>
        /// Flags. Valid flag values include the following:
        /// </summary>
        public DEBUG_GET_TEXT_COMPLETIONS Flags;

        /// <summary>
        /// The index of the replace location.
        /// </summary>
        public uint ReplaceIndex;

        /// <summary>
        /// Count value of matches.
        /// </summary>
        public uint MatchCount;

        /// <summary>
        /// Reserved.
        /// </summary>
        public uint Reserved1;

        /// <summary>
        /// Reserved.
        /// </summary>
        public ulong Reserved2;
        public ulong Reserved3;

        //Completions follow.
        //Completion data is zero-terminated strings ended by a final zero double-terminator.
    }
}
