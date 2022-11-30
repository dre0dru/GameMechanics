using UnityEngine;
using UnityEngine.Scripting;

namespace Dre0Dru.GamePause
{
    public class TimeScaleGamePause : IGamePause
    {
        public event IGamePause.OnPauseStatusChange PauseStatusChange;

        public bool IsPaused { get; private set; }

        private float _lastTimeScale = 1.0f;

        [RequiredMember]
        public TimeScaleGamePause()
        {
        
        }
        
        public void Pause()
        {
            if (IsPaused)
            {
                return;
            }
            
            _lastTimeScale = Time.timeScale;
            Time.timeScale = 0.0f;

            IsPaused = true;
            PauseStatusChange?.Invoke(IsPaused);
        }

        public void Unpause()
        {
            if (!IsPaused)
            {
                return;
            }
            
            Time.timeScale = _lastTimeScale;

            IsPaused = false;
            PauseStatusChange?.Invoke(IsPaused);
        }
    }
}
