using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods for marking and filtering metadata tokens to avoid repeating actions that have already been taken.
    /// </summary>
    public class MetaDataFilter : ComObject<IMetaDataFilter>
    {
        public MetaDataFilter(IMetaDataFilter raw) : base(raw)
        {
        }

        #region IMetaDataFilter
        #region UnmarkAll

        /// <summary>
        /// Removes the processing marks from all the tokens in the current metadata scope.
        /// </summary>
        public void UnmarkAll()
        {
            HRESULT hr;

            if ((hr = TryUnmarkAll()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Removes the processing marks from all the tokens in the current metadata scope.
        /// </summary>
        public HRESULT TryUnmarkAll()
        {
            /*HRESULT UnmarkAll();*/
            return Raw.UnmarkAll();
        }

        #endregion
        #region MarkToken

        /// <summary>
        /// Sets a value indicating that the specified metadata token has been processed.
        /// </summary>
        /// <param name="tk">[in] The token to mark as processed.</param>
        public void MarkToken(mdToken tk)
        {
            HRESULT hr;

            if ((hr = TryMarkToken(tk)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Sets a value indicating that the specified metadata token has been processed.
        /// </summary>
        /// <param name="tk">[in] The token to mark as processed.</param>
        public HRESULT TryMarkToken(mdToken tk)
        {
            /*HRESULT MarkToken(mdToken tk);*/
            return Raw.MarkToken(tk);
        }

        #endregion
        #region IsTokenMarked

        /// <summary>
        /// Gets a value indicating whether the specified metadata token has been marked as processed.
        /// </summary>
        /// <param name="tk">[in] The token to examine for a processing mark.</param>
        /// <returns>[out] A value that is true if tk has been processed; otherwise false.</returns>
        public int IsTokenMarked(mdToken tk)
        {
            HRESULT hr;
            int pIsMarked;

            if ((hr = TryIsTokenMarked(tk, out pIsMarked)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pIsMarked;
        }

        /// <summary>
        /// Gets a value indicating whether the specified metadata token has been marked as processed.
        /// </summary>
        /// <param name="tk">[in] The token to examine for a processing mark.</param>
        /// <param name="pIsMarked">[out] A value that is true if tk has been processed; otherwise false.</param>
        public HRESULT TryIsTokenMarked(mdToken tk, out int pIsMarked)
        {
            /*HRESULT IsTokenMarked([In] mdToken tk, [Out] out int pIsMarked);*/
            return Raw.IsTokenMarked(tk, out pIsMarked);
        }

        #endregion
        #endregion
    }
}