using System;

namespace ClrDebug
{
    [Flags]
	public enum CLRDataFieldFlag : uint
	{
		CLRDATA_FIELD_DEFAULT = 0x00000000,
		CLRDATA_FIELD_IS_PRIMITIVE = CLRDataTypeFlag.CLRDATA_TYPE_IS_PRIMITIVE,
		CLRDATA_FIELD_IS_VALUE_TYPE = CLRDataTypeFlag.CLRDATA_TYPE_IS_VALUE_TYPE,
		CLRDATA_FIELD_IS_STRING = CLRDataTypeFlag.CLRDATA_TYPE_IS_STRING,
		CLRDATA_FIELD_IS_ARRAY = CLRDataTypeFlag.CLRDATA_TYPE_IS_ARRAY,
		CLRDATA_FIELD_IS_REFERENCE = CLRDataTypeFlag.CLRDATA_TYPE_IS_REFERENCE,
		CLRDATA_FIELD_IS_POINTER = CLRDataTypeFlag.CLRDATA_TYPE_IS_POINTER,
		CLRDATA_FIELD_IS_ENUM = CLRDataTypeFlag.CLRDATA_TYPE_IS_ENUM,
		CLRDATA_FIELD_ALL_KINDS = CLRDataTypeFlag.CLRDATA_TYPE_ALL_KINDS,
		CLRDATA_FIELD_IS_INHERITED = 0x00000080,
		CLRDATA_FIELD_IS_LITERAL = 0x00000100,
		CLRDATA_FIELD_FROM_INSTANCE = 0x00000200,
		CLRDATA_FIELD_FROM_TASK_LOCAL = 0x00000400,
		CLRDATA_FIELD_FROM_STATIC = 0x00000800,
		CLRDATA_FIELD_ALL_LOCATIONS = 0x00000e00,
		CLRDATA_FIELD_ALL_FIELDS = 0x00000eff,
	}
}