using System;
using UnityEngine;

namespace Dre0Dru.GameTime
{
    [Serializable]
    public class DeltaTimer
    {
        [SerializeField]
        private float _time;

        public float Time => _time;

        public bool HasFinished => _time <= 0;

        public DeltaTimer(float targetTime = default)
        {
            Reset(targetTime);
        }

        public void Process(float deltaTime)
        {
            _time -= deltaTime;
        }

        public void Reset(float targetTime = default)
        {
            _time = targetTime;
        }
    }
}
