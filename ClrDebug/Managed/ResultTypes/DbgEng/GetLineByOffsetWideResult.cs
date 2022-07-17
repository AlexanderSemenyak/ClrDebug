﻿using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSymbols.GetLineByOffsetWide"/> method.
    /// </summary>
    [DebuggerDisplay("Line = {Line}, FileBuffer = {FileBuffer}, Displacement = {Displacement}")]
    public struct GetLineByOffsetWideResult
    {
        /// <summary>
        /// Receives the line number within the source file of the instruction specified by Offset. If Line is NULL, this information is not returned.
        /// </summary>
        public uint Line { get; }

        /// <summary>
        /// Receives the file name of the file that contains the instruction specified by Offset. If FileBuffer is NULL, this information is not returned.
        /// </summary>
        public string FileBuffer { get; }

        /// <summary>
        /// Receives the difference between the location specified in Offset and the location of the first instruction of the returned line.<para/>
        /// If Displacement is NULL, this information is not returned.
        /// </summary>
        public ulong Displacement { get; }

        public GetLineByOffsetWideResult(uint line, string fileBuffer, ulong displacement)
        {
            Line = line;
            FileBuffer = fileBuffer;
            Displacement = displacement;
        }
    }
}