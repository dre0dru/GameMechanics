using System.Collections.Generic;

namespace Abilities
{
    //TODO with options to fail others on interrupt
    public class SequentialProcessor : ISequenceProcessor
    {
        private readonly IList<ISequenceProcessor> _processors;

        public SequentialProcessor(params ISequenceProcessor[] processors)
        {
            _processors = processors;
        }

        public SequenceStatus Process(float dt)
        {
            for (int i = 0; i < _processors.Count; i++)
            {
                var processor = _processors[i];
                var sequenceStatus = processor.Process(dt);

                if (sequenceStatus == SequenceStatus.Interrupted ||
                    sequenceStatus != SequenceStatus.Finished)
                {
                    return sequenceStatus;
                }
            }

            return SequenceStatus.InProgress;
        }
    }
}
