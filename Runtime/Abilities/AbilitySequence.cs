using System.Collections.Generic;
using Dre0Dru.Values;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Abilities
{
    //TODO add looping when progress goes beyond 1.0f
    public class AbilitySequence : IAbilitySequence
    {
        [ReadOnly]
        [ShowInInspector]
        private readonly List<IAbilityTrack> _abilityTracks;

        [ReadOnly]
        [ShowInInspector]
        private readonly float _duration;

        [ReadOnly]
        [ShowInInspector]
        private readonly float _finishRange;

        [ReadOnly]
        [ShowInInspector]
        private ValueChange<float> _normalizedProgress = new();

        [ReadOnly]
        [ShowInInspector]
        private float _currentDuration;

        [ReadOnly]
        [ShowInInspector]
        private SequenceStatus _sequenceStatus;

        public SequenceStatus Status => _sequenceStatus;

        public AbilitySequence(IEnumerable<IAbilityTrack> abilityTracks, float duration, float finishRange = 1.0f)
        {
            _abilityTracks = new List<IAbilityTrack>(abilityTracks);
            _duration = Mathf.Max(duration, float.Epsilon);
            _finishRange = finishRange;
        }

        public void Begin()
        {
            Debug.Log($"[Abilities] Sequence began");
            _sequenceStatus = SequenceStatus.InProgress;

            foreach (var abilityTrack in _abilityTracks)
            {
                abilityTrack.Begin();
            }
        }

        public void Process(float dt)
        {
            _currentDuration += dt;
            _normalizedProgress.CurrentValue = Mathf.Clamp01(_currentDuration / _duration);

            if (!_normalizedProgress.HasValueChanged())
            {
                return;
            }            
            
            if (_normalizedProgress.CurrentValue >= _finishRange)
            {
                _sequenceStatus = SequenceStatus.CanBeFinished;
            }

            foreach (var abilityTrack in _abilityTracks)
            {
                abilityTrack.Process(_normalizedProgress);
            }
        }

        public void Interrupt()
        {
            Debug.Log($"[Abilities] Sequence interrupted");

            _sequenceStatus = SequenceStatus.Interrupted;

            foreach (var abilityTrack in _abilityTracks)
            {
                abilityTrack.Interrupt();
            }
        }

        public void Finish()
        {
            Debug.Log($"[Abilities] Sequence finished");

            _sequenceStatus = SequenceStatus.Finished;

            foreach (var abilityTrack in _abilityTracks)
            {
                abilityTrack.Finish();
            }
        }

        public void Reset()
        {
            _currentDuration = 0;
            _normalizedProgress.Reset();
            _sequenceStatus = SequenceStatus.Idle;
        }
    }
}
