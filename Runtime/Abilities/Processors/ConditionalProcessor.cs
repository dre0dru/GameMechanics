using Atomic.Elements;

namespace Abilities
{
    public class ConditionalProcessor : ISequenceProcessor
    {
        private readonly IAbilitySequence _sequence;
        private readonly IAtomicValue<bool> _progressCondition;
        private readonly IAtomicValue<bool> _finishCondition;

        public ConditionalProcessor(IAbilitySequence sequence, IAtomicValue<bool> progressCondition,
            IAtomicValue<bool> finishCondition)
        {
            _sequence = sequence;
            _progressCondition = progressCondition;
            _finishCondition = finishCondition;
        }

        public SequenceStatus Process(float dt)
        {
            if (_sequence.Status == SequenceStatus.Idle)
            {
                _sequence.Begin();
            }

            if (_sequence.Status == SequenceStatus.InProgress)
            {
                _sequence.Process(dt);

                if (!_progressCondition.Value)
                {
                    _sequence.Interrupt();
                }
            }

            if (_sequence.Status == SequenceStatus.CanBeFinished)
            {
                _sequence.Process(dt);

                if (_finishCondition.Value)
                {
                    _sequence.Finish();
                }
            }

            return _sequence.Status;
        }
    }
}
