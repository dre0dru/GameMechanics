namespace Abilities
{
    public class AutoProcessor : ISequenceProcessor
    {
        private readonly IAbilitySequence _sequence;

        public AutoProcessor(IAbilitySequence sequence)
        {
            _sequence = sequence;
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
            }

            if (_sequence.Status == SequenceStatus.CanBeFinished)
            {
                _sequence.Finish();
            }

            return _sequence.Status;
        }
    }
}
