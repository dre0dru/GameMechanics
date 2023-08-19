using System;
using UnityEngine;

namespace Dre0Dru.GameTime
{
    public class GlobalTimeControl : ITimeControl, IGamePause
    {
        private float _previousTimeScale;
        
        public float DeltaTime => Time.deltaTime;

        public float TimeScale
        {
            get => Time.timeScale;
            set
            {
                var wasPaused = IsPaused;
                var previousTimeScale = Time.timeScale;
                
                var timeScale = Mathf.Clamp(value, 0 ,Mathf.Infinity);
                
                Time.timeScale = timeScale;

                if (!wasPaused && timeScale == 0)
                {
                    _previousTimeScale = previousTimeScale;
                    PauseStatusChanged?.Invoke(true);
                }

                if (wasPaused && timeScale > 0)
                {
                    PauseStatusChanged?.Invoke(false);
                }
            }
        }

        public bool IsPaused => TimeScale == 0;
        
        public event IGamePause.PauseStatusChange PauseStatusChanged;

        public void Pause()
        {
            if (IsPaused)
            {
                return;
            }
            
            _previousTimeScale = TimeScale;

            TimeScale = 0.0f;
            
            PauseStatusChanged?.Invoke(true);
        }

        public void Unpause()
        {
            if (!IsPaused)
            {
                return;
            }
            
            TimeScale = _previousTimeScale;
            PauseStatusChanged?.Invoke(false);
        }
    }
}
