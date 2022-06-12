using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides information about a loaded module.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugLoadedModule"/> interface is implemented by a debugger and is used by the CLR debugging interfaces to
    /// get information about the loaded module from the debugger.
    /// </remarks>
    public class CorDebugLoadedModule : ComObject<ICorDebugLoadedModule>
    {
        public CorDebugLoadedModule(ICorDebugLoadedModule raw) : base(raw)
        {
        }

        #region ICorDebugLoadedModule
        #region GetBaseAddress

        /// <summary>
        /// Gets the base address of the loaded module.
        /// </summary>
        public ulong BaseAddress
        {
            get
            {
                HRESULT hr;
                ulong pAddress;

                if ((hr = TryGetBaseAddress(out pAddress)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pAddress;
            }
        }

        /// <summary>
        /// Gets the base address of the loaded module.
        /// </summary>
        /// <param name="pAddress">[out] A pointer to the base address of the loaded module.</param>
        public HRESULT TryGetBaseAddress(out ulong pAddress)
        {
            /*HRESULT GetBaseAddress(out ulong pAddress);*/
            return Raw.GetBaseAddress(out pAddress);
        }

        #endregion
        #region GetSize

        /// <summary>
        /// Gets the size in bytes of the loaded module.
        /// </summary>
        public uint Size
        {
            get
            {
                HRESULT hr;
                uint pcBytes;

                if ((hr = TryGetSize(out pcBytes)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcBytes;
            }
        }

        /// <summary>
        /// Gets the size in bytes of the loaded module.
        /// </summary>
        /// <param name="pcBytes">[out] A pointer to the number of bytes in the loaded module.</param>
        public HRESULT TryGetSize(out uint pcBytes)
        {
            /*HRESULT GetSize(out uint pcBytes);*/
            return Raw.GetSize(out pcBytes);
        }

        #endregion
        #region GetName

        /// <summary>
        /// Gets the name of the loaded module.
        /// </summary>
        /// <returns>[out] An array of characters that contain the name of the loaded module.</returns>
        public string GetName()
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryGetName(out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

        /// <summary>
        /// Gets the name of the loaded module.
        /// </summary>
        /// <param name="szNameResult">[out] An array of characters that contain the name of the loaded module.</param>
        public HRESULT TryGetName(out string szNameResult)
        {
            /*HRESULT GetName([In] uint cchName, out uint pcchName, [Out] StringBuilder szName);*/
            uint cchName = 0;
            uint pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetName(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder((int) pcchName);
            hr = Raw.GetName(cchName, out pcchName, szName);

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