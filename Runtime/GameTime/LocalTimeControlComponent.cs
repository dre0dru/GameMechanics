using UnityEngine;

namespace Dre0Dru.GameTime
{
    public class LocalTimeControlComponent : MonoBehaviour, ITimeControl
    {
        [SerializeField]
        private LocalTimeControl _localTimeControl;

        public float DeltaTime => _localTimeControl.DeltaTime;

        public float TimeScale
        {
            get => _localTimeControl.TimeScale;
            set => _localTimeControl.TimeScale = value;
        }
    }
}
