using System;
using UnityEngine;

namespace Dre0Dru.GameStats.Modifiers.Ordered
{
    [Serializable]
    public struct OrderedModifier<TValue>
    {
        [SerializeField]
        public int Order;

        [SerializeField]
        public TValue Value;
    }
}
