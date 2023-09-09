using System;
using Dre0Dru.GameTime;
using UnityEngine;

namespace Dre0Dru.Projectiles.Patterns
{
    //TODO composite processor
    [Serializable]
    public class PatternProcessor<TPattern, TOutput>
        where TPattern : IShapePattern<TOutput>
    {
        [SerializeField]
        private TPattern _pattern;

        [SerializeField]
        private DeltaTimer _timer = new DeltaTimer();

        [SerializeField]
        private int _currentIndex;

        public TPattern Pattern
        {
            set
            {
                _pattern = value;
                _timer.Reset();
                _currentIndex = 0;
            }
        }

        public bool HasFinished => _currentIndex >= _pattern.Count;

        public bool Process(float dt, out int index, out TOutput output)
        {
            index = default;
            output = default;

            _timer.Process(dt);

            if (_timer.HasFinished && !HasFinished)
            {
                index = _currentIndex;
                output = _pattern.CalculateOutput(index);

                _currentIndex++;
                _timer.Reset(_pattern.Delay);

                return true;
            }

            return false;
        }
    }
}
