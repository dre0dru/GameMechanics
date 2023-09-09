using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Dre0Dru.Projectiles.Patterns
{
    //TODO 3D variant https://catlikecoding.com/unity/tutorials/basics/mathematical-surfaces/
    [Serializable]
    public struct ArcPattern : IShapePattern<float>
    {
        [Range(0.0f, 360.0f)]
        public float Arc;

        [Range(0.0f, 360.0f)]
        public float RandomSpread;

        [Min(1)]
        public int Count;

        [Min(0)]
        public float Delay;

        int IShapePattern.Count => Count;
        float IShapePattern.Delay => Delay;

        public float CalculateOutput(int index)
        {
            var angleStep = Arc / Count;
            var recenterAngle = (Arc - angleStep) * 0.5f;

            return angleStep * index - recenterAngle + (Random.value * 2 - 1) * RandomSpread;
        }
    }
}
