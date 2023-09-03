using UnityEngine;

namespace Dre0Dru.GameTime
{
    public class LocalTimeControlComponent : MonoBehaviour, ITimeControl
    {
        [SerializeField]
        private LocalTimeControl _localTimeControl;

        public float DeltaTime => _localTimeControl.DeltaTime;
        public float DeltaTimeUnscaled => _localTimeControl.DeltaTimeUnscaled;
        public float TimeScale => _localTimeControl.TimeScale;

        public void SetTimeScale(float timeScale)
        {
            _localTimeControl.SetTimeScale(timeScale);
        }
    }
}
