using System;
using Dre0Dru.MathExtensions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Dre0Dru.Projectiles.Patterns
{
    //TODO 3D variant https://catlikecoding.com/unity/tutorials/basics/mathematical-surfaces/
    [Serializable]
    public struct ArcPattern : IShapePattern
    {
        [Range(0.0f, 360.0f)]
        public float Arc;

        [Range(0.0f, 360.0f)]
        public float RandomSpread;

        [Min(0)]
        public float Offset;

        [Min(1)]
        [SerializeField]
        private int _count;

        [Min(0)]
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
            var angleStep = Arc / Count;
            var recenterAngle = (Arc - angleStep) * 0.5f;

            var angle = angleStep * index - recenterAngle + (Random.value * 2 - 1) * RandomSpread;
            var offset = VectorExtensions.CalculateDirectionFromAngle2D(angle) * Offset;

            return new PatternOutput()
            {
                Angle = angle,
                Offset = offset
            };
        }
    }
}
