﻿using System;

namespace ClrDebug.DbgEng
{
    [Flags]
    public enum DEBUG_PROC_DESC : uint
    {
        DEFAULT = 0,
        NO_PATHS = 1,
        NO_SERVICES = 2,
        NO_MTS_PACKAGES = 4,
        NO_COMMAND_LINE = 8,
        NO_SESSION_ID = 0x10,
        NO_USER_NAME = 0x20,
    }
}