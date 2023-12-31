using System;
using Sirenix.OdinInspector;

namespace Atomic.Elements
{
    [Serializable]
    public sealed class AtomicFunction<T> : IAtomicFunction<T>
    {
        private Func<T> _func;

        [ShowInInspector, ReadOnly]
        public T Value => _func != null ? _func.Invoke() : default;

        public AtomicFunction()
        {
        }

        public AtomicFunction(Func<T> func)
        {
            _func = func;
        }

        public void Compose(Func<T> func)
        {
            _func = func;
        }

        public T Invoke()
        {
            return _func != null ? _func.Invoke() : default;
        }
    }

    [Serializable]
    public sealed class AtomicFunction<T, TR> : IAtomicFunction<T, TR>
    {
        private Func<T, TR> _func;

        public AtomicFunction()
        {
        }

        public AtomicFunction(Func<T, TR> func)
        {
            _func = func;
        }

        public void Compose(Func<T, TR> func)
        {
            _func = func;
        }

        [Button]
        public TR Invoke(T args)
        {
            return _func.Invoke(args);
        }
    }
}