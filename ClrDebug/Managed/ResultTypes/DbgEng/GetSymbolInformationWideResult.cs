﻿using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugAdvanced.GetSymbolInformationWide"/> method.
    /// </summary>
    [DebuggerDisplay("StringBuffer = {StringBuffer}, StringSize = {StringSize}")]
    public struct GetSymbolInformationWideResult
    {
        /// <summary>
        /// Receives the requested string. The interpretation of this string depends on the value of Which.<para/>
        /// If StringBuffer is NULL, this information is not returned.
        /// </summary>
        public string StringBuffer { get; }

        /// <summary>
        /// Receives the size, in characters, of the string returned to StringBuffer. If StringSize is NULL, this information is not returned.
        /// </summary>
        public int StringSize { get; }

        public GetSymbolInformationWideResult(string stringBuffer, int stringSize)
        {
            StringBuffer = stringBuffer;
            StringSize = stringSize;
        }
    }
}