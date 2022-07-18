﻿using System;

namespace ClrDebug.DbgEng
{
    [Flags]
    public enum VER_SUITE : uint
    {
        SMALLBUSINESS = 0x00000001,
        ENTERPRISE = 0x00000002,
        BACKOFFICE = 0x00000004,
        COMMUNICATIONS = 0x00000008,
        TERMINAL = 0x00000010,
        SMALLBUSINESS_RESTRICTED = 0x00000020,
        EMBEDDEDNT = 0x00000040,
        DATACENTER = 0x00000080,
        SINGLEUSERTS = 0x00000100,
        PERSONAL = 0x00000200,
        BLADE = 0x00000400,
        EMBEDDED_RESTRICTED = 0x00000800,
        SECURITY_APPLIANCE = 0x00001000,
        STORAGE_SERVER = 0x00002000,
        COMPUTE_SERVER = 0x00004000,
        WH_SERVER = 0x00008000,
        MULTIUSERTS = 0x00020000
    }
}