using System;
using UnityEngine;

namespace Dre0Dru.GameTime
{
    public class GlobalTimeControl : ITimeControl, IGamePause
    {
        private float _previousTimeScale;
        
        public float DeltaTime => Time.deltaTime;
        public float DeltaTimeUnscaled => Time.unscaledDeltaTime;

        public float TimeScale => Time.timeScale;

        public bool IsPaused => TimeScale == 0;

        public event IGamePause.PauseStatusChange PauseStatusChanged;

        public void SetTimeScale(float timeScale)
        {
            var wasPaused = IsPaused;
            var previousTimeScale = Time.timeScale;
                
            timeScale = Mathf.Clamp(timeScale, 0 ,Mathf.Infinity);
                
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

        public void Pause()
        {
            if (IsPaused)
            {
                return;
            }
            
            _previousTimeScale = TimeScale;

            SetTimeScale(0.0f);
            
            PauseStatusChanged?.Invoke(true);
        }

        public void Unpause()
        {
            if (!IsPaused)
            {
                return;
            }
            
            SetTimeScale(_previousTimeScale);
            
            PauseStatusChanged?.Invoke(false);
        }
    }
}
