﻿namespace ClrDebug.DbgEng
{
    public enum DEBUG_REQUEST : uint
    {
        /// <summary>
        /// Check the source path for a source server.<para/>
        /// InBuffer - Unused.
        /// OutBuffer - Unused.
        /// </summary>
        SOURCE_PATH_HAS_SOURCE_SERVER = 0,

        /// <summary>
        /// Return the thread context for the stored event in a user-mode minidump file.<para/>
        /// InBuffer - Unused.
        /// OutBuffer - Machine-specific CONTEXT.
        /// </summary>
        TARGET_EXCEPTION_CONTEXT = 1,

        /// <summary>
        /// Return the operating system thread ID for the stored event in a user-mode minidump file.<para/>
        /// InBuffer - Unused.
        /// OutBuffer - ULONG system ID of thread.
        /// </summary>
        TARGET_EXCEPTION_THREAD = 2,

        /// <summary>
        /// Return the exception record for the stored event in a user-mode minidump file.<para/>
        /// InBuffer - Unused.
        /// OutBuffer - <see cref="EXCEPTION_RECORD64"/>.
        /// </summary>
        TARGET_EXCEPTION_RECORD = 3,

        /// <summary>
        /// Return the default process creation options.<para/>
        /// InBuffer - Unused.
        /// OutBuffer - <see cref="DEBUG_CREATE_PROCESS_OPTIONS"/>.
        /// </summary>
        GET_ADDITIONAL_CREATE_OPTIONS = 4,

        /// <summary>
        /// Set the default process creation options.<para/>
        /// InBuffer - <see cref="DEBUG_CREATE_PROCESS_OPTIONS"/>.
        /// OutBuffer - Unused.
        /// </summary>
        SET_ADDITIONAL_CREATE_OPTIONS = 5,

        /// <summary>
        /// Return the version of Windows that is currently running on the target.<para/>
        /// InBuffer - Unused.
        /// OutBuffer - ULONG[2] major/minor.
        /// </summary>
        GET_WIN32_MAJOR_MINOR_VERSIONS = 6,

        /// <summary>
        /// Read a stream from a user-mode minidump target.<para/>
        /// InBuffer - <see cref="DEBUG_READ_USER_MINIDUMP_STREAM"/>.
        /// OutBuffer - Unused.
        /// </summary>
        READ_USER_MINIDUMP_STREAM = 7,

        /// <summary>
        /// Check to see if it is possible for the debugger engine to detach from the current process (leaving the process running but no longer being debugged).<para/>
        /// InBuffer - Unused.
        /// OutBuffer - Unused.
        /// </summary>
        TARGET_CAN_DETACH = 8,

        /// <summary>
        /// Set the debugger engine's implicit command line.<para/>
        /// InBuffer - PTSTR.
        /// OutBuffer - Unused.
        /// </summary>
        SET_LOCAL_IMPLICIT_COMMAND_LINE = 9,

        /// <summary>
        /// Return the current event's instruction pointer.<para/>
        /// InBuffer - Unused.
        /// OutBuffer - Event code stream offset.
        /// </summary>
        GET_CAPTURED_EVENT_CODE_OFFSET = 10,

        /// <summary>
        /// Return up to 64 bytes of memory at the current event's instruction pointer.<para/>
        /// InBuffer - Unused.
        /// OutBuffer - Event code stream information.
        /// </summary>
        READ_CAPTURED_EVENT_CODE_STREAM = 11,

        /// <summary>
        /// Perform a variety of different operations that aid in the interpretation of typed data.<para/>
        /// InBuffer - Input data block.
        /// OutBuffer - Processed data block.
        /// </summary>
        EXT_TYPED_DATA_ANSI = 12,

        /// <summary>
        /// InBuffer - Unused.
        /// OutBuffer - Returned path.
        /// </summary>
        GET_EXTENSION_SEARCH_PATH_WIDE = 13,

        /// <summary>
        /// InBuffer - <see cref="DEBUG_GET_TEXT_COMPLETIONS_IN"/>.
        /// OutBuffer - <see cref="DEBUG_GET_TEXT_COMPLETIONS_OUT"/>.
        /// </summary>
        GET_TEXT_COMPLETIONS_WIDE = 14,

        /// <summary>
        /// InBuffer - ULONG64 cookie.
        /// OutBuffer - <see cref="DEBUG_CACHED_SYMBOL_INFO"/>.
        /// </summary>
        GET_CACHED_SYMBOL_INFO = 15,

        /// <summary>
        /// InBuffer - <see cref="DEBUG_CACHED_SYMBOL_INFO"/>.
        /// OutBuffer - ULONG64 cookie.
        /// </summary>
        ADD_CACHED_SYMBOL_INFO = 16,

        /// <summary>
        /// InBuffer - ULONG64 cookie.
        /// OutBuffer - Unused.
        /// </summary>
        REMOVE_CACHED_SYMBOL_INFO = 17,

        /// <summary>
        /// InBuffer - <see cref="DEBUG_GET_TEXT_COMPLETIONS_IN"/>.
        /// OutBuffer - <see cref="DEBUG_GET_TEXT_COMPLETIONS_OUT"/>.
        /// </summary>
        GET_TEXT_COMPLETIONS_ANSI = 18,

        /// <summary>
        /// InBuffer - Unused.
        /// OutBuffer - Unused.
        /// </summary>
        CURRENT_OUTPUT_CALLBACKS_ARE_DML_AWARE = 19,

        /// <summary>
        /// InBuffer - ULONG64 offset.
        /// OutBuffer - Unwind information.
        /// </summary>
        GET_OFFSET_UNWIND_INFORMATION = 20,

        /// <summary>
        /// Get the headers of a kernel dump or minidump.
        /// InBuffer - Unused
        /// OutBuffer - returned <see cref="DUMP_HEADER32"/>/<see cref="DUMP_HEADER64"/> structure.
        /// </summary>
        GET_DUMP_HEADER = 21,

        /// <summary>
        /// InBuffer - <see cref="DUMP_HEADER32"/>/<see cref="DUMP_HEADER64"/> structure.
        /// OutBuffer - Unused
        /// </summary>
        SET_DUMP_HEADER = 22,

        /// <summary>
        /// InBuffer - Midori specific
        /// OutBuffer - Midori specific
        /// </summary>
        MIDORI = 23,

        /// <summary>
        /// InBuffer - Unused
        /// OutBuffer - PROCESS_NAME_ENTRY blocks
        /// </summary>
        PROCESS_DESCRIPTORS = 24,

        /// <summary>
        /// InBuffer - Unused
        /// OutBuffer - MINIDUMP_MISC_INFO_N blocks
        /// </summary>
        MISC_INFORMATION = 25,

        /// <summary>
        /// InBuffer - Unused
        /// OutBuffer - ULONG64 as TokenHandle value
        /// </summary>
        OPEN_PROCESS_TOKEN = 26,

        /// <summary>
        /// InBuffer - Unused
        /// OutBuffer - ULONG64 as TokenHandle value
        /// </summary>
        OPEN_THREAD_TOKEN = 27,

        /// <summary>
        /// InBuffer -  ULONG64 as TokenHandle being duplicated
        /// OutBuffer - ULONG64 as new duplicated TokenHandle
        /// </summary>
        DUPLICATE_TOKEN = 28,

        /// <summary>
        /// InBuffer - a ULONG64 as TokenHandle and a ULONG as NtQueryInformationToken() request code
        /// OutBuffer - NtQueryInformationToken() return
        /// </summary>
        QUERY_INFO_TOKEN = 29,

        /// <summary>
        /// InBuffer - ULONG64 as TokenHandle
        /// OutBuffer - Unused
        /// </summary>
        CLOSE_TOKEN = 30,

        /// <summary>
        /// InBuffer - ULONG64 for process server identification and ULONG as PID
        /// OutBuffer - Unused
        /// </summary>
        WOW_PROCESS = 31,

        /// <summary>
        /// InBuffer - ULONG64 for process server identification and PWSTR as module path
        /// OutBuffer - Unused
        /// </summary>
        WOW_MODULE = 32,

        /// <summary>
        /// InBuffer - Unused
        /// OutBuffer - Unused
        /// return - S_OK if non-invasive user-mode attach, S_FALSE if not (but still live user-mode), E_FAIL otherwise.
        /// </summary>
        LIVE_USER_NON_INVASIVE = 33,

        /// <summary>
        /// InBuffer - TID
        /// OutBuffer - Unused
        /// return - ResumeThreads() return.
        /// </summary>
        RESUME_THREAD = 34,

        INLINE_QUERY = 35,
        TL_INSTRUMENTATION_AWARE = 36,
        GET_INSTRUMENTATION_VERSION = 37,
        GET_MODULE_ARCHITECTURE = 38,
        GET_IMAGE_ARCHITECTURE = 39,
        SET_PARENT_HWND = 40,

        ENGPRIV_REQUEST_ENGINE_SOURCE_OPTION_NOTIFICATIONS = 0xFF000000,
        ENGPRIV_REQUEST_GET_ENGINE_SOURCE_OPTIONS = 0xFF000001,
        ENGPRIV_REQUEST_SET_ENGINE_SOURCE_OPTIONS = 0xFF000002,
        ENGPRIV_REQUEST_SET_ENGINE_DEBUG_SESSION_ACTIVITY = 0xFF000003,
        ENGPRIV_REQUEST_ADD_DEFAULT_ENGINE_OPTIONS = 0xFF000004,
        ENGPRIV_REQUEST_CLEAR_DEFAULT_ENGINE_OPTIONS = 0xFF000005
    }
}
