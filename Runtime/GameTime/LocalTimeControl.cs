using System;
using UnityEngine;

namespace Dre0Dru.GameTime
{
    //TODO tokens with values linked to specific time control? for polling
    [Serializable]
    public class LocalTimeControl : ITimeControl
    {
        [SerializeField]
        private float _timeScale = 1;

        public float DeltaTime => Time.deltaTime * TimeScale;
        public float DeltaTimeUnscaled => Time.deltaTime;

        public float TimeScale => _timeScale;

        public void SetTimeScale(float timeScale)
        {
            _timeScale = timeScale;
        }
    }
}
