﻿using System;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ClrDebug
{
    /// <summary>
    /// Extends the <see cref="IMetaDataDispenser"/> interface to provide the capability to control how the metadata APIs operate on the current metadata scope.
    /// </summary>
    public class MetaDataDispenserEx : MetaDataDispenser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetaDataDispenserEx"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public MetaDataDispenserEx(IMetaDataDispenserEx raw) : base(raw)
        {
        }

        #region IMetaDataDispenserEx

        public new IMetaDataDispenserEx Raw => (IMetaDataDispenserEx) base.Raw;

        #region CORSystemDirectory

        /// <summary>
        /// Gets the directory that holds the current common language runtime (CLR). This method is supported only for use by out-of-process debuggers.<para/>
        /// If called from another component, it will return E_NOTIMPL.
        /// </summary>
        public string CORSystemDirectory
        {
            get
            {
                string szBufferResult;
                TryGetCORSystemDirectory(out szBufferResult).ThrowOnNotOK();

                return szBufferResult;
            }
        }

        /// <summary>
        /// Gets the directory that holds the current common language runtime (CLR). This method is supported only for use by out-of-process debuggers.<para/>
        /// If called from another component, it will return E_NOTIMPL.
        /// </summary>
        /// <param name="szBufferResult">[out] The buffer to receive the directory name.</param>
        public HRESULT TryGetCORSystemDirectory(out string szBufferResult)
        {
            /*HRESULT GetCORSystemDirectory(
            [Out, MarshalAs(UnmanagedType.LPWStr, SizeParamIndex = 1)] StringBuilder szBuffer,
            [In] int cchBuffer,
            [Out] out int pchBuffer);*/
            StringBuilder szBuffer = null;
            int cchBuffer = 0;
            int pchBuffer;
            HRESULT hr = Raw.GetCORSystemDirectory(szBuffer, cchBuffer, out pchBuffer);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchBuffer = pchBuffer;
            szBuffer = new StringBuilder(cchBuffer);
            hr = Raw.GetCORSystemDirectory(szBuffer, cchBuffer, out pchBuffer);

            if (hr == HRESULT.S_OK)
            {
                szBufferResult = szBuffer.ToString();

                return hr;
            }

            fail:
            szBufferResult = default(string);

            return hr;
        }

        #endregion
        #region SetOption

        /// <summary>
        /// Sets the specified option to a given value for the current metadata scope. The option controls how calls to the current metadata scope are handled.
        /// </summary>
        /// <param name="optionId">[in] A pointer to a GUID that specifies the option to be set.</param>
        /// <param name="pValue">[in] The value to use to set the option. The type of this value must be a variant of the specified option's type.</param>
        /// <remarks>
        /// The following table lists the available GUIDs that the optionId parameter can point to and the corresponding valid
        /// values for the pValue parameter.
        /// </remarks>
        public void SetOption(Guid optionId, object pValue)
        {
            TrySetOption(optionId, pValue).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the specified option to a given value for the current metadata scope. The option controls how calls to the current metadata scope are handled.
        /// </summary>
        /// <param name="optionId">[in] A pointer to a GUID that specifies the option to be set.</param>
        /// <param name="pValue">[in] The value to use to set the option. The type of this value must be a variant of the specified option's type.</param>
        /// <remarks>
        /// The following table lists the available GUIDs that the optionId parameter can point to and the corresponding valid
        /// values for the pValue parameter.
        /// </remarks>
        public HRESULT TrySetOption(Guid optionId, object pValue)
        {
            /*HRESULT SetOption([In] ref Guid optionId, [In, MarshalAs(UnmanagedType.Struct)] object pValue);*/
            return Raw.SetOption(ref optionId, pValue);
        }

        #endregion
        #region GetOption

        /// <summary>
        /// Gets the value of the specified option for the current metadata scope. The option controls how calls to the current metadata scope are handled.
        /// </summary>
        /// <param name="optionId">[in] A pointer to a GUID that specifies the option to be retrieved. See the Remarks section for a list of supported GUIDs.</param>
        /// <returns>[out] The value of the returned option. The type of this value will be a variant of the specified option's type.</returns>
        /// <remarks>
        /// The following list shows the GUIDs that are supported for this method. For descriptions, see the <see cref="SetOption"/>
        /// method. If optionId is not in this list, this method returns <see cref="HRESULT"/> E_INVALIDARG, indicating an incorrect parameter.
        /// </remarks>
        public object GetOption(Guid optionId)
        {
            object pValue = default(object);
            TryGetOption(optionId, ref pValue).ThrowOnNotOK();

            return pValue;
        }

        /// <summary>
        /// Gets the value of the specified option for the current metadata scope. The option controls how calls to the current metadata scope are handled.
        /// </summary>
        /// <param name="optionId">[in] A pointer to a GUID that specifies the option to be retrieved. See the Remarks section for a list of supported GUIDs.</param>
        /// <param name="pValue">[out] The value of the returned option. The type of this value will be a variant of the specified option's type.</param>
        /// <remarks>
        /// The following list shows the GUIDs that are supported for this method. For descriptions, see the <see cref="SetOption"/>
        /// method. If optionId is not in this list, this method returns <see cref="HRESULT"/> E_INVALIDARG, indicating an incorrect parameter.
        /// </remarks>
        public HRESULT TryGetOption(Guid optionId, ref object pValue)
        {
            /*HRESULT GetOption([In] ref Guid optionId, [Out] object pValue);*/
            return Raw.GetOption(ref optionId, pValue);
        }

        #endregion
        #region OpenScopeOnITypeInfo

        /// <summary>
        /// This method is not implemented. If called, it returns E_NOTIMPL.
        /// </summary>
        /// <param name="pITI">[in] Pointer to an ITypeInfo interface that provides the type information on which to open the scope.</param>
        /// <param name="dwOpenFlags">[in] The open mode flags.</param>
        /// <param name="riid">[in] The desired interface.</param>
        /// <returns>[out] Pointer to a pointer to the returned interface.</returns>
        public object OpenScopeOnITypeInfo(ITypeInfo pITI, int dwOpenFlags, Guid riid)
        {
            object ppIUnk;
            TryOpenScopeOnITypeInfo(pITI, dwOpenFlags, riid, out ppIUnk).ThrowOnNotOK();

            return ppIUnk;
        }

        /// <summary>
        /// This method is not implemented. If called, it returns E_NOTIMPL.
        /// </summary>
        /// <param name="pITI">[in] Pointer to an ITypeInfo interface that provides the type information on which to open the scope.</param>
        /// <param name="dwOpenFlags">[in] The open mode flags.</param>
        /// <param name="riid">[in] The desired interface.</param>
        /// <param name="ppIUnk">[out] Pointer to a pointer to the returned interface.</param>
        public HRESULT TryOpenScopeOnITypeInfo(ITypeInfo pITI, int dwOpenFlags, Guid riid, out object ppIUnk)
        {
            /*HRESULT OpenScopeOnITypeInfo(
            [In, MarshalAs(UnmanagedType.Interface)] ITypeInfo pITI,
            [In] int dwOpenFlags,
            [In] ref Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface, IidParameterIndex = 2)] out object ppIUnk
        );*/
            return Raw.OpenScopeOnITypeInfo(pITI, dwOpenFlags, ref riid, out ppIUnk);
        }

        #endregion
        #region FindAssembly

        /// <summary>
        /// This method is not implemented. If called, it returns E_NOTIMPL.
        /// </summary>
        /// <param name="szAppBase">[in] Not used.</param>
        /// <param name="szPrivateBin">[in] Not used.</param>
        /// <param name="szGlobalBin">[in] Not used.</param>
        /// <param name="szAssemblyName">[in] The assembly to be found.</param>
        /// <returns>[out] The simple name of the assembly.</returns>
        public string FindAssembly(string szAppBase, string szPrivateBin, string szGlobalBin, string szAssemblyName)
        {
            string szNameResult;
            TryFindAssembly(szAppBase, szPrivateBin, szGlobalBin, szAssemblyName, out szNameResult).ThrowOnNotOK();

            return szNameResult;
        }

        /// <summary>
        /// This method is not implemented. If called, it returns E_NOTIMPL.
        /// </summary>
        /// <param name="szAppBase">[in] Not used.</param>
        /// <param name="szPrivateBin">[in] Not used.</param>
        /// <param name="szGlobalBin">[in] Not used.</param>
        /// <param name="szAssemblyName">[in] The assembly to be found.</param>
        /// <param name="szNameResult">[out] The simple name of the assembly.</param>
        public HRESULT TryFindAssembly(string szAppBase, string szPrivateBin, string szGlobalBin, string szAssemblyName, out string szNameResult)
        {
            /*HRESULT FindAssembly(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szAppBase,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szPrivateBin,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szGlobalBin,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szAssemblyName,
            [Out, MarshalAs(UnmanagedType.LPWStr, SizeParamIndex = 5)] StringBuilder szName,
            [In] int cchName,
            [Out] out int pcName);*/
            StringBuilder szName = null;
            int cchName = 0;
            int pcName;
            HRESULT hr = Raw.FindAssembly(szAppBase, szPrivateBin, szGlobalBin, szAssemblyName, szName, cchName, out pcName);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pcName;
            szName = new StringBuilder(cchName);
            hr = Raw.FindAssembly(szAppBase, szPrivateBin, szGlobalBin, szAssemblyName, szName, cchName, out pcName);

            if (hr == HRESULT.S_OK)
            {
                szNameResult = szName.ToString();

                return hr;
            }

            fail:
            szNameResult = default(string);

            return hr;
        }

        #endregion
        #region FindAssemblyModule

        /// <summary>
        /// This method is not implemented. If called, it returns E_NOTIMPL.
        /// </summary>
        /// <param name="szAppBase">[in] Not used.</param>
        /// <param name="szPrivateBin">[in] Not used.</param>
        /// <param name="szGlobalBin">[in] Not used.</param>
        /// <param name="szAssemblyName">[in] The name of the module.</param>
        /// <param name="szModuleName">[in] The assembly to be found.</param>
        /// <returns>[out] The simple name of the assembly.</returns>
        public string FindAssemblyModule(string szAppBase, string szPrivateBin, string szGlobalBin, string szAssemblyName, string szModuleName)
        {
            string szNameResult;
            TryFindAssemblyModule(szAppBase, szPrivateBin, szGlobalBin, szAssemblyName, szModuleName, out szNameResult).ThrowOnNotOK();

            return szNameResult;
        }

        /// <summary>
        /// This method is not implemented. If called, it returns E_NOTIMPL.
        /// </summary>
        /// <param name="szAppBase">[in] Not used.</param>
        /// <param name="szPrivateBin">[in] Not used.</param>
        /// <param name="szGlobalBin">[in] Not used.</param>
        /// <param name="szAssemblyName">[in] The name of the module.</param>
        /// <param name="szModuleName">[in] The assembly to be found.</param>
        /// <param name="szNameResult">[out] The simple name of the assembly.</param>
        public HRESULT TryFindAssemblyModule(string szAppBase, string szPrivateBin, string szGlobalBin, string szAssemblyName, string szModuleName, out string szNameResult)
        {
            /*HRESULT FindAssemblyModule(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szAppBase,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szPrivateBin,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szGlobalBin,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szAssemblyName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szModuleName,
            [Out, MarshalAs(UnmanagedType.LPWStr, SizeParamIndex = 6)] StringBuilder szName,
            [In] int cchName,
            [Out] out int pcName);*/
            StringBuilder szName = null;
            int cchName = 0;
            int pcName;
            HRESULT hr = Raw.FindAssemblyModule(szAppBase, szPrivateBin, szGlobalBin, szAssemblyName, szModuleName, szName, cchName, out pcName);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pcName;
            szName = new StringBuilder(cchName);
            hr = Raw.FindAssemblyModule(szAppBase, szPrivateBin, szGlobalBin, szAssemblyName, szModuleName, szName, cchName, out pcName);

            if (hr == HRESULT.S_OK)
            {
                szNameResult = szName.ToString();

                return hr;
            }

            fail:
            szNameResult = default(string);

            return hr;
        }

        #endregion
        #endregion
    }
}
