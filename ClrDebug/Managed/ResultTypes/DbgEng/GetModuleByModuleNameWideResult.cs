﻿using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSymbols.GetModuleByModuleNameWide"/> method.
    /// </summary>
    [DebuggerDisplay("Index = {Index}, Base = {Base}")]
    public struct GetModuleByModuleNameWideResult
    {
        /// <summary>
        /// Receives the index of the first module with the name Name. If Index is NULL, this information is not returned.
        /// </summary>
        public int Index { get; }

        /// <summary>
        /// Receives the location in the target's memory address space of the base of the module. If Base is NULL, this information is not returned.
        /// </summary>
        public long Base { get; }

        public GetModuleByModuleNameWideResult(int index, long @base)
        {
            Index = index;
            Base = @base;
        }
    }
}
