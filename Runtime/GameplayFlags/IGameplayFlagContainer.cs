using System;
using System.Collections.Generic;

namespace Dre0Dru.GameplayFlags
{
    //https://dev.epicgames.com/documentation/en-us/unreal-engine/using-gameplay-tags-in-unreal-engine
    //TODO hierarchical flags
    public interface IGameplayFlagContainer<TFlag>
    {
        event Action<TFlag> FlagSet;
        event Action<TFlag> FlagUnset;

        void AddFlag(TFlag flag);
        bool RemoveFlag(TFlag flag);
        void SetFlag(TFlag flag, int count);
        void ResetFlag(TFlag flag);

        bool HasFlag(TFlag flag);
        bool HasFlag(TFlag flag, out int count);
        bool HasAny(IEnumerable<TFlag> flags);
        bool HasAll(IEnumerable<TFlag> flags);
    }
}
