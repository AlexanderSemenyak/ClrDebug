using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods that return information about a specific common language runtime (CLR), including version, directory, and load status.<para/>
    /// This interface also provides runtime-specific functionality without initializing the runtime. It includes the runtime-relative <see cref="LoadLibrary"/> method, the runtime module-specific <see cref="GetProcAddress"/> method, and runtime-provided interfaces through the <see cref="GetInterface"/> method.
    /// </summary>
    public class CLRRuntimeInfo : ComObject<ICLRRuntimeInfo>
    {
        public CLRRuntimeInfo(ICLRRuntimeInfo raw) : base(raw)
        {
        }

        #region ICLRRuntimeInfo
        #region GetVersionString

        /// <summary>
        /// Gets common language runtime (CLR) version information associated with a given <see cref="ICLRRuntimeInfo"/> interface.<para/>
        /// This method supersedes the following functions:
        /// </summary>
        public string VersionString
        {
            get
            {
                HRESULT hr;
                string pwzBufferResult;

                if ((hr = TryGetVersionString(out pwzBufferResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pwzBufferResult;
            }
        }

        /// <summary>
        /// Gets common language runtime (CLR) version information associated with a given <see cref="ICLRRuntimeInfo"/> interface.<para/>
        /// This method supersedes the following functions:
        /// </summary>
        /// <param name="pwzBufferResult">[out] The .NET Framework compilation version in the format "vA.B[.X]". A, B, and X are decimal numbers that correspond to the major version, the minor version, and the build number.<para/>
        /// X is optional. If X is not present, there is no trailing period. Example values are "v1.0.3705", "v1.1.4322", "v2.0.50727", and "v4.0.x", where x depends on the build number installed.<para/>
        /// Note that the "v" prefix is mandatory.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT   | Description                        |
        /// | --------- | ---------------------------------- |
        /// | S_OK      | The method completed successfully. |
        /// | E_POINTER | pwzBuffer or pchBuffer is null.    |
        /// </returns>
        public HRESULT TryGetVersionString(out string pwzBufferResult)
        {
            /*HRESULT GetVersionString([MarshalAs(UnmanagedType.LPWStr), Out]
            StringBuilder pwzBuffer, [In] [Out] ref uint pcchBuffer);*/
            StringBuilder pwzBuffer = null;
            uint pcchBuffer = default(uint);
            HRESULT hr = Raw.GetVersionString(pwzBuffer, ref pcchBuffer);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            pwzBuffer = new StringBuilder((int) pcchBuffer);
            hr = Raw.GetVersionString(pwzBuffer, ref pcchBuffer);

            if (hr == HRESULT.S_OK)
            {
                pwzBufferResult = pwzBuffer.ToString();

                return hr;
            }

            fail:
            pwzBufferResult = default(string);

            return hr;
        }

        #endregion
        #region GetRuntimeDirectory

        /// <summary>
        /// Gets the installation directory of the common language runtime (CLR) associated with this interface. This method supersedes the GetCORSystemDirectory function provided in the .NET Framework versions 2.0, 3.0, and 3.5.
        /// </summary>
        public string RuntimeDirectory
        {
            get
            {
                HRESULT hr;
                string pwzBufferResult;

                if ((hr = TryGetRuntimeDirectory(out pwzBufferResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pwzBufferResult;
            }
        }

        /// <summary>
        /// Gets the installation directory of the common language runtime (CLR) associated with this interface. This method supersedes the GetCORSystemDirectory function provided in the .NET Framework versions 2.0, 3.0, and 3.5.
        /// </summary>
        /// <param name="pwzBufferResult">[out] Returns the CLR installation directory. The installation path is fully qualified; for example, "c:\windows\microsoft.net\framework\v1.0.3705\".</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT   | Description                        |
        /// | --------- | ---------------------------------- |
        /// | S_OK      | The method completed successfully. |
        /// | E_POINTER | pwzBuffer or pchBuffer is null.    |
        /// </returns>
        public HRESULT TryGetRuntimeDirectory(out string pwzBufferResult)
        {
            /*HRESULT GetRuntimeDirectory([MarshalAs(UnmanagedType.LPWStr), Out]
            StringBuilder pwzBuffer, [In] [Out] ref uint pcchBuffer);*/
            StringBuilder pwzBuffer = null;
            uint pcchBuffer = default(uint);
            HRESULT hr = Raw.GetRuntimeDirectory(pwzBuffer, ref pcchBuffer);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            pwzBuffer = new StringBuilder((int) pcchBuffer);
            hr = Raw.GetRuntimeDirectory(pwzBuffer, ref pcchBuffer);

            if (hr == HRESULT.S_OK)
            {
                pwzBufferResult = pwzBuffer.ToString();

                return hr;
            }

            fail:
            pwzBufferResult = default(string);

            return hr;
        }

        #endregion
        #region IsLoadable

        /// <summary>
        /// Indicates whether the runtime associated with this interface can be loaded into the current process, taking into account other runtimes that might already be loaded into the process.
        /// </summary>
        public int IsLoadable
        {
            get
            {
                HRESULT hr;
                int pbLoadable;

                if ((hr = TryIsLoadable(out pbLoadable)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pbLoadable;
            }
        }

        /// <summary>
        /// Indicates whether the runtime associated with this interface can be loaded into the current process, taking into account other runtimes that might already be loaded into the process.
        /// </summary>
        /// <param name="pbLoadable">[out] true if this runtime could be loaded into the current process; otherwise, false.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT   | Description                        |
        /// | --------- | ---------------------------------- |
        /// | S_OK      | The method completed successfully. |
        /// | E_POINTER | pbLoadable is null.                |
        /// </returns>
        /// <remarks>
        /// If another runtime is already loaded into the process, and the runtime associated with this interface can be loaded
        /// for in-process side-by-side execution, pbLoadable returns true. If the two runtimes cannot run side-by-side in-process,
        /// pbLoadable returns false. For example, the common language runtime (CLR) version 4 can run side-by-side in the
        /// same process with CLR version 2.0 or CLR version 1.1. However, CLR version 1.1 and CLR version 2.0 cannot run side-by-side
        /// in-process. If no runtimes are loaded into the process, this method always returns true.
        /// </remarks>
        public HRESULT TryIsLoadable(out int pbLoadable)
        {
            /*HRESULT IsLoadable(
            [Out] out int pbLoadable);*/
            return Raw.IsLoadable(out pbLoadable);
        }

        #endregion
        #region IsStarted

        /// <summary>
        /// Indicates whether the runtime has been started (that is, whether the <see cref="CLRRuntimeHost.Start"/> has been called and has succeeded).
        /// </summary>
        public IsStartedResult IsStarted
        {
            get
            {
                HRESULT hr;
                IsStartedResult result;

                if ((hr = TryIsStarted(out result)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return result;
            }
        }

        /// <summary>
        /// Indicates whether the runtime has been started (that is, whether the <see cref="CLRRuntimeHost.Start"/> has been called and has succeeded).
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT   | Description                                                                                        |
        /// | --------- | -------------------------------------------------------------------------------------------------- |
        /// | S_OK      | The method completed successfully.                                                                 |
        /// | E_NOTIMPL | The common language runtime (CLR) version is earlier than the CLR version in the .NET Framework 4. |
        /// </returns>
        /// <remarks>
        /// This method does not work with CLR versions earlier than the CLR version in the .NET Framework 4.
        /// </remarks>
        public HRESULT TryIsStarted(out IsStartedResult result)
        {
            /*HRESULT IsStarted(out int pbStarted, out uint pdwStartupFlags);*/
            int pbStarted;
            uint pdwStartupFlags;
            HRESULT hr = Raw.IsStarted(out pbStarted, out pdwStartupFlags);

            if (hr == HRESULT.S_OK)
                result = new IsStartedResult(pbStarted, pdwStartupFlags);
            else
                result = default(IsStartedResult);

            return hr;
        }

        #endregion
        #region IsLoaded

        /// <summary>
        /// Indicates whether the common language runtime (CLR) associated with the <see cref="ICLRRuntimeInfo"/> interface is loaded into a process.<para/>
        /// A runtime can be loaded without also being started.
        /// </summary>
        /// <param name="hndProcess">[in] A handle to the process.</param>
        /// <returns>[out] true if the CLR is loaded into the process; otherwise, false.</returns>
        /// <remarks>
        /// This method is backward-compatible with the following functions and interfaces: A host may call one of the deprecated
        /// CorBindTo* functions, such as the CorBindToRuntime function, to instantiate a specific version of the CLR. The
        /// host could then call the <see cref="CLRMetaHost.GetRuntime"/> method and specify the same version number to obtain
        /// a <see cref="ICLRRuntimeInfo"/> interface. If the host then calls the IsLoaded method on the returned <see cref="ICLRRuntimeInfo"/>
        /// interface, pbLoaded returns true; otherwise, it returns false.
        /// </remarks>
        public int IsLoaded(IntPtr hndProcess)
        {
            HRESULT hr;
            int pbLoaded;

            if ((hr = TryIsLoaded(hndProcess, out pbLoaded)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pbLoaded;
        }

        /// <summary>
        /// Indicates whether the common language runtime (CLR) associated with the <see cref="ICLRRuntimeInfo"/> interface is loaded into a process.<para/>
        /// A runtime can be loaded without also being started.
        /// </summary>
        /// <param name="hndProcess">[in] A handle to the process.</param>
        /// <param name="pbLoaded">[out] true if the CLR is loaded into the process; otherwise, false.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT   | Description                        |
        /// | --------- | ---------------------------------- |
        /// | S_OK      | The method completed successfully. |
        /// | E_POINTER | pbLoaded is null.                  |
        /// </returns>
        /// <remarks>
        /// This method is backward-compatible with the following functions and interfaces: A host may call one of the deprecated
        /// CorBindTo* functions, such as the CorBindToRuntime function, to instantiate a specific version of the CLR. The
        /// host could then call the <see cref="CLRMetaHost.GetRuntime"/> method and specify the same version number to obtain
        /// a <see cref="ICLRRuntimeInfo"/> interface. If the host then calls the IsLoaded method on the returned <see cref="ICLRRuntimeInfo"/>
        /// interface, pbLoaded returns true; otherwise, it returns false.
        /// </remarks>
        public HRESULT TryIsLoaded(IntPtr hndProcess, out int pbLoaded)
        {
            /*HRESULT IsLoaded(
            [In] IntPtr hndProcess,
            [Out] out int pbLoaded);*/
            return Raw.IsLoaded(hndProcess, out pbLoaded);
        }

        #endregion
        #region LoadErrorString

        /// <summary>
        /// Translates an <see cref="HRESULT"/> value into an appropriate error message for the specified culture. This method supersedes the following functions:
        /// </summary>
        /// <param name="iResourceID">[in] The <see cref="HRESULT"/> to translate.</param>
        /// <param name="iLocaleID">[in] The culture identifier. To use the default culture, you must specify -1.</param>
        /// <returns>[out] The message string associated with the given <see cref="HRESULT"/>.</returns>
        public string LoadErrorString(HRESULT iResourceID, int iLocaleID)
        {
            HRESULT hr;
            string pwzBufferResult;

            if ((hr = TryLoadErrorString(iResourceID, iLocaleID, out pwzBufferResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pwzBufferResult;
        }

        /// <summary>
        /// Translates an <see cref="HRESULT"/> value into an appropriate error message for the specified culture. This method supersedes the following functions:
        /// </summary>
        /// <param name="iResourceID">[in] The <see cref="HRESULT"/> to translate.</param>
        /// <param name="pwzBufferResult">[out] The message string associated with the given <see cref="HRESULT"/>.</param>
        /// <param name="iLocaleID">[in] The culture identifier. To use the default culture, you must specify -1.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT      | Description                        |
        /// | ------------ | ---------------------------------- |
        /// | S_OK         | The method completed successfully. |
        /// | E_POINTER    | pcchBuffer is null.                |
        /// | E_INVALIDARG | pwzBuffer is null.                 |
        /// </returns>
        public HRESULT TryLoadErrorString(HRESULT iResourceID, int iLocaleID, out string pwzBufferResult)
        {
            /*HRESULT LoadErrorString(
            [In] HRESULT iResourceID,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder pwzBuffer,
            [In, Out] ref uint pcchBuffer,
            [In] int iLocaleID);*/
            StringBuilder pwzBuffer = null;
            uint pcchBuffer = default(uint);
            HRESULT hr = Raw.LoadErrorString(iResourceID, pwzBuffer, ref pcchBuffer, iLocaleID);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            pwzBuffer = new StringBuilder((int) pcchBuffer);
            hr = Raw.LoadErrorString(iResourceID, pwzBuffer, ref pcchBuffer, iLocaleID);

            if (hr == HRESULT.S_OK)
            {
                pwzBufferResult = pwzBuffer.ToString();

                return hr;
            }

            fail:
            pwzBufferResult = default(string);

            return hr;
        }

        #endregion
        #region LoadLibrary

        /// <summary>
        /// Loads a .NET Framework library from the common language runtime (CLR) represented by an <see cref="ICLRRuntimeInfo"/> interface.<para/>
        /// This method supersedes the LoadLibraryShim function.
        /// </summary>
        /// <param name="pwzDllName">[in] The name of the assembly to be loaded.</param>
        /// <returns>[out] A handle to the loaded assembly.</returns>
        /// <remarks>
        /// This method only loads DLLs included in the .NET Framework redistributable package. It can not load user-generated
        /// assemblies.
        /// </remarks>
        public IntPtr LoadLibrary(string pwzDllName)
        {
            HRESULT hr;
            IntPtr phndModule = default(IntPtr);

            if ((hr = TryLoadLibrary(pwzDllName, ref phndModule)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return phndModule;
        }

        /// <summary>
        /// Loads a .NET Framework library from the common language runtime (CLR) represented by an <see cref="ICLRRuntimeInfo"/> interface.<para/>
        /// This method supersedes the LoadLibraryShim function.
        /// </summary>
        /// <param name="pwzDllName">[in] The name of the assembly to be loaded.</param>
        /// <param name="phndModule">[out] A handle to the loaded assembly.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT       | Description                                           |
        /// | ------------- | ----------------------------------------------------- |
        /// | S_OK          | The method completed successfully.                    |
        /// | E_POINTER     | pwzDllName or phndModule is null.                     |
        /// | E_OUTOFMEMORY | Not enough memory is available to handle the request. |
        /// </returns>
        /// <remarks>
        /// This method only loads DLLs included in the .NET Framework redistributable package. It can not load user-generated
        /// assemblies.
        /// </remarks>
        public HRESULT TryLoadLibrary(string pwzDllName, ref IntPtr phndModule)
        {
            /*HRESULT LoadLibrary(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzDllName,
            [Out] IntPtr phndModule);*/
            return Raw.LoadLibrary(pwzDllName, phndModule);
        }

        #endregion
        #region GetProcAddress

        /// <summary>
        /// Gets the address of a specified function that was exported from the common language runtime (CLR) associated with this interface.<para/>
        /// This method supersedes the GetRealProcAddress function.
        /// </summary>
        /// <param name="pszProcName">[in] The name of the exported function.</param>
        /// <returns>[out] The address of the exported function.</returns>
        /// <remarks>
        /// This method causes the CLR to be loaded but not initialized.
        /// </remarks>
        public IntPtr GetProcAddress(string pszProcName)
        {
            HRESULT hr;
            IntPtr ppProc = default(IntPtr);

            if ((hr = TryGetProcAddress(pszProcName, ref ppProc)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppProc;
        }

        /// <summary>
        /// Gets the address of a specified function that was exported from the common language runtime (CLR) associated with this interface.<para/>
        /// This method supersedes the GetRealProcAddress function.
        /// </summary>
        /// <param name="pszProcName">[in] The name of the exported function.</param>
        /// <param name="ppProc">[out] The address of the exported function.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT                  | Description                                         |
        /// | ------------------------ | --------------------------------------------------- |
        /// | S_OK                     | The method completed successfully.                  |
        /// | E_POINTER                | pszProcName or ppProc is null.                      |
        /// | CLR_E_SHIM_RUNTIMEEXPORT | The specified function is not an exported function. |
        /// </returns>
        /// <remarks>
        /// This method causes the CLR to be loaded but not initialized.
        /// </remarks>
        public HRESULT TryGetProcAddress(string pszProcName, ref IntPtr ppProc)
        {
            /*HRESULT GetProcAddress(
            [MarshalAs(UnmanagedType.LPStr), In] string pszProcName,
            [Out] IntPtr ppProc);*/
            return Raw.GetProcAddress(pszProcName, ppProc);
        }

        #endregion
        #region GetInterface

        /// <summary>
        /// Loads the CLR into the current process and returns runtime interface pointers, such as <see cref="ICLRRuntimeHost"/>, <see cref="ICLRStrongName"/>, and <see cref="IMetaDataDispenser"/>.<para/>
        /// This method supersedes all the CorBindTo* functions in the Deprecated CLR Hosting Functions section.
        /// </summary>
        /// <param name="rclsid">[in] The CLSID interface for the coclass.</param>
        /// <param name="riid">[in] The IID of the requested rclsid interface.</param>
        /// <remarks>
        /// This method causes the CLR to be loaded but not initialized. The following table shows the supported combinations
        /// for rclsid and riid.
        /// </remarks>
        public void GetInterface(Guid rclsid, Guid riid)
        {
            HRESULT hr;

            if ((hr = TryGetInterface(rclsid, riid)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Loads the CLR into the current process and returns runtime interface pointers, such as <see cref="ICLRRuntimeHost"/>, <see cref="ICLRStrongName"/>, and <see cref="IMetaDataDispenser"/>.<para/>
        /// This method supersedes all the CorBindTo* functions in the Deprecated CLR Hosting Functions section.
        /// </summary>
        /// <param name="rclsid">[in] The CLSID interface for the coclass.</param>
        /// <param name="riid">[in] The IID of the requested rclsid interface.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT                              | Description                                                                          |
        /// | ------------------------------------ | ------------------------------------------------------------------------------------ |
        /// | S_OK                                 | The method completed successfully.                                                   |
        /// | E_POINTER                            | ppUnk is null.                                                                       |
        /// | E_OUTOFMEMORY                        | Not enough memory is available to handle the request.                                |
        /// | CLR_E_SHIM_LEGACYRUNTIMEALREADYBOUND | A different runtime was already bound to the legacy CLR version 2 activation policy. |
        /// </returns>
        /// <remarks>
        /// This method causes the CLR to be loaded but not initialized. The following table shows the supported combinations
        /// for rclsid and riid.
        /// </remarks>
        public HRESULT TryGetInterface(Guid rclsid, Guid riid)
        {
            /*HRESULT GetInterface(
            [In] ref Guid rclsid,
            [In] ref Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppUnk);*/
            object ppUnk;

            return Raw.GetInterface(ref rclsid, ref riid, out ppUnk);
        }

        #endregion
        #region SetDefaultStartupFlags

        /// <summary>
        /// Sets the startup flags and the host configuration file that will be used to start the runtime. This method supersedes the use of the startupFlags parameter in the CorBindToRuntimeEx and CorBindToRuntimeHost functions.
        /// </summary>
        /// <param name="dwStartupFlags">[in] The host startup flags to set. Use the same flags as with the CorBindToRuntimeEx and CorBindToRuntimeHost functions.</param>
        /// <param name="pwzHostConfigFile">[in] The directory path of the host configuration file to set.</param>
        /// <remarks>
        /// A multithreaded host should synchronize calls to this method. Otherwise, thread A might call the SetStartupFlags
        /// method after thread B completes a call to SetStartupFlags and before thread B starts the runtime.
        /// </remarks>
        public void SetDefaultStartupFlags(uint dwStartupFlags, string pwzHostConfigFile)
        {
            HRESULT hr;

            if ((hr = TrySetDefaultStartupFlags(dwStartupFlags, pwzHostConfigFile)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Sets the startup flags and the host configuration file that will be used to start the runtime. This method supersedes the use of the startupFlags parameter in the CorBindToRuntimeEx and CorBindToRuntimeHost functions.
        /// </summary>
        /// <param name="dwStartupFlags">[in] The host startup flags to set. Use the same flags as with the CorBindToRuntimeEx and CorBindToRuntimeHost functions.</param>
        /// <param name="pwzHostConfigFile">[in] The directory path of the host configuration file to set.</param>
        /// <returns>
        /// This method returns the following specific HRESULT as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT | Description                        |
        /// | ------- | ---------------------------------- |
        /// | S_OK    | The method completed successfully. |
        /// </returns>
        /// <remarks>
        /// A multithreaded host should synchronize calls to this method. Otherwise, thread A might call the SetStartupFlags
        /// method after thread B completes a call to SetStartupFlags and before thread B starts the runtime.
        /// </remarks>
        public HRESULT TrySetDefaultStartupFlags(uint dwStartupFlags, string pwzHostConfigFile)
        {
            /*HRESULT SetDefaultStartupFlags([In] uint dwStartupFlags,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzHostConfigFile);*/
            return Raw.SetDefaultStartupFlags(dwStartupFlags, pwzHostConfigFile);
        }

        #endregion
        #region GetDefaultStartupFlags

        /// <summary>
        /// Gets the startup flags and host configuration file that will be used to start the runtime.
        /// </summary>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// This method returns the default flag values (STARTUP_CONCURRENT_GC and NULL), or the values provided by a previous
        /// call to the <see cref="SetDefaultStartupFlags"/>, or the values set by any of the CorBind* methods if they are
        /// bound to this runtime.
        /// </remarks>
        public GetDefaultStartupFlagsResult GetDefaultStartupFlags()
        {
            HRESULT hr;
            GetDefaultStartupFlagsResult result;

            if ((hr = TryGetDefaultStartupFlags(out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the startup flags and host configuration file that will be used to start the runtime.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// This method returns the following specific HRESULT as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT | Description                        |
        /// | ------- | ---------------------------------- |
        /// | S_OK    | The method completed successfully. |
        /// </returns>
        /// <remarks>
        /// This method returns the default flag values (STARTUP_CONCURRENT_GC and NULL), or the values provided by a previous
        /// call to the <see cref="SetDefaultStartupFlags"/>, or the values set by any of the CorBind* methods if they are
        /// bound to this runtime.
        /// </remarks>
        public HRESULT TryGetDefaultStartupFlags(out GetDefaultStartupFlagsResult result)
        {
            /*HRESULT GetDefaultStartupFlags(
            out uint pdwStartupFlags,
            [MarshalAs(UnmanagedType.LPWStr), Out]
            StringBuilder pwzHostConfigFile,
            [In] [Out] ref uint pcchHostConfigFile);*/
            uint pdwStartupFlags;
            StringBuilder pwzHostConfigFile = null;
            uint pcchHostConfigFile = default(uint);
            HRESULT hr = Raw.GetDefaultStartupFlags(out pdwStartupFlags, pwzHostConfigFile, ref pcchHostConfigFile);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            pwzHostConfigFile = new StringBuilder((int) pcchHostConfigFile);
            hr = Raw.GetDefaultStartupFlags(out pdwStartupFlags, pwzHostConfigFile, ref pcchHostConfigFile);

            if (hr == HRESULT.S_OK)
            {
                result = new GetDefaultStartupFlagsResult(pdwStartupFlags, pwzHostConfigFile.ToString());

                return hr;
            }

            fail:
            result = default(GetDefaultStartupFlagsResult);

            return hr;
        }

        #endregion
        #region BindAsLegacyV2Runtime

        /// <summary>
        /// Binds the current runtime for all legacy common language runtime (CLR) version 2 activation policy decisions.
        /// </summary>
        /// <remarks>
        /// If the current runtime is already bound for all legacy CLR version 2 activation policy decisions (for example,
        /// by using the useLegacyV2RuntimeActivationPolicy attribute on the &lt;startup&gt; element in the configuration file),
        /// this method does not return an error result; instead, the result is S_OK, just as it would be if the method had
        /// successfully bound legacy activation policy.
        /// </remarks>
        public void BindAsLegacyV2Runtime()
        {
            HRESULT hr;

            if ((hr = TryBindAsLegacyV2Runtime()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Binds the current runtime for all legacy common language runtime (CLR) version 2 activation policy decisions.
        /// </summary>
        /// <returns>
        /// This method returns the following specific HRESULTs:
        /// 
        /// | HRESULT                              | Description                                                                                                        |
        /// | ------------------------------------ | ------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                                 | Either binding succeeded, or this runtime was already bound as the legacy CLR version 2 activation policy runtime. |
        /// | CLR_E_SHIM_LEGACYRUNTIMEALREADYBOUND | A different runtime was already bound to the legacy CLR version 2 activation policy.                               |
        /// </returns>
        /// <remarks>
        /// If the current runtime is already bound for all legacy CLR version 2 activation policy decisions (for example,
        /// by using the useLegacyV2RuntimeActivationPolicy attribute on the &lt;startup&gt; element in the configuration file),
        /// this method does not return an error result; instead, the result is S_OK, just as it would be if the method had
        /// successfully bound legacy activation policy.
        /// </remarks>
        public HRESULT TryBindAsLegacyV2Runtime()
        {
            /*HRESULT BindAsLegacyV2Runtime();*/
            return Raw.BindAsLegacyV2Runtime();
        }

        #endregion
        #endregion
    }
}