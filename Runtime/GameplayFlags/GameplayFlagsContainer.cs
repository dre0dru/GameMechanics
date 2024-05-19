using System;
using System.Collections.Generic;
using Dre0Dru.Collections;
using UnityEngine;

namespace Dre0Dru.GameplayFlags
{
    [Serializable]
    public class GameplayFlagsContainer<TFlag> : IGameplayFlagContainer<TFlag>
    {
        [SerializeField]
        private UDictionary<TFlag, int> _flags;

        public event Action<TFlag> FlagSet;
        public event Action<TFlag> FlagUnset;

        public void AddFlag(TFlag flag)
        {
            if (!_flags.TryGetValue(flag, out var count))
            {
                _flags[flag] = 0;
            }

            var newCount = count + 1;
            _flags[flag]= newCount;

            if (count == 0 && newCount > 0)
            {
                FlagSet?.Invoke(flag);
            }
        }

        public bool RemoveFlag(TFlag flag)
        {
            if (!_flags.TryGetValue(flag, out var count))
            {
                return false;
            }

            var newCount = Mathf.Max(0, count - 1);
            _flags[flag] = newCount;

            if (count > 0 && newCount == 0)
            {
                FlagUnset?.Invoke(flag);
            }

            return true;
        }

        public void SetFlag(TFlag flag, int count)
        {
            var previousCount = _flags.GetValueOrDefault(flag, 0);

            _flags[flag] = count;

            if (previousCount == 0 && count > 0)
            {
                FlagSet?.Invoke(flag);
            }

            if (previousCount > 0 && count == 0)
            {
                FlagUnset?.Invoke(flag);
            }
        }

        public void ResetFlag(TFlag flag)
        {
            SetFlag(flag, 0);
        }

        public bool HasFlag(TFlag flag)
        {
            return HasFlag(flag, out var count) && count > 0;
        }

        public bool HasFlag(TFlag flag, out int count)
        {
            return _flags.TryGetValue(flag, out count);
        }

        public bool HasAny(IEnumerable<TFlag> flags)
        {
            foreach (var flag in flags)
            {
                if (HasFlag(flag))
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasAll(IEnumerable<TFlag> flags)
        {
            foreach (var flag in flags)
            {
                if (!HasFlag(flag))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
