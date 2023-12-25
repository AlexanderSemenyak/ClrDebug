﻿using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6b86fe2c-2c4f-4f0c-9da2-174311acc327")]
    [ComImport]
    public interface IDebugSystemObjects
    {
        /// <summary>
        /// The GetEventThread method returns the engine thread ID for the thread on which the last event occurred.
        /// </summary>
        /// <param name="Id">[out] Receives the engine thread ID.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In kernel-mode debugging, the engine thread ID for the virtual thread representing the processor on which the event
        /// occurred is returned. For more information about threads, see Threads and Processes. For details about debugger
        /// engine events, see Monitoring Events.
        /// </remarks>
        [PreserveSig]
        HRESULT GetEventThread(
            [Out] out int Id);

        /// <summary>
        /// The GetEventProcess method returns the engine process ID for the process on which the last event occurred.
        /// </summary>
        /// <param name="Id">[out] Receives the engine process ID.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In kernel-mode debugging, the engine process ID for the virtual process representing the kernel is returned. For
        /// more information about processes, see Threads and Processes. For details about debugger engine events, see Monitoring
        /// Events.
        /// </remarks>
        [PreserveSig]
        HRESULT GetEventProcess(
            [Out] out int Id);

        /// <summary>
        /// The GetCurrentThreadId method returns the engine thread ID for the current thread.
        /// </summary>
        /// <param name="Id">[out] Receives the engine thread ID.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about threads, see Threads and Processes.
        /// </remarks>
        [PreserveSig]
        HRESULT GetCurrentThreadId(
            [Out] out int Id);

        /// <summary>
        /// The SetCurrentThreadId method makes the specified thread the current thread.
        /// </summary>
        /// <param name="Id">[in] Specifies the engine thread ID of the thread that is to become the current thread.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method may also change the current process, current target, and current computer. If the thread is changed,
        /// the callback <see cref="IDebugEventCallbacks.ChangeEngineState"/> will be called with the DEBUG_CES_CURRENT_THREAD
        /// bit set.
        /// </remarks>
        [PreserveSig]
        HRESULT SetCurrentThreadId(
            [In] int Id);

        /// <summary>
        /// The GetCurrentProcessId method returns the engine process ID for the current process.
        /// </summary>
        /// <param name="Id">[out] Receives the engine process ID for the current process.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about processes, see Threads and Processes.
        /// </remarks>
        [PreserveSig]
        HRESULT GetCurrentProcessId(
            [Out] out int Id);

        /// <summary>
        /// The SetCurrentProcessId method makes the specified process the current process.
        /// </summary>
        /// <param name="Id">[in] Specifies the engine process ID for the process that is to become the current process.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method also changes the current thread, and may change the current target and current computer. If the process
        /// is changed, the callback <see cref="IDebugEventCallbacks.ChangeEngineState"/> will be called with the DEBUG_CES_CURRENT_THREAD
        /// bit set.
        /// </remarks>
        [PreserveSig]
        HRESULT SetCurrentProcessId(
            [In] int Id);

        /// <summary>
        /// The GetNumberThreads method returns the number of threads in the current process.
        /// </summary>
        /// <param name="Number">[out] Receives the number of threads in the current process.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In kernel-mode debugging, there is a virtual thread representing each processor. In user-mode debugging, the number
        /// of threads changes with the <see cref="IDebugEventCallbacks.CreateThread"/> and <see cref="IDebugEventCallbacks.ExitThread"/>
        /// events. For more information about threads, see Threads and Processes.
        /// </remarks>
        [PreserveSig]
        HRESULT GetNumberThreads(
            [Out] out int Number);

        /// <summary>
        /// The GetTotalNumberThreads method returns the total number of threads for all the processes in the current target, in addition to the largest number of threads in any process for the current target.
        /// </summary>
        /// <param name="Total">[out] Receives the total number of threads for all the processes in the current target.</param>
        /// <param name="LargestProcess">[out] Receives the largest number of threads in any process for the current target.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about threads, see Threads and Processes.
        /// </remarks>
        [PreserveSig]
        HRESULT GetTotalNumberThreads(
            [Out] out int Total,
            [Out] out int LargestProcess);

        /// <summary>
        /// The GetThreadIdsByIndex method returns the engine and system thread IDs for the specified threads in the current process.
        /// </summary>
        /// <param name="Start">[in] Specifies the index of the first thread whose IDs are requested.</param>
        /// <param name="Count">[in] Specifies the number of threads whose IDs are requested.</param>
        /// <param name="Ids">[out, optional] Receives the engine thread IDs. If Ids is NULL, this information is not returned; otherwise, Ids is treated as an array of Count ULONG valuess.</param>
        /// <param name="SysIds">[out, optional] Receives the system thread IDs. If SysIds is NULL, this information is not returned; otherwise, SysIds is treated as an array of Count ULONG values.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The index of the first thread is zero. The index of the last thread is the number of threads returned by <see cref="GetNumberThreads"/>
        /// minus one. For more information about threads, see Threads and Processes.
        /// </remarks>
        [PreserveSig]
        HRESULT GetThreadIdsByIndex(
            [In] int Start,
            [In] int Count,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] Ids,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] SysIds);

        /// <summary>
        /// The GetThreadIdByProcessor method returns the engine thread ID for the kernel-mode virtual thread corresponding to the specified processor.
        /// </summary>
        /// <param name="Processor">[in] Specifies the processor corresponding to the desired thread.</param>
        /// <param name="Id">[out] Receives the engine thread ID.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in kernel-mode debugging. For more information about threads, see Threads and Processes.
        /// </remarks>
        [PreserveSig]
        HRESULT GetThreadIdByProcessor(
            [In] int Processor,
            [Out] out int Id);

        /// <summary>
        /// The GetCurrentThreadDataOffset method returns the location of the system data structure for the current thread.
        /// </summary>
        /// <param name="Offset">[out] Receives the location of the system data structure for the current thread.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In user-mode debugging, the location returned is of the thread environment block (TEB) for the current thread.
        /// This is the same location returned by <see cref="GetCurrentThreadTeb"/>. In kernel-mode debugging, the location
        /// returned is of the KTHREAD structure of the system thread that was executing on the processor represented by the
        /// current thread when the last event occurred.
        /// </remarks>
        [PreserveSig]
        HRESULT GetCurrentThreadDataOffset(
            [Out] out long Offset);

        /// <summary>
        /// The GetThreadIdByDataOffset method returns the engine thread ID for the specified thread. The thread is specified by its system data structure.
        /// </summary>
        /// <param name="Offset">[in] Specifies the location of the system data structure for the thread.</param>
        /// <param name="Id">[out] Receives the engine thread ID.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In kernel-mode debugging, this method returns the engine thread ID for the virtual thread representing the processor
        /// on which the specified thread is executing. If the thread is not executing on a processor, this method will fail.
        /// For more information about threads, see Threads and Processes.
        /// </remarks>
        [PreserveSig]
        HRESULT GetThreadIdByDataOffset(
            [In] long Offset,
            [Out] out int Id);

        /// <summary>
        /// The GetCurrentThreadTeb method returns the location of the thread environment block (TEB) for the current thread.
        /// </summary>
        /// <param name="Offset">[out] Receives the location in the target's virtual address space of the TEB for the current thread.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In user-mode debugging, this method provides the same information as <see cref="GetCurrentThreadDataOffset"/>.
        /// In kernel-mode debugging, the location returned is of the TEB structure of the system thread that was executing
        /// on the processor represented by the current thread when the last event occurred.
        /// </remarks>
        [PreserveSig]
        HRESULT GetCurrentThreadTeb(
            [Out] out long Offset);

        /// <summary>
        /// The GetThreadIdByTeb method returns the engine thread ID of the specified thread. The thread is specified by its thread environment block (TEB).
        /// </summary>
        /// <param name="Offset">[in] Specifies the location of the thread's TEB.</param>
        /// <param name="Id">[out] Receives the engine thread ID.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In kernel-mode debugging, this method returns the engine thread ID for the virtual thread representing the processor
        /// on which the specified thread is executing. If the thread is not executing on a processor, this method will fail.
        /// For more information about threads, see Threads and Processes.
        /// </remarks>
        [PreserveSig]
        HRESULT GetThreadIdByTeb(
            [In] long Offset,
            [Out] out int Id);

        /// <summary>
        /// The GetCurrentThreadSystemId method returns the system thread ID of the current thread.
        /// </summary>
        /// <param name="SysId">[out] Receives the system thread ID.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in user-mode debugging. For more information about threads, see Threads and Processes.
        /// </remarks>
        [PreserveSig]
        HRESULT GetCurrentThreadSystemId(
            [Out] out int SysId);

        /// <summary>
        /// The GetThreadIdBySystemId method returns the engine thread ID for the specified thread. The thread is specified by its system thread ID.
        /// </summary>
        /// <param name="SysId">[in] Specifies the system thread ID.</param>
        /// <param name="Id">[out] Receives the engine thread ID.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in user-mode debugging. For more information about threads, see Threads and Processes.
        /// </remarks>
        [PreserveSig]
        HRESULT GetThreadIdBySystemId(
            [In] int SysId,
            [Out] out int Id);

        /// <summary>
        /// The GetCurrentThreadHandle method returns the system handle for the current thread.
        /// </summary>
        /// <param name="Handle">[out] Receives the current thread's system handle.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In kernel-mode debugging, an artificial handle is created because the threads are virtual threads. For more information
        /// about threads, see Threads and Processes. For details on system handles, see Handles.
        /// </remarks>
        [PreserveSig]
        HRESULT GetCurrentThreadHandle(
            [Out] out long Handle);

        /// <summary>
        /// The GetThreadIdByHandle method returns the engine thread ID for the specified thread. The thread is specified by its system handle.
        /// </summary>
        /// <param name="Handle">[in] Specifies the system handle of the thread whose thread ID is requested.</param>
        /// <param name="Id">[out] Receives the engine thread ID.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In kernel-mode debugging, because the handle is an artificial handle for a processor, this method returns the engine
        /// thread ID for the virtual thread representing that processor. For more information about threads, see Threads and
        /// Processes. For details on system handles, see Handles.
        /// </remarks>
        [PreserveSig]
        HRESULT GetThreadIdByHandle(
            [In] long Handle,
            [Out] out int Id);

        /// <summary>
        /// The GetNumberProcesses method returns the number of processes for the current target.
        /// </summary>
        /// <param name="Number">[out] Receives the number of processes.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In kernel-mode debugging, there is only a single virtual process representing the kernel. In user-mode debugging,
        /// the number of processes changes with the create-process and exit-process debugging events. For more information
        /// about processes, see Threads and Processes.
        /// </remarks>
        [PreserveSig]
        HRESULT GetNumberProcesses(
            [Out] out int Number);

        /// <summary>
        /// The GetProcessIdsByIndex method returns the engine process ID and system process ID for the specified processes in the current target.
        /// </summary>
        /// <param name="Start">[in] Specifies the index of the first process whose ID is requested.</param>
        /// <param name="Count">[in] Specifies the number of processes whose IDs are requested.</param>
        /// <param name="Ids">[out, optional] Receives the engine process IDs. If Ids is NULL, this information is not returned; otherwise, Ids is treated as an array of Count ULONG values.</param>
        /// <param name="SysIds">[out, optional] Receives the system process IDs. If SysIds is NULL, this information is not returned; otherwise, SysIds is treated as an array of Count ULONG values.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// The index of the first process is zero. The index of the last process is the number of processes returned by <see
        /// cref="GetNumberProcesses"/> minus one. For more information about processes, see Threads and Processes.
        /// </remarks>
        [PreserveSig]
        HRESULT GetProcessIdsByIndex(
            [In] int Start,
            [In] int Count,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] Ids,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] SysIds);

        /// <summary>
        /// The GetCurrentProcessDataOffset method returns the location of the system data structure describing the current process.
        /// </summary>
        /// <param name="Offset">[out] Receives the location in the target's virtual address space of the system data structure describing the current process.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In user-mode debugging, the location returned is of the process environment block (PEB) for the current process.
        /// This is the same location returned by <see cref="GetCurrentProcessPeb"/>. In kernel-mode debugging, the location
        /// returned is of the KPROCESS structure for the system process in which the last event occurred.
        /// </remarks>
        [PreserveSig]
        HRESULT GetCurrentProcessDataOffset(
            [Out] out long Offset);

        /// <summary>
        /// The GetProcessIdByDataOffset method returns the engine process ID for the specified process. The process is specified by its data offset.
        /// </summary>
        /// <param name="Offset">[in] Specifies the location in the target's virtual address space of the data offset of the process.</param>
        /// <param name="Id">[out] Receives the engine process ID for the process.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is currently not available in kernel-mode debugging. In user-mode debugging, this method behaves the
        /// same as <see cref="GetProcessIdByPeb"/>. For more information about processes, see Threads and Processes.
        /// </remarks>
        [PreserveSig]
        HRESULT GetProcessIdByDataOffset(
            [In] long Offset,
            [Out] out int Id);

        /// <summary>
        /// The GetCurrentProcessPeb method returns the process environment block (PEB) of the current process.
        /// </summary>
        /// <param name="Offset">[out] Receives the location in the target's virtual address space of the PEB of the current process.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In user-mode debugging, this method provides the same information as <see cref="GetCurrentProcessDataOffset"/>.
        /// In kernel-mode debugging, the location returned is that of the PEB structure for the system process in which the
        /// last event occurred.
        /// </remarks>
        [PreserveSig]
        HRESULT GetCurrentProcessPeb(
            [Out] out long Offset);

        /// <summary>
        /// The GetProcessIdByPeb method returns the engine process ID for the specified process. The process is specified by its process environment block (PEB).
        /// </summary>
        /// <param name="Offset">[in] Specifies the location in the target's virtual address space of the PEB of the process whose process ID is requested.</param>
        /// <param name="Id">[out] Receives the engine process ID.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is not available in kernel-mode debugging. For more information about processes, see Threads and Processes.
        /// </remarks>
        [PreserveSig]
        HRESULT GetProcessIdByPeb(
            [In] long Offset,
            [Out] out int Id);

        /// <summary>
        /// The GetCurrentProcessSystemId method returns the system process ID of the current process.
        /// </summary>
        /// <param name="SysId">[out] Receives the system process ID.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in user-mode debugging. For more information about processes, see Threads and Processes.
        /// </remarks>
        [PreserveSig]
        HRESULT GetCurrentProcessSystemId(
            [Out] out int SysId);

        /// <summary>
        /// The GetProcessIdBySystemId method returns the engine process ID for a process specified by its system process ID.
        /// </summary>
        /// <param name="SysId">[in] Specifies the system process ID.</param>
        /// <param name="Id">[out] Receives the engine process ID.</param>
        /// <returns>This method may also return other error values. See Return Values for more details.</returns>
        /// <remarks>
        /// This method is only available in user-mode debugging. For more information about processes, see Threads and Processes.
        /// </remarks>
        [PreserveSig]
        HRESULT GetProcessIdBySystemId(
            [In] int SysId,
            [Out] out int Id);

        /// <summary>
        /// The GetCurrentProcessHandle method returns the system handle for the current process.
        /// </summary>
        /// <param name="Handle">[out] Receives the system handle of the current process.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// In kernel-mode debugging, the only process in the target is the virtual process created for the kernel. In this
        /// case, an artificial handle is created. The artificial handle can only be used with the debugger engine API. For
        /// more information about processes, see Threads and Processes. For details on system handles, see Handles.
        /// </remarks>
        [PreserveSig]
        HRESULT GetCurrentProcessHandle(
            [Out] out long Handle);

        /// <summary>
        /// The GetProcessIdByHandle method returns the engine process ID for the specified process. The process is specified by its system handle.
        /// </summary>
        /// <param name="Handle">[in] Specifies the handle of the process whose process ID is requested. This handle must be a process handle previously retrieved from the debugger engine.</param>
        /// <param name="Id">[out] Receives the engine process ID.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// For more information about processes, see Threads and Processes. For details on system handles, see Handles.
        /// </remarks>
        [PreserveSig]
        HRESULT GetProcessIdByHandle(
            [In] long Handle,
            [Out] out int Id);

        /// <summary>
        /// The GetCurrentProcessExecutableName method returns the name of executable file loaded in the current process.
        /// </summary>
        /// <param name="Buffer">[out, optional] Receives the name of the executable file. If Buffer is NULL, this information is not returned.</param>
        /// <param name="BufferSize">[in] Specifies the size in characters of the buffer Buffer. This size includes the space for the '\0' terminating character.</param>
        /// <param name="ExeSize">[out, optional] Receives the size in characters of the name of the executable file. This size includes the space for the '\0' terminating character.<para/>
        /// If ExeSize is NULL, this information is not returned.</param>
        /// <returns>This method may also return error values. See Return Values for more details.</returns>
        /// <remarks>
        /// These methods are only available in user-mode debugging. If the engine cannot determine the name of the executable
        /// file, it writes the string "?NoImage?" to the buffer. For more information about processes, see Threads and Processes.
        /// </remarks>
        [PreserveSig]
        HRESULT GetCurrentProcessExecutableName(
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] char[] Buffer,
            [In] int BufferSize,
            [Out] out int ExeSize);
    }
}
