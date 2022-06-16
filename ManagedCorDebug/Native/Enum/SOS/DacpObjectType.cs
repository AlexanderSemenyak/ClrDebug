using System;

namespace ManagedCorDebug
{
    [Flags]
	public enum DacpObjectType : uint
	{
		OBJ_STRING,
		OBJ_FREE,
		OBJ_OBJECT,
		OBJ_ARRAY,
		OBJ_OTHER,
	}
}
