using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.GameplayFlags
{
    public class GameplayFlagsContainerComponent<TFlag> : MonoBehaviour, IGameplayFlagContainer<TFlag>
    {
        [SerializeField]
        private GameplayFlagsContainer<TFlag> _container;

        public event Action<TFlag> FlagSet
        {
            add => _container.FlagSet += value;
            remove => _container.FlagSet -= value;
        }

        public event Action<TFlag> FlagUnset
        {
            add => _container.FlagUnset += value;
            remove => _container.FlagUnset -= value;
        }

        public void AddFlag(TFlag flag)
        {
            _container.AddFlag(flag);
        }

        public bool RemoveFlag(TFlag flag)
        {
            return _container.RemoveFlag(flag);
        }

        public void SetFlag(TFlag flag, int count)
        {
            _container.SetFlag(flag, count);
        }

        public void ResetFlag(TFlag flag)
        {
            _container.ResetFlag(flag);
        }

        public bool HasFlag(TFlag flag)
        {
            return _container.HasFlag(flag);
        }

        public bool HasFlag(TFlag flag, out int count)
        {
            return _container.HasFlag(flag, out count);
        }

        public bool HasAny(IEnumerable<TFlag> flags)
        {
            return _container.HasAny(flags);
        }

        public bool HasAll(IEnumerable<TFlag> flags)
        {
            return _container.HasAll(flags);
        }
    }
}
