﻿using System.Collections;
using System.Collections.Generic;

namespace ClrDebug
{
    /// <summary>
    /// Implements <see cref="ICorDebugEnum"/> methods, and enumerates arrays of objects by their relative virtual addresses (RVAs).
    /// </summary>
    public class CorDebugObjectEnum : IEnumerable<CORDB_ADDRESS>, IEnumerator<CORDB_ADDRESS>
    {
        public ICorDebugObjectEnum Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugObjectEnum"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugObjectEnum(ICorDebugObjectEnum raw)
        {
            Raw = raw;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(CORDB_ADDRESS);
        }

        public CorDebugObjectEnum Clone()
        {
            if (Raw == null)
                return this;

            ICorDebugEnum clone;
            Raw.Clone(out clone);

            return new CorDebugObjectEnum((ICorDebugObjectEnum) clone);
        }

        #region IEnumerable

        public IEnumerator<CORDB_ADDRESS> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public CORDB_ADDRESS Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            CORDB_ADDRESS result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result;
            else
                Current = default(CORDB_ADDRESS);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
