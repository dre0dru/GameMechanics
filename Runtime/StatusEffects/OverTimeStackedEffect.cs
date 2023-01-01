using System;
using UnityEngine;

namespace Dre0Dru.StatusEffects
{
    [Serializable]
    public abstract class OverTimeStackedEffect : StackedEffect
    {
        [SerializeField]
        private float _totalDuration;

        [SerializeField]
        private int _triggeredTimes;

        public float TotalDuration => _totalDuration;

        public int TriggeredTimes => _triggeredTimes;

        protected override void OnApply(GameObject target)
        {
            _totalDuration = 0;
            _triggeredTimes = 0;
        }

        protected override void OnTick(float deltaTime)
        {
            _totalDuration += deltaTime;

            var trigger = _totalDuration / Properties.Frequency;

            if (trigger > _triggeredTimes + 1)
            {
                _triggeredTimes++;

                OnOverTimeTrigger();
            }
        }


        protected abstract void OnOverTimeTrigger();
    }
}
