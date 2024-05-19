using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.GameplayFlags
{
    //TODO native collections to reduce allocations
    [Serializable]
    public struct GameplayFlagQuery<TFlag>
    {
        [SerializeField]
        private List<TFlag> _anyFlags;

        [SerializeField]
        private List<TFlag> _allFlags;

        [SerializeField]
        private List<TFlag> _noneFlags;

        public IEnumerable<TFlag> AnyFlags => _anyFlags;

        public IEnumerable<TFlag> AllFlags => _allFlags;

        public IEnumerable<TFlag> NoneFlags => _noneFlags;

        public GameplayFlagQuery(List<TFlag> anyFlags, List<TFlag> allFlags, List<TFlag> noneFlags)
        {
            _anyFlags = anyFlags;
            _allFlags = allFlags;
            _noneFlags = noneFlags;
        }
    }
}
