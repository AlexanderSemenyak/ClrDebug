using System;

namespace ManagedCorDebug
{
    [Flags]
	public enum CLRDataValueFlag : uint
	{
		CLRDATA_VALUE_DEFAULT = 0x00000000,
		CLRDATA_VALUE_IS_PRIMITIVE = CLRDataTypeFlag.CLRDATA_TYPE_IS_PRIMITIVE,
		CLRDATA_VALUE_IS_VALUE_TYPE = CLRDataTypeFlag.CLRDATA_TYPE_IS_VALUE_TYPE,
		CLRDATA_VALUE_IS_STRING = CLRDataTypeFlag.CLRDATA_TYPE_IS_STRING,
		CLRDATA_VALUE_IS_ARRAY = CLRDataTypeFlag.CLRDATA_TYPE_IS_ARRAY,
		CLRDATA_VALUE_IS_REFERENCE = CLRDataTypeFlag.CLRDATA_TYPE_IS_REFERENCE,
		CLRDATA_VALUE_IS_POINTER = CLRDataTypeFlag.CLRDATA_TYPE_IS_POINTER,
		CLRDATA_VALUE_IS_ENUM = CLRDataTypeFlag.CLRDATA_TYPE_IS_ENUM,
		CLRDATA_VALUE_ALL_KINDS = CLRDataTypeFlag.CLRDATA_TYPE_ALL_KINDS,
		CLRDATA_VALUE_IS_INHERITED = CLRDataFieldFlag.CLRDATA_FIELD_IS_INHERITED,
		CLRDATA_VALUE_IS_LITERAL = CLRDataFieldFlag.CLRDATA_FIELD_IS_LITERAL,
		CLRDATA_VALUE_FROM_INSTANCE = CLRDataFieldFlag.CLRDATA_FIELD_FROM_INSTANCE,
		CLRDATA_VALUE_FROM_TASK_LOCAL = CLRDataFieldFlag.CLRDATA_FIELD_FROM_TASK_LOCAL,
		CLRDATA_VALUE_FROM_STATIC = CLRDataFieldFlag.CLRDATA_FIELD_FROM_STATIC,
		CLRDATA_VALUE_ALL_LOCATIONS = CLRDataFieldFlag.CLRDATA_FIELD_ALL_LOCATIONS,
		CLRDATA_VALUE_ALL_FIELDS = CLRDataFieldFlag.CLRDATA_FIELD_ALL_FIELDS,
		CLRDATA_VALUE_IS_BOXED = 0x00001000,
	}
}
