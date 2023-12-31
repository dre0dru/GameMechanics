using System;
using UnityEngine;

namespace Atomic.Elements
{
    [Serializable]
    public sealed class AtomicValue<T> : IAtomicValue<T>
    {
        public T Value => _value;

        [SerializeField]
        private T _value;

        public AtomicValue(T value = default)
        {
            _value = value;
        }
    }
}
