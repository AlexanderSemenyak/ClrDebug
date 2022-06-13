using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides functions for the Edit and Continue feature.
    /// </summary>
    public class SymUnmanagedENCUpdate : ComObject<ISymUnmanagedENCUpdate>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymUnmanagedENCUpdate"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SymUnmanagedENCUpdate(ISymUnmanagedENCUpdate raw) : base(raw)
        {
        }

        #region ISymUnmanagedENCUpdate
        #region UpdateSymbolStore2

        /// <summary>
        /// Allows a compiler to omit functions that have not been modified from the program database (PDB) stream, provided the line information meets the requirements.<para/>
        /// The correct line information can be determined with the old PDB line information and one delta for all lines in the function.
        /// </summary>
        /// <param name="pIStream">[in] A pointer to an <see cref="IStream"/> that contains the line information.</param>
        /// <param name="pDeltaLines">[in] A pointer to a <see cref="SYMLINEDELTA"/> structure that contains the lines that have changed.</param>
        /// <param name="cDeltaLines">[in] A ULONG that represents the number of lines that have changed.</param>
        public void UpdateSymbolStore2(IStream pIStream, SYMLINEDELTA pDeltaLines, int cDeltaLines)
        {
            HRESULT hr;

            if ((hr = TryUpdateSymbolStore2(pIStream, pDeltaLines, cDeltaLines)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Allows a compiler to omit functions that have not been modified from the program database (PDB) stream, provided the line information meets the requirements.<para/>
        /// The correct line information can be determined with the old PDB line information and one delta for all lines in the function.
        /// </summary>
        /// <param name="pIStream">[in] A pointer to an <see cref="IStream"/> that contains the line information.</param>
        /// <param name="pDeltaLines">[in] A pointer to a <see cref="SYMLINEDELTA"/> structure that contains the lines that have changed.</param>
        /// <param name="cDeltaLines">[in] A ULONG that represents the number of lines that have changed.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryUpdateSymbolStore2(IStream pIStream, SYMLINEDELTA pDeltaLines, int cDeltaLines)
        {
            /*HRESULT UpdateSymbolStore2([MarshalAs(UnmanagedType.Interface), In]
            IStream pIStream, [In] ref SYMLINEDELTA pDeltaLines, [In] int cDeltaLines);*/
            return Raw.UpdateSymbolStore2(pIStream, ref pDeltaLines, cDeltaLines);
        }

        #endregion
        #region GetLocalVariableCount

        /// <summary>
        /// Gets the number of local variables.
        /// </summary>
        /// <param name="mdMethodToken">[in] The metadata token of methods.</param>
        /// <returns>[out] A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the number of local variables.</returns>
        public int GetLocalVariableCount(mdMethodDef mdMethodToken)
        {
            HRESULT hr;
            int pcLocals;

            if ((hr = TryGetLocalVariableCount(mdMethodToken, out pcLocals)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pcLocals;
        }

        /// <summary>
        /// Gets the number of local variables.
        /// </summary>
        /// <param name="mdMethodToken">[in] The metadata token of methods.</param>
        /// <param name="pcLocals">[out] A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the number of local variables.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetLocalVariableCount(mdMethodDef mdMethodToken, out int pcLocals)
        {
            /*HRESULT GetLocalVariableCount([In] mdMethodDef mdMethodToken, out int pcLocals);*/
            return Raw.GetLocalVariableCount(mdMethodToken, out pcLocals);
        }

        #endregion
        #region GetLocalVariables

        /// <summary>
        /// Gets the local variables.
        /// </summary>
        /// <param name="mdMethodToken">[in] The metadata token of the method.</param>
        /// <param name="cLocals">[in] A ULONG that indicates the size of the rgLocals parameter.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetLocalVariablesResult GetLocalVariables(mdMethodDef mdMethodToken, int cLocals)
        {
            HRESULT hr;
            GetLocalVariablesResult result;

            if ((hr = TryGetLocalVariables(mdMethodToken, cLocals, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the local variables.
        /// </summary>
        /// <param name="mdMethodToken">[in] The metadata token of the method.</param>
        /// <param name="cLocals">[in] A ULONG that indicates the size of the rgLocals parameter.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetLocalVariables(mdMethodDef mdMethodToken, int cLocals, out GetLocalVariablesResult result)
        {
            /*HRESULT GetLocalVariables(
            [In] mdMethodDef mdMethodToken,
            [In] int cLocals,
            [Out] IntPtr rgLocals, //ISymUnmanagedVariable
            out int pceltFetched);*/
            IntPtr rgLocals = default(IntPtr);
            int pceltFetched;
            HRESULT hr = Raw.GetLocalVariables(mdMethodToken, cLocals, rgLocals, out pceltFetched);

            if (hr == HRESULT.S_OK)
                result = new GetLocalVariablesResult(rgLocals, pceltFetched);
            else
                result = default(GetLocalVariablesResult);

            return hr;
        }

        #endregion
        #region InitializeForEnc

        /// <summary>
        /// Allows method boundaries to be computed before the first call to the <see cref="UpdateSymbolStore2"/> method.
        /// </summary>
        public void InitializeForEnc()
        {
            HRESULT hr;

            if ((hr = TryInitializeForEnc()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Allows method boundaries to be computed before the first call to the <see cref="UpdateSymbolStore2"/> method.
        /// </summary>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryInitializeForEnc()
        {
            /*HRESULT InitializeForEnc();*/
            return Raw.InitializeForEnc();
        }

        #endregion
        #region UpdateMethodLines

        /// <summary>
        /// Allows updating the line information for a method that has not been recompiled, but whose lines have moved independently.<para/>
        /// A delta for each statement is allowed.
        /// </summary>
        /// <param name="mdMethodToken">[in] The metadata of the method token.</param>
        /// <param name="pDeltas">[in] An array of INT32 values that indicates deltas for each sequence point in the method.</param>
        /// <param name="cDeltas">[in] A ULONG containing the size of the pDeltas parameter.</param>
        public void UpdateMethodLines(mdMethodDef mdMethodToken, int pDeltas, int cDeltas)
        {
            HRESULT hr;

            if ((hr = TryUpdateMethodLines(mdMethodToken, pDeltas, cDeltas)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Allows updating the line information for a method that has not been recompiled, but whose lines have moved independently.<para/>
        /// A delta for each statement is allowed.
        /// </summary>
        /// <param name="mdMethodToken">[in] The metadata of the method token.</param>
        /// <param name="pDeltas">[in] An array of INT32 values that indicates deltas for each sequence point in the method.</param>
        /// <param name="cDeltas">[in] A ULONG containing the size of the pDeltas parameter.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryUpdateMethodLines(mdMethodDef mdMethodToken, int pDeltas, int cDeltas)
        {
            /*HRESULT UpdateMethodLines([In] mdMethodDef mdMethodToken, [In] ref int pDeltas, [In] int cDeltas);*/
            return Raw.UpdateMethodLines(mdMethodToken, ref pDeltas, cDeltas);
        }

        #endregion
        #endregion
    }
}