using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Dre0Dru.Projectiles.Patterns
{
    [Serializable]
    public struct LinePattern : IShapePattern
    {
        [Min(0)]
        public float Length;

        [Min(0)]
        public float RandomShift;

        [Min(0)]
        public float OffsetY;

        [Min(1)]
        [SerializeField]
        private int _count;

        [Min(0f)]
        [SerializeField]
        private float _delay;

        public int Count
        {
            readonly get => _count;
            set => _count = value;
        }

        public float Delay
        {
            readonly get => _delay;
            set => _delay = value;
        }

        public PatternOutput CalculateOutput(int index)
        {
            var offsetX = (Random.value * 2 - 1) * RandomShift;

            if (Count > 1)
            {
                var offsetStep = Length / (Count - 1);
                var recenterOffset = Length * 0.5f;

                offsetX += offsetStep * index - recenterOffset;
            }

            return new PatternOutput()
            {
                Angle = 0,
                Offset = new Vector2(offsetX, OffsetY)
            };
        }
    }
}
