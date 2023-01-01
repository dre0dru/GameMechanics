using System;
using UnityEngine;

namespace Dre0Dru.StatusEffects
{
    [Serializable]
    public struct StackedEffectProperties
    {
        [SerializeField]
        private int _maxStack;

        [SerializeField]
        private bool _renewOnMaxStack;

        [SerializeField]
        private float _duration;

        [SerializeField]
        private float _frequency;

        public float Frequency => _frequency;
        public float Duration => _duration;
        public int MaxStack => _maxStack;
        public bool RenewOnMaxStack => _renewOnMaxStack;
    }
}
