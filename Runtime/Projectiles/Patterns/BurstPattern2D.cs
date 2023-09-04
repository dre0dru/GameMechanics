using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Dre0Dru.Projectiles.Patterns
{
    //TODO 3D variant https://catlikecoding.com/unity/tutorials/basics/mathematical-surfaces/
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

        public readonly float AngleStep => Arc / Count;

        public readonly float RecenterAngle => (Arc - AngleStep) * 0.5f;
        
        public readonly float CalculateAngle2D(int index)
        {
            var randomSpread = Random.value * RandomSpread;

            return AngleStep * index + randomSpread - RecenterAngle;
        }
        
        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }
        
        public struct Enumerator
        {
            private readonly BurstPattern2D _burstPattern2D;
            private int _currentIndex;

            public Enumerator (BurstPattern2D burstPattern2D)
            {
                _burstPattern2D = burstPattern2D;
                _currentIndex = -1;
            }

            public float Current => _burstPattern2D.CalculateAngle2D(_currentIndex);

            public bool MoveNext () {
                return ++_currentIndex < _burstPattern2D.Count;
            }

            public void Reset()
            {
                _currentIndex = -1;
            }
        }
    }
}
