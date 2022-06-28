using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a lexical scope within a method.
    /// </summary>
    public class SymUnmanagedScope : ComObject<ISymUnmanagedScope>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymUnmanagedScope"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SymUnmanagedScope(ISymUnmanagedScope raw) : base(raw)
        {
        }

        #region ISymUnmanagedScope
        #region Method

        /// <summary>
        /// Gets the method that contains this scope.
        /// </summary>
        public SymUnmanagedMethod Method
        {
            get
            {
                SymUnmanagedMethod pRetValResult;
                TryGetMethod(out pRetValResult).ThrowOnNotOK();

                return pRetValResult;
            }
        }

        /// <summary>
        /// Gets the method that contains this scope.
        /// </summary>
        /// <param name="pRetValResult">[out] A pointer to the returned <see cref="ISymUnmanagedMethod"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetMethod(out SymUnmanagedMethod pRetValResult)
        {
            /*HRESULT GetMethod([Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedMethod pRetVal);*/
            ISymUnmanagedMethod pRetVal;
            HRESULT hr = Raw.GetMethod(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = new SymUnmanagedMethod(pRetVal);
            else
                pRetValResult = default(SymUnmanagedMethod);

            return hr;
        }

        #endregion
        #region Parent

        /// <summary>
        /// Gets the parent scope of this scope.
        /// </summary>
        public SymUnmanagedScope Parent
        {
            get
            {
                SymUnmanagedScope pRetValResult;
                TryGetParent(out pRetValResult).ThrowOnNotOK();

                return pRetValResult;
            }
        }

        /// <summary>
        /// Gets the parent scope of this scope.
        /// </summary>
        /// <param name="pRetValResult">[out] A pointer to the returned <see cref="ISymUnmanagedScope"/> interface.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetParent(out SymUnmanagedScope pRetValResult)
        {
            /*HRESULT GetParent([Out, MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedScope pRetVal);*/
            ISymUnmanagedScope pRetVal;
            HRESULT hr = Raw.GetParent(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = new SymUnmanagedScope(pRetVal);
            else
                pRetValResult = default(SymUnmanagedScope);

            return hr;
        }

        #endregion
        #region Children

        /// <summary>
        /// Gets the children of this scope.
        /// </summary>
        public ISymUnmanagedScope[] Children
        {
            get
            {
                ISymUnmanagedScope[] childrenResult;
                TryGetChildren(out childrenResult).ThrowOnNotOK();

                return childrenResult;
            }
        }

        /// <summary>
        /// Gets the children of this scope.
        /// </summary>
        /// <param name="childrenResult">[out] The returned array of children.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetChildren(out ISymUnmanagedScope[] childrenResult)
        {
            /*HRESULT GetChildren(
            [In] int cChildren,
            [Out] out int pcChildren,
            [Out, MarshalAs(UnmanagedType.LPArray)] ISymUnmanagedScope[] children);*/
            int cChildren = 0;
            int pcChildren;
            ISymUnmanagedScope[] children = null;
            HRESULT hr = Raw.GetChildren(cChildren, out pcChildren, children);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cChildren = pcChildren;
            children = new ISymUnmanagedScope[pcChildren];
            hr = Raw.GetChildren(cChildren, out pcChildren, children);

            if (hr == HRESULT.S_OK)
            {
                childrenResult = children;

                return hr;
            }

            fail:
            childrenResult = default(ISymUnmanagedScope[]);

            return hr;
        }

        #endregion
        #region StartOffset

        /// <summary>
        /// Gets the start offset for this scope.
        /// </summary>
        public int StartOffset
        {
            get
            {
                int pRetVal;
                TryGetStartOffset(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets the start offset for this scope.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that contains the starting offset.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetStartOffset(out int pRetVal)
        {
            /*HRESULT GetStartOffset([Out] out int pRetVal);*/
            return Raw.GetStartOffset(out pRetVal);
        }

        #endregion
        #region EndOffset

        /// <summary>
        /// Gets the end offset for this scope.
        /// </summary>
        public int EndOffset
        {
            get
            {
                int pRetVal;
                TryGetEndOffset(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets the end offset for this scope.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the end offset.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetEndOffset(out int pRetVal)
        {
            /*HRESULT GetEndOffset([Out] out int pRetVal);*/
            return Raw.GetEndOffset(out pRetVal);
        }

        #endregion
        #region LocalCount

        /// <summary>
        /// Gets a count of the local variables defined within this scope.
        /// </summary>
        public int LocalCount
        {
            get
            {
                int pRetVal;
                TryGetLocalCount(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets a count of the local variables defined within this scope.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the count of local variables.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetLocalCount(out int pRetVal)
        {
            /*HRESULT GetLocalCount([Out] out int pRetVal);*/
            return Raw.GetLocalCount(out pRetVal);
        }

        #endregion
        #region Locals

        /// <summary>
        /// Gets the local variables defined within this scope.
        /// </summary>
        public ISymUnmanagedVariable[] Locals
        {
            get
            {
                ISymUnmanagedVariable[] localsResult;
                TryGetLocals(out localsResult).ThrowOnNotOK();

                return localsResult;
            }
        }

        /// <summary>
        /// Gets the local variables defined within this scope.
        /// </summary>
        /// <param name="localsResult">[out] The array that receives the local variables.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetLocals(out ISymUnmanagedVariable[] localsResult)
        {
            /*HRESULT GetLocals(
            [In] int cLocals,
            [Out] out int pcLocals,
            [Out, MarshalAs(UnmanagedType.LPArray)] ISymUnmanagedVariable[] locals);*/
            int cLocals = 0;
            int pcLocals;
            ISymUnmanagedVariable[] locals = null;
            HRESULT hr = Raw.GetLocals(cLocals, out pcLocals, locals);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cLocals = pcLocals;
            locals = new ISymUnmanagedVariable[pcLocals];
            hr = Raw.GetLocals(cLocals, out pcLocals, locals);

            if (hr == HRESULT.S_OK)
            {
                localsResult = locals;

                return hr;
            }

            fail:
            localsResult = default(ISymUnmanagedVariable[]);

            return hr;
        }

        #endregion
        #region Namespaces

        /// <summary>
        /// Gets the namespaces that are being used within this scope.
        /// </summary>
        public ISymUnmanagedNamespace[] Namespaces
        {
            get
            {
                ISymUnmanagedNamespace[] namespacesResult;
                TryGetNamespaces(out namespacesResult).ThrowOnNotOK();

                return namespacesResult;
            }
        }

        /// <summary>
        /// Gets the namespaces that are being used within this scope.
        /// </summary>
        /// <param name="namespacesResult">[out] The array that receives the namespaces.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetNamespaces(out ISymUnmanagedNamespace[] namespacesResult)
        {
            /*HRESULT GetNamespaces(
            [In] int cNameSpaces,
            [Out] out int pcNameSpaces,
            [Out, MarshalAs(UnmanagedType.LPArray)] ISymUnmanagedNamespace[] namespaces);*/
            int cNameSpaces = 0;
            int pcNameSpaces;
            ISymUnmanagedNamespace[] namespaces = null;
            HRESULT hr = Raw.GetNamespaces(cNameSpaces, out pcNameSpaces, namespaces);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cNameSpaces = pcNameSpaces;
            namespaces = new ISymUnmanagedNamespace[pcNameSpaces];
            hr = Raw.GetNamespaces(cNameSpaces, out pcNameSpaces, namespaces);

            if (hr == HRESULT.S_OK)
            {
                namespacesResult = namespaces;

                return hr;
            }

            fail:
            namespacesResult = default(ISymUnmanagedNamespace[]);

            return hr;
        }

        #endregion
        #endregion
        #region ISymUnmanagedScope2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ISymUnmanagedScope2 Raw2 => (ISymUnmanagedScope2) Raw;

        #region ConstantCount

        /// <summary>
        /// Gets a count of the constants defined within this scope.
        /// </summary>
        public int ConstantCount
        {
            get
            {
                int pRetVal;
                TryGetConstantCount(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets a count of the constants defined within this scope.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the constants.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetConstantCount(out int pRetVal)
        {
            /*HRESULT GetConstantCount([Out] out int pRetVal);*/
            return Raw2.GetConstantCount(out pRetVal);
        }

        #endregion
        #region Constants

        /// <summary>
        /// Gets the local constants defined within this scope.
        /// </summary>
        public ISymUnmanagedConstant[] Constants
        {
            get
            {
                ISymUnmanagedConstant[] constantsResult;
                TryGetConstants(out constantsResult).ThrowOnNotOK();

                return constantsResult;
            }
        }

        /// <summary>
        /// Gets the local constants defined within this scope.
        /// </summary>
        /// <param name="constantsResult">[out] The buffer that stores the constants.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetConstants(out ISymUnmanagedConstant[] constantsResult)
        {
            /*HRESULT GetConstants([In] int cConstants, [Out] out int pcConstants, [MarshalAs(UnmanagedType.LPArray), Out] ISymUnmanagedConstant[] constants);*/
            int cConstants = 0;
            int pcConstants;
            ISymUnmanagedConstant[] constants = null;
            HRESULT hr = Raw2.GetConstants(cConstants, out pcConstants, constants);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cConstants = pcConstants;
            constants = new ISymUnmanagedConstant[pcConstants];
            hr = Raw2.GetConstants(cConstants, out pcConstants, constants);

            if (hr == HRESULT.S_OK)
            {
                constantsResult = constants;

                return hr;
            }

            fail:
            constantsResult = default(ISymUnmanagedConstant[]);

            return hr;
        }

        #endregion
        #endregion
    }
}