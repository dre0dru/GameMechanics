using System.Collections.Generic;

namespace Dre0Dru.GameplayFlags
{
    public static class GameplayFlagsExtensions
    {
        public static bool HasNone<TFlag>(this IGameplayFlagContainer<TFlag> container, IEnumerable<TFlag> flags)
        {
            return !container.HasAny(flags);
        }

        public static bool HasNone<TFlag>(this IGameplayFlagContainer<TFlag> container, GameplayFlagQuery<TFlag> flagsQuery)
        {
            return !container.HasAny(flagsQuery.NoneFlags);
        }

        public static bool HasAll<TFlag>(this IGameplayFlagContainer<TFlag> container, GameplayFlagQuery<TFlag> flagsQuery)
        {
            return container.HasAll(flagsQuery.AllFlags);
        }

        public static bool HasAny<TFlag>(this IGameplayFlagContainer<TFlag> container, GameplayFlagQuery<TFlag> flagsQuery)
        {
            return container.HasAny(flagsQuery.AnyFlags);
        }
    }
}
