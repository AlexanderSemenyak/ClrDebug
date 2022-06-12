using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods that get information about the search path. Obtain this interface by calling QueryInterface on an object that implements the <see cref="ISymUnmanagedReader"/> interface.
    /// </summary>
    public class SymUnmanagedSymbolSearchInfo : ComObject<ISymUnmanagedSymbolSearchInfo>
    {
        public SymUnmanagedSymbolSearchInfo(ISymUnmanagedSymbolSearchInfo raw) : base(raw)
        {
        }

        #region ISymUnmanagedSymbolSearchInfo
        #region SearchPathLength

        /// <summary>
        /// Gets the search path length.
        /// </summary>
        public int SearchPathLength
        {
            get
            {
                HRESULT hr;
                int pcchPath;

                if ((hr = TryGetSearchPathLength(out pcchPath)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcchPath;
            }
        }

        /// <summary>
        /// Gets the search path length.
        /// </summary>
        /// <param name="pcchPath">[out] A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the search path length.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetSearchPathLength(out int pcchPath)
        {
            /*HRESULT GetSearchPathLength(out int pcchPath);*/
            return Raw.GetSearchPathLength(out pcchPath);
        }

        #endregion
        #region HRESULT

        /// <summary>
        /// Gets the <see cref="HRESULT"/>.
        /// </summary>
        public HRESULT HRESULT
        {
            get
            {
                HRESULT hr;
                HRESULT phr;

                if ((hr = TryGetHRESULT(out phr)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return phr;
            }
        }

        /// <summary>
        /// Gets the <see cref="HRESULT"/>.
        /// </summary>
        /// <param name="phr">[out] A pointer to the <see cref="HRESULT"/>.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetHRESULT(out HRESULT phr)
        {
            /*HRESULT GetHRESULT([MarshalAs(UnmanagedType.Error)] out HRESULT phr);*/
            return Raw.GetHRESULT(out phr);
        }

        #endregion
        #region GetSearchPath

        /// <summary>
        /// Gets the search path.
        /// </summary>
        /// <returns>[out] A buffer to hold the search path.</returns>
        public string GetSearchPath()
        {
            HRESULT hr;
            string szPathResult;

            if ((hr = TryGetSearchPath(out szPathResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szPathResult;
        }

        /// <summary>
        /// Gets the search path.
        /// </summary>
        /// <param name="szPathResult">[out] A buffer to hold the search path.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetSearchPath(out string szPathResult)
        {
            /*HRESULT GetSearchPath(
            [In] int cchPath,
            out int pcchPath,
            [Out] StringBuilder szPath);*/
            int cchPath = 0;
            int pcchPath;
            StringBuilder szPath = null;
            HRESULT hr = Raw.GetSearchPath(cchPath, out pcchPath, szPath);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER)
                goto fail;

            cchPath = pcchPath;
            szPath = new StringBuilder(pcchPath);
            hr = Raw.GetSearchPath(cchPath, out pcchPath, szPath);

            if (hr == HRESULT.S_OK)
            {
                szPathResult = szPath.ToString();

                return hr;
            }

            fail:
            szPathResult = default(string);

            return hr;
        }

        #endregion
        #endregion
    }
}