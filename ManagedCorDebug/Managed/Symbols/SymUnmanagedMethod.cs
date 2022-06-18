using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a method within the symbol store. This interface provides access to only the symbol-related attributes of a method, instead of the type-related attributes.
    /// </summary>
    public class SymUnmanagedMethod : ComObject<ISymUnmanagedMethod>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymUnmanagedMethod"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SymUnmanagedMethod(ISymUnmanagedMethod raw) : base(raw)
        {
        }

        #region ISymUnmanagedMethod
        #region Token

        /// <summary>
        /// Returns the metadata token for this method.
        /// </summary>
        public mdMethodDef Token
        {
            get
            {
                HRESULT hr;
                mdMethodDef pToken;

                if ((hr = TryGetToken(out pToken)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pToken;
            }
        }

        /// <summary>
        /// Returns the metadata token for this method.
        /// </summary>
        /// <param name="pToken">[out] A pointer to a <see cref="mdMethodDef"/> that receives the size, in characters, of the buffer required to contain the metadata.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetToken(out mdMethodDef pToken)
        {
            /*HRESULT GetToken([Out] out mdMethodDef pToken);*/
            return Raw.GetToken(out pToken);
        }

        #endregion
        #region SequencePointCount

        /// <summary>
        /// Gets the count of sequence points within this method.
        /// </summary>
        public int SequencePointCount
        {
            get
            {
                HRESULT hr;
                int pRetVal;

                if ((hr = TryGetSequencePointCount(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets the count of sequence points within this method.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the size of the buffer required to contain the sequence points.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetSequencePointCount(out int pRetVal)
        {
            /*HRESULT GetSequencePointCount([Out] out int pRetVal);*/
            return Raw.GetSequencePointCount(out pRetVal);
        }

        #endregion
        #region RootScope

        /// <summary>
        /// Gets the root lexical scope within this method. This scope encloses the entire method.
        /// </summary>
        public ISymUnmanagedScope RootScope
        {
            get
            {
                HRESULT hr;
                ISymUnmanagedScope pRetVal = default(ISymUnmanagedScope);

                if ((hr = TryGetRootScope(ref pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets the root lexical scope within this method. This scope encloses the entire method.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer that is set to the returned <see cref="ISymUnmanagedScope"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetRootScope(ref ISymUnmanagedScope pRetVal)
        {
            /*HRESULT GetRootScope([Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedScope pRetVal);*/
            return Raw.GetRootScope(pRetVal);
        }

        #endregion
        #region Parameters

        /// <summary>
        /// Gets the parameters for this method. The parameters are returned in the order in which they are defined within the method's signature.
        /// </summary>
        public ISymUnmanagedVariable[] Parameters
        {
            get
            {
                HRESULT hr;
                ISymUnmanagedVariable[] @paramsResult;

                if ((hr = TryGetParameters(out @paramsResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return @paramsResult;
            }
        }

        /// <summary>
        /// Gets the parameters for this method. The parameters are returned in the order in which they are defined within the method's signature.
        /// </summary>
        /// <param name="paramsResult">[out] A pointer to the buffer that receives the parameters.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetParameters(out ISymUnmanagedVariable[] @paramsResult)
        {
            /*HRESULT GetParameters([In] int cParams, [Out] out int pcParams, [MarshalAs(UnmanagedType.LPArray), Out] ISymUnmanagedVariable[] @params);*/
            int cParams = 0;
            int pcParams;
            ISymUnmanagedVariable[] @params = null;
            HRESULT hr = Raw.GetParameters(cParams, out pcParams, @params);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cParams = pcParams;
            @params = new ISymUnmanagedVariable[pcParams];
            hr = Raw.GetParameters(cParams, out pcParams, @params);

            if (hr == HRESULT.S_OK)
            {
                @paramsResult = @params;

                return hr;
            }

            fail:
            @paramsResult = default(ISymUnmanagedVariable[]);

            return hr;
        }

        #endregion
        #region Namespace

        /// <summary>
        /// Gets the namespace within which this method is defined.
        /// </summary>
        public SymUnmanagedNamespace Namespace
        {
            get
            {
                HRESULT hr;
                SymUnmanagedNamespace pRetValResult;

                if ((hr = TryGetNamespace(out pRetValResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRetValResult;
            }
        }

        /// <summary>
        /// Gets the namespace within which this method is defined.
        /// </summary>
        /// <param name="pRetValResult">[out] A pointer that is set to the returned <see cref="ISymUnmanagedNamespace"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetNamespace(out SymUnmanagedNamespace pRetValResult)
        {
            /*HRESULT GetNamespace([Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedNamespace pRetVal);*/
            ISymUnmanagedNamespace pRetVal;
            HRESULT hr = Raw.GetNamespace(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = new SymUnmanagedNamespace(pRetVal);
            else
                pRetValResult = default(SymUnmanagedNamespace);

            return hr;
        }

        #endregion
        #region GetScopeFromOffset

        /// <summary>
        /// Gets the most enclosing lexical scope within this method that encloses the given offset. This can be used to start local variable searches.
        /// </summary>
        /// <param name="offset">[in] A ULONG that contains the offset.</param>
        /// <returns>[out] A pointer that is set to the returned <see cref="ISymUnmanagedScope"/> interface.</returns>
        public ISymUnmanagedScope GetScopeFromOffset(int offset)
        {
            HRESULT hr;
            ISymUnmanagedScope pRetVal = default(ISymUnmanagedScope);

            if ((hr = TryGetScopeFromOffset(offset, ref pRetVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetVal;
        }

        /// <summary>
        /// Gets the most enclosing lexical scope within this method that encloses the given offset. This can be used to start local variable searches.
        /// </summary>
        /// <param name="offset">[in] A ULONG that contains the offset.</param>
        /// <param name="pRetVal">[out] A pointer that is set to the returned <see cref="ISymUnmanagedScope"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetScopeFromOffset(int offset, ref ISymUnmanagedScope pRetVal)
        {
            /*HRESULT GetScopeFromOffset([In] int offset, [Out, MarshalAs(UnmanagedType.Interface)] ISymUnmanagedScope pRetVal);*/
            return Raw.GetScopeFromOffset(offset, pRetVal);
        }

        #endregion
        #region GetOffset

        /// <summary>
        /// Returns the offset within this method that corresponds to a given position within a document.
        /// </summary>
        /// <param name="document">[in] A pointer to the document for which the offset is requested.</param>
        /// <param name="line">[in] The document line for which the offset is requested.</param>
        /// <param name="column">[in] The document column for which the offset is requested.</param>
        /// <returns>[out] A pointer to a ULONG32 that receives the offsets.</returns>
        public int GetOffset(ISymUnmanagedDocument document, int line, int column)
        {
            HRESULT hr;
            int pRetVal;

            if ((hr = TryGetOffset(document, line, column, out pRetVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetVal;
        }

        /// <summary>
        /// Returns the offset within this method that corresponds to a given position within a document.
        /// </summary>
        /// <param name="document">[in] A pointer to the document for which the offset is requested.</param>
        /// <param name="line">[in] The document line for which the offset is requested.</param>
        /// <param name="column">[in] The document column for which the offset is requested.</param>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the offsets.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetOffset(ISymUnmanagedDocument document, int line, int column, out int pRetVal)
        {
            /*HRESULT GetOffset(
            [MarshalAs(UnmanagedType.Interface), In] ISymUnmanagedDocument document,
            [In] int line,
            [In] int column,
            [Out] out int pRetVal);*/
            return Raw.GetOffset(document, line, column, out pRetVal);
        }

        #endregion
        #region GetRanges

        /// <summary>
        /// Given a position in a document, returns an array of start and end offset pairs that correspond to the ranges of Microsoft intermediate language (MSIL) that the position covers within this method.<para/>
        /// The array is an array of integers and has the format [start, end, start, end]. The number of range pairs is the length of the array divided by 2.
        /// </summary>
        /// <param name="document">[in] The document for which the offset is requested.</param>
        /// <param name="line">[in] The document line corresponding to the ranges.</param>
        /// <param name="column">[in] The document column corresponding to the ranges.</param>
        /// <returns>[out] A pointer to the buffer that receives the ranges.</returns>
        public int[] GetRanges(ISymUnmanagedDocument document, int line, int column)
        {
            HRESULT hr;
            int[] rangesResult;

            if ((hr = TryGetRanges(document, line, column, out rangesResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return rangesResult;
        }

        /// <summary>
        /// Given a position in a document, returns an array of start and end offset pairs that correspond to the ranges of Microsoft intermediate language (MSIL) that the position covers within this method.<para/>
        /// The array is an array of integers and has the format [start, end, start, end]. The number of range pairs is the length of the array divided by 2.
        /// </summary>
        /// <param name="document">[in] The document for which the offset is requested.</param>
        /// <param name="line">[in] The document line corresponding to the ranges.</param>
        /// <param name="column">[in] The document column corresponding to the ranges.</param>
        /// <param name="rangesResult">[out] A pointer to the buffer that receives the ranges.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetRanges(ISymUnmanagedDocument document, int line, int column, out int[] rangesResult)
        {
            /*HRESULT GetRanges(
            [MarshalAs(UnmanagedType.Interface), In]
            ISymUnmanagedDocument document,
            [In] int line,
            [In] int column,
            [In] int cRanges,
            [Out] out int pcRanges,
            [MarshalAs(UnmanagedType.LPArray), Out] int[] ranges);*/
            int cRanges = 0;
            int pcRanges;
            int[] ranges = null;
            HRESULT hr = Raw.GetRanges(document, line, column, cRanges, out pcRanges, ranges);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cRanges = pcRanges;
            ranges = new int[pcRanges];
            hr = Raw.GetRanges(document, line, column, cRanges, out pcRanges, ranges);

            if (hr == HRESULT.S_OK)
            {
                rangesResult = ranges;

                return hr;
            }

            fail:
            rangesResult = default(int[]);

            return hr;
        }

        #endregion
        #region GetSourceStartEnd

        /// <summary>
        /// Gets the start and end document positions for the source of this method. The first array position is the start, and the second array position is the end.
        /// </summary>
        /// <param name="docs">[in] The starting and ending source documents.</param>
        /// <param name="lines">[in] The starting and ending lines in the corresponding source documents.</param>
        /// <param name="columns">[in] The starting and ending columns in the corresponding source documents.</param>
        /// <returns>[out] true if positions were defined; otherwise, false.</returns>
        public int GetSourceStartEnd(ISymUnmanagedDocument[] docs, int[] lines, int[] columns)
        {
            HRESULT hr;
            int pRetVal;

            if ((hr = TryGetSourceStartEnd(docs, lines, columns, out pRetVal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pRetVal;
        }

        /// <summary>
        /// Gets the start and end document positions for the source of this method. The first array position is the start, and the second array position is the end.
        /// </summary>
        /// <param name="docs">[in] The starting and ending source documents.</param>
        /// <param name="lines">[in] The starting and ending lines in the corresponding source documents.</param>
        /// <param name="columns">[in] The starting and ending columns in the corresponding source documents.</param>
        /// <param name="pRetVal">[out] true if positions were defined; otherwise, false.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetSourceStartEnd(ISymUnmanagedDocument[] docs, int[] lines, int[] columns, out int pRetVal)
        {
            /*HRESULT GetSourceStartEnd(
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 2), In]
            ISymUnmanagedDocument[] docs,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 2), In]
            int[] lines,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 2), In]
            int[] columns,
            [Out] out int pRetVal);*/
            return Raw.GetSourceStartEnd(docs, lines, columns, out pRetVal);
        }

        #endregion
        #region GetSequencePoints

        /// <summary>
        /// Gets all the sequence points within this method.
        /// </summary>
        /// <param name="cPoints">[in] A ULONG32 that receives the size of the offsets, documents, lines, columns, endLines, and endColumns arrays.</param>
        /// <param name="offsets">[in] An array in which to store the Microsoft intermediate language (MSIL) offsets from the beginning of the method for the sequence points.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetSequencePointsResult GetSequencePoints(int cPoints, int offsets)
        {
            HRESULT hr;
            GetSequencePointsResult result;

            if ((hr = TryGetSequencePoints(cPoints, offsets, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets all the sequence points within this method.
        /// </summary>
        /// <param name="cPoints">[in] A ULONG32 that receives the size of the offsets, documents, lines, columns, endLines, and endColumns arrays.</param>
        /// <param name="offsets">[in] An array in which to store the Microsoft intermediate language (MSIL) offsets from the beginning of the method for the sequence points.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetSequencePoints(int cPoints, int offsets, out GetSequencePointsResult result)
        {
            /*HRESULT GetSequencePoints(
            [In] int cPoints,
            [Out] out int pcPoints,
            [In] ref int offsets,
            [Out, MarshalAs(UnmanagedType.LPArray)] ISymUnmanagedDocument[] documents,
            [Out, MarshalAs(UnmanagedType.LPArray)] int[] lines,
            [Out, MarshalAs(UnmanagedType.LPArray)] int[] columns,
            [Out, MarshalAs(UnmanagedType.LPArray)] int[] endLines,
            [Out, MarshalAs(UnmanagedType.LPArray)] int[] endColumns);*/
            int pcPoints;
            ISymUnmanagedDocument[] documents = null;
            int[] lines = null;
            int[] columns = null;
            int[] endLines = null;
            int[] endColumns = null;
            HRESULT hr = Raw.GetSequencePoints(cPoints, out pcPoints, ref offsets, documents, lines, columns, endLines, endColumns);

            if (hr == HRESULT.S_OK)
                result = new GetSequencePointsResult(pcPoints, documents, lines, columns, endLines, endColumns);
            else
                result = default(GetSequencePointsResult);

            return hr;
        }

        #endregion
        #endregion
    }
}