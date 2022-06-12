using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// A subclass of <see cref="ICorDebugReferenceValue"/> that represents a reference value to which the debugger has created a handle for garbage collection.
    /// </summary>
    /// <remarks>
    /// An <see cref="ICorDebugReferenceValue"/> object is invalidated by a break in the execution of debugged code. An <see cref="ICorDebugHandleValue"/>
    /// maintains its reference through breaks and continuations, until it is explicitly released.
    /// </remarks>
    public class CorDebugHandleValue : CorDebugReferenceValue
    {
        public CorDebugHandleValue(ICorDebugHandleValue raw) : base(raw)
        {
        }

        #region ICorDebugHandleValue

        public new ICorDebugHandleValue Raw => (ICorDebugHandleValue) base.Raw;

        #region GetHandleType

        /// <summary>
        /// Gets a value that indicates the kind of handle referenced by this <see cref="ICorDebugHandleValue"/> object.
        /// </summary>
        public CorDebugHandleType HandleType
        {
            get
            {
                HRESULT hr;
                CorDebugHandleType pType;

                if ((hr = TryGetHandleType(out pType)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pType;
            }
        }

        /// <summary>
        /// Gets a value that indicates the kind of handle referenced by this <see cref="ICorDebugHandleValue"/> object.
        /// </summary>
        /// <param name="pType">[out] A pointer to a value of the <see cref="CorDebugHandleType"/> enumeration that indicates the type of this handle.</param>
        public HRESULT TryGetHandleType(out CorDebugHandleType pType)
        {
            /*HRESULT GetHandleType(out CorDebugHandleType pType);*/
            return Raw.GetHandleType(out pType);
        }

        #endregion
        #region Dispose

        /// <summary>
        /// Releases the handle referenced by this <see cref="ICorDebugHandleValue"/> object without explicitly releasing the interface pointer.
        /// </summary>
        public void Dispose()
        {
            HRESULT hr;

            if ((hr = TryDispose()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Releases the handle referenced by this <see cref="ICorDebugHandleValue"/> object without explicitly releasing the interface pointer.
        /// </summary>
        public HRESULT TryDispose()
        {
            /*HRESULT Dispose();*/
            return Raw.Dispose();
        }

        #endregion
        #endregion
    }
}