using System;

namespace ManagedCorDebug
{
    [Flags]
	public enum CLRNativeImageDumpOptions : uint
	{
		CLRNATIVEIMAGE_PE_INFO = 0x00000001,
		CLRNATIVEIMAGE_COR_INFO = 0x00000002,
		CLRNATIVEIMAGE_FIXUP_TABLES = 0x00000004,
		CLRNATIVEIMAGE_FIXUP_HISTOGRAM = 0x00000008,
		CLRNATIVEIMAGE_MODULE = 0x00000010,
		CLRNATIVEIMAGE_METHODS = 0x00000020,
		CLRNATIVEIMAGE_DISASSEMBLE_CODE = 0x00000040,
		CLRNATIVEIMAGE_IL = 0x00000080,
		CLRNATIVEIMAGE_METHODTABLES = 0x00000100,
		CLRNATIVEIMAGE_NATIVE_INFO = 0x00000200,
		CLRNATIVEIMAGE_MODULE_TABLES = 0x00000400,
		CLRNATIVEIMAGE_FROZEN_SEGMENT = 0x00000800,
		CLRNATIVEIMAGE_PE_FILE = 0x00001000,
		CLRNATIVEIMAGE_GC_INFO = 0x00002000,
		CLRNATIVEIMAGE_EECLASSES = 0x00004000,
		CLRNATIVEIMAGE_NATIVE_TABLES = 0x00008000,
		CLRNATIVEIMAGE_PRECODES = 0x00010000,
		CLRNATIVEIMAGE_TYPEDESCS = 0x00020000,
		CLRNATIVEIMAGE_VERBOSE_TYPES = 0x00040000,
		CLRNATIVEIMAGE_METHODDESCS = 0x00080000,
		CLRNATIVEIMAGE_METADATA = 0x00100000,
		CLRNATIVEIMAGE_DISABLE_NAMES = 0x00200000,
		CLRNATIVEIMAGE_DISABLE_REBASING = 0x00400000,
		CLRNATIVEIMAGE_SLIM_MODULE_TBLS = 0x00800000,
		CLRNATIVEIMAGE_RESOURCES = 0x01000000,
		CLRNATIVEIMAGE_FILE_OFFSET = 0x02000000,
		CLRNATIVEIMAGE_DEBUG_TRACE = 0x04000000,
		CLRNATIVEIMAGE_RELOCATIONS = 0x08000000,
		CLRNATIVEIMAGE_FIXUP_THUNKS = 0x10000000,
		CLRNATIVEIMAGE_DEBUG_COVERAGE = 0x80000000,
	}
}
