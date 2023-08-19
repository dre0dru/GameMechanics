using System;
using UnityEngine;

namespace Dre0Dru.GameTime
{
    [Serializable]
    public class LocalTimeControl : ITimeControl
    {
        [SerializeField]
        private float _timeScale = 1;

        public float DeltaTime => Time.deltaTime * TimeScale;

        public float TimeScale
        {
            get => _timeScale;
            set => _timeScale = value;
        }
    }
}
