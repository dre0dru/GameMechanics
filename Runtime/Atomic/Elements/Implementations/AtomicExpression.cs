using System;
using System.Collections.Generic;
using Atomic.Elements;

namespace GameEngine
{
    [Serializable]
    public abstract class AtomicExpression<T> : IAtomicExpression<T>
    {
        protected readonly List<IAtomicValue<T>> Members = new();

        public IAtomicExpression<T> AddMember(IAtomicValue<T> member)
        {
            Members.Add(member);
            return this;
        }

        public IAtomicExpression<T> RemoveMember(IAtomicValue<T> member)
        {
            Members.Remove(member);
            return this;
        }
        
        public abstract T Invoke();
    }
}