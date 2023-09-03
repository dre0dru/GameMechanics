using System;
using UnityEngine;

namespace Dre0Dru.Projectiles.Patterns
{
    //TODO 3D variant
    [Serializable]
    public struct BurstPattern2D
    {
        [Range(0, 360)]
        public float Arc;
        
        [Range(0, 360)]
        public float RandomSpread;
        
        [Min(1)]
        public int Count;

        [Min(0f)]
        public float Delay;

        public float AngleStep => Arc / Count;

        public float RecenterAngle => (Arc - AngleStep) * 0.5f;
    }
}
