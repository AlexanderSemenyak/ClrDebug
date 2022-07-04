﻿using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataProcess.FollowStub"/> method.
    /// </summary>
    [DebuggerDisplay("outAddr = {outAddr.ToString(),nq}, outBuffer = {outBuffer.ToString(),nq}, outFlags = {outFlags}")]
    public struct FollowStubResult
    {
        public CLRDATA_ADDRESS outAddr { get; }

        public CLRDATA_FOLLOW_STUB_BUFFER outBuffer { get; }

        public int outFlags { get; }

        public FollowStubResult(CLRDATA_ADDRESS outAddr, CLRDATA_FOLLOW_STUB_BUFFER outBuffer, int outFlags)
        {
            this.outAddr = outAddr;
            this.outBuffer = outBuffer;
            this.outFlags = outFlags;
        }
    }
}
