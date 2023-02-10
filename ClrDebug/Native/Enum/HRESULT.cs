﻿namespace ClrDebug
{
    public enum HRESULT : uint
    {
        S_OK = 0x0,
        S_FALSE = 0x1,
        CLDB_S_TRUNCATION = 0x131106,
        META_S_DUPLICATE = 0x131197,
        CORDBG_S_BAD_START_SEQUENCE_POINT = 0x13130b,
        CORDBG_S_BAD_END_SEQUENCE_POINT = 0x13130c,
        CORDBG_S_FUNC_EVAL_HAS_NO_RESULT = 0x131316,
        CORDBG_S_VALUE_POINTS_TO_VOID = 0x131317,
        CORDBG_S_FUNC_EVAL_ABORTED = 0x131319,
        CORDBG_S_AT_END_OF_STACK = 0x131324,
        CORDBG_S_NOT_ALL_BITS_SET = 0x131c13,

        E_NOTIMPL = 0x80004001,
        E_NOINTERFACE = 0x80004002,
        E_FAIL = 0x80004005,
        E_UNEXPECTED = 0x8000FFFF,
        RPC_E_NOT_REGISTERED = 0x80010103,
        RPC_E_SERVERCALL_RETRYLATER = 0x8001010A,
        E_OUTOFMEMORY = 0x8007000E,
        ERROR_NOT_ENOUGH_MEMORY = 0x80070008,
        ERROR_READ_FAULT = 0x8007001E,
        ERROR_BUFFER_OVERFLOW = 0x8007006F,
        ERROR_BAD_EXE_FORMAT = 0x800700C1,
        E_INVALIDARG = 0x80070057,
        EVENT_E_INTERNALEXCEPTION = 0x80040205,

        CEE_E_CVTRES_NOT_FOUND = 0x80131001,
        COR_E_TYPEUNLOADED = 0x80131013,
        COR_E_APPDOMAINUNLOADED = 0x80131014,
        COR_E_CANNOTUNLOADAPPDOMAIN = 0x80131015,
        MSEE_E_ASSEMBLYLOADINPROGRESS = 0x80131016,
        COR_E_ASSEMBLYEXPECTED = 0x80131018,
        COR_E_FIXUPSINEXE = 0x80131019,
        COR_E_NEWER_RUNTIME = 0x8013101b,
        COR_E_MULTIMODULEASSEMBLIESDIALLOWED = 0x8013101e,
        HOST_E_DEADLOCK = 0x80131020,
        HOST_E_INVALIDOPERATION = 0x80131022,
        HOST_E_CLRNOTAVAILABLE = 0x80131023,
        HOST_E_EXITPROCESS_THREADABORT = 0x80131027,
        HOST_E_EXITPROCESS_ADUNLOAD = 0x80131028,
        HOST_E_EXITPROCESS_TIMEOUT = 0x80131029,
        HOST_E_EXITPROCESS_OUTOFMEMORY = 0x8013102a,
        COR_E_MODULE_HASH_CHECK_FAILED = 0x80131039,
        FUSION_E_REF_DEF_MISMATCH = 0x80131040,
        FUSION_E_INVALID_PRIVATE_ASM_LOCATION = 0x80131041,
        FUSION_E_ASM_MODULE_MISSING = 0x80131042,
        FUSION_E_PRIVATE_ASM_DISALLOWED = 0x80131044,
        FUSION_E_SIGNATURE_CHECK_FAILED = 0x80131045,
        FUSION_E_INVALID_NAME = 0x80131047,
        FUSION_E_CODE_DOWNLOAD_DISABLED = 0x80131048,
        FUSION_E_HOST_GAC_ASM_MISMATCH = 0x80131050,
        FUSION_E_LOADFROM_BLOCKED = 0x80131051,
        FUSION_E_CACHEFILE_FAILED = 0x80131052,
        FUSION_E_APP_DOMAIN_LOCKED = 0x80131053,
        FUSION_E_CONFIGURATION_ERROR = 0x80131054,
        FUSION_E_MANIFEST_PARSE_ERROR = 0x80131055,
        COR_E_LOADING_REFERENCE_ASSEMBLY = 0x80131058,
        COR_E_NI_AND_RUNTIME_VERSION_MISMATCH = 0x80131059,
        COR_E_LOADING_WINMD_REFERENCE_ASSEMBLY = 0x80131069,
        COR_E_AMBIGUOUSIMPLEMENTATION = 0x8013106a,
        CLDB_E_FILE_BADREAD = 0x80131100,
        CLDB_E_FILE_BADWRITE = 0x80131101,
        CLDB_E_FILE_OLDVER = 0x80131107,
        CLDB_E_SMDUPLICATE = 0x8013110a,
        CLDB_E_NO_DATA = 0x8013110b,
        CLDB_E_INCOMPATIBLE = 0x8013110d,
        CLDB_E_FILE_CORRUPT = 0x8013110e,
        CLDB_E_BADUPDATEMODE = 0x80131110,
        CLDB_E_INDEX_NOTFOUND = 0x80131124,
        CLDB_E_RECORD_NOTFOUND = 0x80131130,
        CLDB_E_RECORD_OUTOFORDER = 0x80131135,
        CLDB_E_TOO_BIG = 0x80131154,
        META_E_INVALID_TOKEN_TYPE = 0x8013115f,
        TLBX_E_LIBNOTREGISTERED = 0x80131165,
        META_E_BADMETADATA = 0x8013118a,
        META_E_BAD_SIGNATURE = 0x80131192,
        META_E_BAD_INPUT_PARAMETER = 0x80131193,
        META_E_CANNOTRESOLVETYPEREF = 0x80131196,
        META_E_STRINGSPACE_FULL = 0x80131198,
        META_E_HAS_UNMARKALL = 0x8013119a,
        META_E_MUST_CALL_UNMARKALL = 0x8013119b,
        META_E_CA_INVALID_TARGET = 0x801311c0,
        META_E_CA_INVALID_VALUE = 0x801311c1,
        META_E_CA_INVALID_BLOB = 0x801311c2,
        META_E_CA_REPEATED_ARG = 0x801311c3,
        META_E_CA_UNKNOWN_ARGUMENT = 0x801311c4,
        META_E_CA_UNEXPECTED_TYPE = 0x801311c7,
        META_E_CA_INVALID_ARGTYPE = 0x801311c8,
        META_E_CA_INVALID_ARG_FOR_TYPE = 0x801311c9,
        META_E_CA_INVALID_UUID = 0x801311ca,
        META_E_CA_INVALID_MARSHALAS_FIELDS = 0x801311cb,
        META_E_CA_NT_FIELDONLY = 0x801311cc,
        META_E_CA_NEGATIVE_PARAMINDEX = 0x801311cd,
        META_E_CA_NEGATIVE_CONSTSIZE = 0x801311cf,
        META_E_CA_FIXEDSTR_SIZE_REQUIRED = 0x801311d0,
        META_E_CA_CUSTMARSH_TYPE_REQUIRED = 0x801311d1,
        META_E_NOT_IN_ENC_MODE = 0x801311d4,
        META_E_CA_BAD_FRIENDS_ARGS = 0x801311e5,
        META_E_CA_FRIENDS_SN_REQUIRED = 0x801311e6,
        VLDTR_E_RID_OUTOFRANGE = 0x80131203,
        VLDTR_E_STRING_INVALID = 0x80131206,
        VLDTR_E_GUID_INVALID = 0x80131207,
        VLDTR_E_BLOB_INVALID = 0x80131208,
        VLDTR_E_MR_BADCALLINGCONV = 0x80131224,
        VLDTR_E_SIGNULL = 0x80131237,
        VLDTR_E_MD_BADCALLINGCONV = 0x80131239,
        VLDTR_E_MD_THISSTATIC = 0x8013123a,
        VLDTR_E_MD_NOTTHISNOTSTATIC = 0x8013123b,
        VLDTR_E_MD_NOARGCNT = 0x8013123c,
        VLDTR_E_SIG_MISSELTYPE = 0x8013123d,
        VLDTR_E_SIG_MISSTKN = 0x8013123e,
        VLDTR_E_SIG_TKNBAD = 0x8013123f,
        VLDTR_E_SIG_MISSFPTR = 0x80131240,
        VLDTR_E_SIG_MISSFPTRARGCNT = 0x80131241,
        VLDTR_E_SIG_MISSRANK = 0x80131242,
        VLDTR_E_SIG_MISSNSIZE = 0x80131243,
        VLDTR_E_SIG_MISSSIZE = 0x80131244,
        VLDTR_E_SIG_MISSNLBND = 0x80131245,
        VLDTR_E_SIG_MISSLBND = 0x80131246,
        VLDTR_E_SIG_BADELTYPE = 0x80131247,
        VLDTR_E_TD_ENCLNOTNESTED = 0x80131256,
        VLDTR_E_FMD_PINVOKENOTSTATIC = 0x80131277,
        VLDTR_E_SIG_SENTINMETHODDEF = 0x801312df,
        VLDTR_E_SIG_SENTMUSTVARARG = 0x801312e0,
        VLDTR_E_SIG_MULTSENTINELS = 0x801312e1,
        VLDTR_E_SIG_MISSARG = 0x801312e3,
        VLDTR_E_SIG_BYREFINFIELD = 0x801312e4,
        CORDBG_E_UNRECOVERABLE_ERROR = 0x80131300,
        CORDBG_E_PROCESS_TERMINATED = 0x80131301,
        CORDBG_E_PROCESS_NOT_SYNCHRONIZED = 0x80131302,
        CORDBG_E_CLASS_NOT_LOADED = 0x80131303,
        CORDBG_E_IL_VAR_NOT_AVAILABLE = 0x80131304,
        CORDBG_E_BAD_REFERENCE_VALUE = 0x80131305,
        CORDBG_E_FIELD_NOT_AVAILABLE = 0x80131306,
        CORDBG_E_NON_NATIVE_FRAME = 0x80131307,
        CORDBG_E_CODE_NOT_AVAILABLE = 0x80131309,
        CORDBG_E_FUNCTION_NOT_IL = 0x8013130a,
        CORDBG_E_CANT_SET_IP_INTO_FINALLY = 0x8013130e,
        CORDBG_E_CANT_SET_IP_OUT_OF_FINALLY = 0x8013130f,
        CORDBG_E_CANT_SET_IP_INTO_CATCH = 0x80131310,
        CORDBG_E_SET_IP_NOT_ALLOWED_ON_NONLEAF_FRAME = 0x80131311,
        CORDBG_E_SET_IP_IMPOSSIBLE = 0x80131312,
        CORDBG_E_FUNC_EVAL_BAD_START_POINT = 0x80131313,
        CORDBG_E_INVALID_OBJECT = 0x80131314,
        CORDBG_E_FUNC_EVAL_NOT_COMPLETE = 0x80131315,
        CORDBG_E_STATIC_VAR_NOT_AVAILABLE = 0x8013131a,
        CORDBG_E_CANT_SETIP_INTO_OR_OUT_OF_FILTER = 0x8013131c,
        CORDBG_E_CANT_CHANGE_JIT_SETTING_FOR_ZAP_MODULE = 0x8013131d,
        CORDBG_E_CANT_SET_IP_OUT_OF_FINALLY_ON_WIN64 = 0x8013131e,
        CORDBG_E_CANT_SET_IP_OUT_OF_CATCH_ON_WIN64 = 0x8013131f,
        CORDBG_E_CANT_SET_TO_JMC = 0x80131323,
        CORDBG_E_NO_CONTEXT_FOR_INTERNAL_FRAME = 0x80131325,
        CORDBG_E_NOT_CHILD_FRAME = 0x80131326,
        CORDBG_E_NON_MATCHING_CONTEXT = 0x80131327,
        CORDBG_E_PAST_END_OF_STACK = 0x80131328,
        CORDBG_E_FUNC_EVAL_CANNOT_UPDATE_REGISTER_IN_NONLEAF_FRAME = 0x80131329,
        CORDBG_E_BAD_THREAD_STATE = 0x8013132d,
        CORDBG_E_DEBUGGER_ALREADY_ATTACHED = 0x8013132e,
        CORDBG_E_SUPERFLOUS_CONTINUE = 0x8013132f,
        CORDBG_E_SET_VALUE_NOT_ALLOWED_ON_NONLEAF_FRAME = 0x80131330,
        CORDBG_E_ENC_MODULE_NOT_ENC_ENABLED = 0x80131332,
        CORDBG_E_SET_IP_NOT_ALLOWED_ON_EXCEPTION = 0x80131333,
        CORDBG_E_VARIABLE_IS_ACTUALLY_LITERAL = 0x80131334,
        CORDBG_E_PROCESS_DETACHED = 0x80131335,
        CORDBG_E_ENC_CANT_ADD_FIELD_TO_VALUE_OR_LAYOUT_CLASS = 0x80131338,
        CORDBG_E_FIELD_NOT_STATIC = 0x8013133b,
        CORDBG_E_FIELD_NOT_INSTANCE = 0x8013133c,
        CORDBG_E_ENC_JIT_CANT_UPDATE = 0x8013133f,
        CORDBG_E_ENC_INTERNAL_ERROR = 0x80131341,
        CORDBG_E_ENC_HANGING_FIELD = 0x80131342,
        CORDBG_E_MODULE_NOT_LOADED = 0x80131343,
        CORDBG_E_UNABLE_TO_SET_BREAKPOINT = 0x80131345,
        CORDBG_E_DEBUGGING_NOT_POSSIBLE = 0x80131346,
        CORDBG_E_KERNEL_DEBUGGER_ENABLED = 0x80131347,
        CORDBG_E_KERNEL_DEBUGGER_PRESENT = 0x80131348,
        CORDBG_E_INCOMPATIBLE_PROTOCOL = 0x8013134b,
        CORDBG_E_TOO_MANY_PROCESSES = 0x8013134c,
        CORDBG_E_INTEROP_NOT_SUPPORTED = 0x8013134d,
        CORDBG_E_NO_REMAP_BREAKPIONT = 0x8013134e,
        CORDBG_E_OBJECT_NEUTERED = 0x8013134f,
        CORPROF_E_FUNCTION_NOT_COMPILED = 0x80131350,
        CORPROF_E_DATAINCOMPLETE = 0x80131351,
        CORPROF_E_FUNCTION_NOT_IL = 0x80131354,
        CORPROF_E_NOT_MANAGED_THREAD = 0x80131355,
        CORPROF_E_CALL_ONLY_FROM_INIT = 0x80131356,
        CORPROF_E_NOT_YET_AVAILABLE = 0x8013135b,
        CORPROF_E_TYPE_IS_PARAMETERIZED = 0x8013135c,
        CORPROF_E_FUNCTION_IS_PARAMETERIZED = 0x8013135d,
        CORPROF_E_STACKSNAPSHOT_INVALID_TGT_THREAD = 0x8013135e,
        CORPROF_E_STACKSNAPSHOT_UNMANAGED_CTX = 0x8013135f,
        CORPROF_E_STACKSNAPSHOT_UNSAFE = 0x80131360,
        CORPROF_E_STACKSNAPSHOT_ABORTED = 0x80131361,
        CORPROF_E_LITERALS_HAVE_NO_ADDRESS = 0x80131362,
        CORPROF_E_UNSUPPORTED_CALL_SEQUENCE = 0x80131363,
        CORPROF_E_ASYNCHRONOUS_UNSAFE = 0x80131364,
        CORPROF_E_CLASSID_IS_ARRAY = 0x80131365,
        CORPROF_E_CLASSID_IS_COMPOSITE = 0x80131366,
        CORPROF_E_PROFILER_DETACHING = 0x80131367,
        CORPROF_E_PROFILER_NOT_ATTACHABLE = 0x80131368,
        CORPROF_E_UNRECOGNIZED_PIPE_MSG_FORMAT = 0x80131369,
        CORPROF_E_PROFILER_ALREADY_ACTIVE = 0x8013136a,
        CORPROF_E_PROFILEE_INCOMPATIBLE_WITH_TRIGGER = 0x8013136b,
        CORPROF_E_IPC_FAILED = 0x8013136c,
        CORPROF_E_PROFILEE_PROCESS_NOT_FOUND = 0x8013136d,
        CORPROF_E_CALLBACK3_REQUIRED = 0x8013136e,
        CORPROF_E_UNSUPPORTED_FOR_ATTACHING_PROFILER = 0x8013136f,
        CORPROF_E_IRREVERSIBLE_INSTRUMENTATION_PRESENT = 0x80131370,
        CORPROF_E_RUNTIME_UNINITIALIZED = 0x80131371,
        CORPROF_E_IMMUTABLE_FLAGS_SET = 0x80131372,
        CORPROF_E_PROFILER_NOT_YET_INITIALIZED = 0x80131373,
        CORPROF_E_INCONSISTENT_WITH_FLAGS = 0x80131374,
        CORPROF_E_PROFILER_CANCEL_ACTIVATION = 0x80131375,
        CORPROF_E_CONCURRENT_GC_NOT_PROFILABLE = 0x80131376,
        CORPROF_E_DEBUGGING_DISABLED = 0x80131378,
        CORPROF_E_TIMEOUT_WAITING_FOR_CONCURRENT_GC = 0x80131379,
        CORPROF_E_MODULE_IS_DYNAMIC = 0x8013137a,
        CORPROF_E_CALLBACK4_REQUIRED = 0x8013137b,
        CORPROF_E_REJIT_NOT_ENABLED = 0x8013137c,
        CORPROF_E_FUNCTION_IS_COLLECTIBLE = 0x8013137e,
        CORPROF_E_CALLBACK6_REQUIRED = 0x80131380,
        CORPROF_E_CALLBACK7_REQUIRED = 0x80131382,
        CORPROF_E_REJIT_INLINING_DISABLED = 0x80131383,
        CORDIAGIPC_E_BAD_ENCODING = 0x80131384,
        CORDIAGIPC_E_UNKNOWN_COMMAND = 0x80131385,
        CORDIAGIPC_E_UNKNOWN_MAGIC = 0x80131386,
        CORDIAGIPC_E_UNKNOWN_ERROR = 0x80131387,
        CORPROF_E_SUSPENSION_IN_PROGRESS = 0x80131388,
        SECURITY_E_INCOMPATIBLE_SHARE = 0x80131401,
        SECURITY_E_UNVERIFIABLE = 0x80131402,
        SECURITY_E_INCOMPATIBLE_EVIDENCE = 0x80131403,
        CORSEC_E_POLICY_EXCEPTION = 0x80131416,
        CORSEC_E_MIN_GRANT_FAIL = 0x80131417,
        CORSEC_E_NO_EXEC_PERM = 0x80131418,
        CORSEC_E_XMLSYNTAX = 0x80131419,
        CORSEC_E_INVALID_STRONGNAME = 0x8013141a,
        CORSEC_E_MISSING_STRONGNAME = 0x8013141b,
        CORSEC_E_INVALID_IMAGE_FORMAT = 0x8013141d,
        CORSEC_E_INVALID_PUBLICKEY = 0x8013141e,
        CORSEC_E_SIGNATURE_MISMATCH = 0x80131420,
        CORSEC_E_CRYPTO = 0x80131430,
        CORSEC_E_CRYPTO_UNEX_OPER = 0x80131431,
        CORSECATTR_E_BAD_ACTION = 0x80131442,
        COR_E_EXCEPTION = 0x80131500,
        COR_E_SYSTEM = 0x80131501,
        COR_E_ARGUMENTOUTOFRANGE = 0x80131502,
        COR_E_ARRAYTYPEMISMATCH = 0x80131503,
        COR_E_CONTEXTMARSHAL = 0x80131504,
        COR_E_TIMEOUT = 0x80131505,
        COR_E_EXECUTIONENGINE = 0x80131506,
        COR_E_FIELDACCESS = 0x80131507,
        COR_E_INDEXOUTOFRANGE = 0x80131508,
        COR_E_INVALIDOPERATION = 0x80131509,
        COR_E_SECURITY = 0x8013150a,
        COR_E_SERIALIZATION = 0x8013150c,
        COR_E_VERIFICATION = 0x8013150d,
        COR_E_METHODACCESS = 0x80131510,
        COR_E_MISSINGFIELD = 0x80131511,
        COR_E_MISSINGMEMBER = 0x80131512,
        COR_E_MISSINGMETHOD = 0x80131513,
        COR_E_MULTICASTNOTSUPPORTED = 0x80131514,
        COR_E_NOTSUPPORTED = 0x80131515,
        COR_E_OVERFLOW = 0x80131516,
        COR_E_RANK = 0x80131517,
        COR_E_SYNCHRONIZATIONLOCK = 0x80131518,
        COR_E_THREADINTERRUPTED = 0x80131519,
        COR_E_MEMBERACCESS = 0x8013151a,
        COR_E_THREADSTATE = 0x80131520,
        COR_E_THREADSTOP = 0x80131521,
        COR_E_TYPELOAD = 0x80131522,
        COR_E_ENTRYPOINTNOTFOUND = 0x80131523,
        COR_E_DLLNOTFOUND = 0x80131524,
        COR_E_THREADSTART = 0x80131525,
        COR_E_INVALIDCOMOBJECT = 0x80131527,
        COR_E_NOTFINITENUMBER = 0x80131528,
        COR_E_DUPLICATEWAITOBJECT = 0x80131529,
        COR_E_SEMAPHOREFULL = 0x8013152b,
        COR_E_WAITHANDLECANNOTBEOPENED = 0x8013152c,
        COR_E_ABANDONEDMUTEX = 0x8013152d,
        COR_E_THREADABORTED = 0x80131530,
        COR_E_INVALIDOLEVARIANTTYPE = 0x80131531,
        COR_E_MISSINGMANIFESTRESOURCE = 0x80131532,
        COR_E_SAFEARRAYTYPEMISMATCH = 0x80131533,
        COR_E_TYPEINITIALIZATION = 0x80131534,
        COR_E_MARSHALDIRECTIVE = 0x80131535,
        COR_E_MISSINGSATELLITEASSEMBLY = 0x80131536,
        COR_E_FORMAT = 0x80131537,
        COR_E_SAFEARRAYRANKMISMATCH = 0x80131538,
        COR_E_PLATFORMNOTSUPPORTED = 0x80131539,
        COR_E_INVALIDPROGRAM = 0x8013153a,
        COR_E_OPERATIONCANCELED = 0x8013153b,
        COR_E_INSUFFICIENTMEMORY = 0x8013153d,
        COR_E_RUNTIMEWRAPPED = 0x8013153e,
        COR_E_DATAMISALIGNED = 0x80131541,
        COR_E_CODECONTRACTFAILED = 0x80131542,
        COR_E_TYPEACCESS = 0x80131543,
        COR_E_ACCESSING_CCW = 0x80131544,
        COR_E_KEYNOTFOUND = 0x80131577,
        COR_E_INSUFFICIENTEXECUTIONSTACK = 0x80131578,
        COR_E_APPLICATION = 0x80131600,
        COR_E_INVALIDFILTERCRITERIA = 0x80131601,
        COR_E_REFLECTIONTYPELOAD = 0x80131602,
        COR_E_TARGET = 0x80131603,
        COR_E_TARGETINVOCATION = 0x80131604,
        COR_E_CUSTOMATTRIBUTEFORMAT = 0x80131605,
        COR_E_IO = 0x80131620,
        COR_E_FILELOAD = 0x80131621,
        COR_E_OBJECTDISPOSED = 0x80131622,
        COR_E_FAILFAST = 0x80131623,
        COR_E_HOSTPROTECTION = 0x80131640,
        COR_E_ILLEGAL_REENTRANCY = 0x80131641,
        CLR_E_SHIM_RUNTIMELOAD = 0x80131700,
        CLR_E_SHIM_LEGACYRUNTIMEALREADYBOUND = 0x80131704,
        VER_E_FIELD_SIG = 0x80131815,
        VER_E_CIRCULAR_VAR_CONSTRAINTS = 0x801318ce,
        VER_E_CIRCULAR_MVAR_CONSTRAINTS = 0x801318cf,
        COR_E_Data = 0x80131920,
        VLDTR_E_SIG_BADVOID = 0x80131b24,
        VLDTR_E_GP_ILLEGAL_VARIANT_MVAR = 0x80131b2d,
        CORDBG_E_THREAD_NOT_SCHEDULED = 0x80131c00,
        CORDBG_E_HANDLE_HAS_BEEN_DISPOSED = 0x80131c01,
        CORDBG_E_NONINTERCEPTABLE_EXCEPTION = 0x80131c02,
        CORDBG_E_INTERCEPT_FRAME_ALREADY_SET = 0x80131c04,
        CORDBG_E_NO_NATIVE_PATCH_AT_ADDR = 0x80131c05,
        CORDBG_E_MUST_BE_INTEROP_DEBUGGING = 0x80131c06,
        CORDBG_E_NATIVE_PATCH_ALREADY_AT_ADDR = 0x80131c07,
        CORDBG_E_TIMEOUT = 0x80131c08,
        CORDBG_E_CANT_CALL_ON_THIS_THREAD = 0x80131c09,
        CORDBG_E_ENC_INFOLESS_METHOD = 0x80131c0a,
        CORDBG_E_ENC_IN_FUNCLET = 0x80131c0c,
        CORDBG_E_ENC_EDIT_NOT_SUPPORTED = 0x80131c0e,
        CORDBG_E_NOTREADY = 0x80131c10,
        CORDBG_E_CANNOT_RESOLVE_ASSEMBLY = 0x80131c11,
        CORDBG_E_MUST_BE_IN_LOAD_MODULE = 0x80131c12,
        CORDBG_E_CANNOT_BE_ON_ATTACH = 0x80131c13,
        CORDBG_E_NGEN_NOT_SUPPORTED = 0x80131c14,
        CORDBG_E_ILLEGAL_SHUTDOWN_ORDER = 0x80131c15,
        CORDBG_E_CANNOT_DEBUG_FIBER_PROCESS = 0x80131c16,
        CORDBG_E_MUST_BE_IN_CREATE_PROCESS = 0x80131c17,
        CORDBG_E_DETACH_FAILED_OUTSTANDING_EVALS = 0x80131c18,
        CORDBG_E_DETACH_FAILED_OUTSTANDING_STEPPERS = 0x80131c19,
        CORDBG_E_CANT_INTEROP_STEP_OUT = 0x80131c20,
        CORDBG_E_DETACH_FAILED_OUTSTANDING_BREAKPOINTS = 0x80131c21,
        CORDBG_E_ILLEGAL_IN_STACK_OVERFLOW = 0x80131c22,
        CORDBG_E_ILLEGAL_AT_GC_UNSAFE_POINT = 0x80131c23,
        CORDBG_E_ILLEGAL_IN_PROLOG = 0x80131c24,
        CORDBG_E_ILLEGAL_IN_NATIVE_CODE = 0x80131c25,
        CORDBG_E_ILLEGAL_IN_OPTIMIZED_CODE = 0x80131c26,
        CORDBG_E_APPDOMAIN_MISMATCH = 0x80131c28,
        CORDBG_E_CONTEXT_UNVAILABLE = 0x80131c29,
        CORDBG_E_UNCOMPATIBLE_PLATFORMS = 0x80131c30,
        CORDBG_E_DEBUGGING_DISABLED = 0x80131c31,
        CORDBG_E_DETACH_FAILED_ON_ENC = 0x80131c32,
        CORDBG_E_CURRENT_EXCEPTION_IS_OUTSIDE_CURRENT_EXECUTION_SCOPE = 0x80131c33,
        CORDBG_E_HELPER_MAY_DEADLOCK = 0x80131c34,
        CORDBG_E_MISSING_METADATA = 0x80131c35,
        CORDBG_E_TARGET_INCONSISTENT = 0x80131c36,
        CORDBG_E_DETACH_FAILED_OUTSTANDING_TARGET_RESOURCES = 0x80131c37,
        CORDBG_E_TARGET_READONLY = 0x80131c38,
        CORDBG_E_MISMATCHED_CORWKS_AND_DACWKS_DLLS = 0x80131c39,
        CORDBG_E_MODULE_LOADED_FROM_DISK = 0x80131c3a,
        CORDBG_E_SYMBOLS_NOT_AVAILABLE = 0x80131c3b,
        CORDBG_E_DEBUG_COMPONENT_MISSING = 0x80131c3c,
        CORDBG_E_LIBRARY_PROVIDER_ERROR = 0x80131c43,
        CORDBG_E_NOT_CLR = 0x80131c44,
        CORDBG_E_MISSING_DATA_TARGET_INTERFACE = 0x80131c45,
        CORDBG_E_UNSUPPORTED_DEBUGGING_MODEL = 0x80131c46,
        CORDBG_E_UNSUPPORTED_FORWARD_COMPAT = 0x80131c47,
        CORDBG_E_UNSUPPORTED_VERSION_STRUCT = 0x80131c48,
        CORDBG_E_READVIRTUAL_FAILURE = 0x80131c49,
        CORDBG_E_VALUE_POINTS_TO_FUNCTION = 0x80131c4a,
        CORDBG_E_CORRUPT_OBJECT = 0x80131c4b,
        CORDBG_E_GC_STRUCTURES_INVALID = 0x80131c4c,
        CORDBG_E_INVALID_OPCODE = 0x80131c4d,
        CORDBG_E_UNSUPPORTED = 0x80131c4e,
        CORDBG_E_MISSING_DEBUGGER_EXPORTS = 0x80131c4f,
        CORDBG_E_DATA_TARGET_ERROR = 0x80131c61,
        CORDBG_E_NO_IMAGE_AVAILABLE = 0x80131c64,
        CORDBG_E_UNSUPPORTED_DELEGATE = 0x80131c68,
        CORDBG_E_ASSEMBLY_UPDATES_APPLIED = 0x80131c69,
        PEFMT_E_64BIT = 0x80131d02,
        PEFMT_E_32BIT = 0x80131d0b,
        CLDB_E_INTERNALERROR = 0x80131fff,
        CLR_E_BIND_ASSEMBLY_VERSION_TOO_LOW = 0x80132000,
        CLR_E_BIND_ASSEMBLY_PUBLIC_KEY_MISMATCH = 0x80132001,
        CLR_E_BIND_IMAGE_UNAVAILABLE = 0x80132002,
        CLR_E_BIND_UNRECOGNIZED_IDENTITY_FORMAT = 0x80132003,
        CLR_E_BIND_ASSEMBLY_NOT_FOUND = 0x80132004,
        CLR_E_BIND_TYPE_NOT_FOUND = 0x80132005,
        CLR_E_BIND_SYS_ASM_NI_MISSING = 0x80132006,
        CLR_E_BIND_NI_SECURITY_FAILURE = 0x80132007,
        CLR_E_BIND_NI_DEP_IDENTITY_MISMATCH = 0x80132008,
        CLR_E_GC_OOM = 0x80132009,
        CLR_E_GC_BAD_AFFINITY_CONFIG = 0x8013200a,
        CLR_E_GC_BAD_AFFINITY_CONFIG_FORMAT = 0x8013200b,
        CLR_E_CROSSGEN_NO_IBC_DATA_FOUND = 0x8013200c,
        CLR_E_GC_BAD_HARD_LIMIT = 0x8013200d,
        CLR_E_GC_LARGE_PAGE_MISSING_HARD_LIMIT = 0x8013200e,
        COR_E_UNAUTHORIZEDACCESS = 0x80070005,
        COR_E_NULLREFERENCE = 0x80004003,
        COR_E_ARITHMETIC = 0x80070216,
        COR_E_PATHTOOLONG = 0x800700ce,
        COR_E_FILENOTFOUND = 0x80070002,
        COR_E_ENDOFSTREAM = 0x80070026,
        COR_E_DIRECTORYNOTFOUND = 0x80070003,
        COR_E_STACKOVERFLOW = 0x800703e9,
        COR_E_AMBIGUOUSMATCH = 0x8000211D,
        COR_E_TARGETPARAMCOUNT = 0x8002000E,
        COR_E_DIVIDEBYZERO = 0x80020012,
        TYPE_E_ELEMENTNOTFOUND = 0x8002802B,
        COR_E_BADIMAGEFORMAT = 0x8007000B,

        ERROR_INSUFFICIENT_BUFFER = 0x8007007a,
        ERROR_PARTIAL_COPY = 0x8007012b,
        ERROR_SERVER_DISABLED = 0x8007053d,

        E_PDB_OK = 0x806d001,
        E_PDB_USAGE = 0x806d002,
        E_PDB_OUT_OF_MEMORY = 0x806d0003,
        E_PDB_FILE_SYSTEM = 0x806d0004,
        E_PDB_NOT_FOUND = 0x806d0005,
        E_PDB_INVALID_SIG = 0x806d0006,
        E_PDB_INVALID_AGE = 0x806d0007,
        E_PDB_PRECOMP_REQUIRED = 0x806d0008,
        E_PDB_OUT_OF_TI = 0x806d009,
        E_PDB_NOT_IMPLEMENTED = 0x806d000a,
        E_PDB_V1_PDB = 0x806d000b,
        E_PDB_FORMAT = 0x806d000c,
        E_PDB_LIMIT = 0x806d000d,
        E_PDB_CORRUPT = 0x806d000e,
        E_PDB_TI16 = 0x806d000f,
        E_PDB_ACCESS_DENIED = 0x806d0010,
        E_PDB_ILLEGAL_TYPE_EDIT = 0x806d0011,
        E_PDB_INVALID_EXECUTABLE = 0x806d0012,
        E_PDB_DBG_NOT_FOUND = 0x806d0013,
        E_PDB_NO_DEBUG_INFO = 0x806d0014,
        E_PDB_INVALID_EXE_TIMESTAMP = 0x806d0015,
        E_PDB_RESERVED = 0x806d0016,
        E_PDB_DEBUG_INFO_NOT_IN_PDB = 0x806d0017,
        E_PDB_SYMSRV_BAD_CACHE_PATH = 0x806d0018,
        E_PDB_SYMSRV_CACHE_FULL = 0x806d0019,
        E_PDB_OBJECT_DISPOSED = 0x806d001a,
        E_PDB_MAX = 0x806d001b
    }
}
