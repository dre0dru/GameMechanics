using System;
using UnityEngine;

namespace Dre0Dru.GameInput
{
    [Serializable]
    public class TimeInputBuffer
    {
        [SerializeField]
        private float _timeOut;

        [SerializeField]
        private float _bufferedTime = float.MinValue;

        [SerializeField]
        private bool _isConsumed;

        public bool IsConsumed => _isConsumed;

        public float ValidUntilTime => _bufferedTime + _timeOut;

        public TimeInputBuffer(float timeOut)
        {
            _timeOut = timeOut;
        }

        public void Buffer(float bufferedTime)
        {
            _bufferedTime = bufferedTime;
        }
        
        public void Buffer(float bufferedTime, float timeOut)
        {
            _timeOut = timeOut;
            _bufferedTime = bufferedTime;
        }

        public bool CanBeConsumed(float time)
        {
            return !IsConsumed && time <= ValidUntilTime;
        }

        public void Consume()
        {
            _isConsumed = true;
        }

        public void Reset()
        {
            _isConsumed = false;
        }
    }

    [Serializable]
    public class TimeInputBuffer<T> : TimeInputBuffer
    {
        [SerializeField]
        private T _value;

        public T Value => _value;

        public TimeInputBuffer(T value, float timeOut) : base(timeOut)
        {
            _value = value;
        }
        
        public void Buffer(T value, float bufferedTime)
        {
            _value = value;
            Buffer(bufferedTime);
        }
        
        public void Buffer(T value, float bufferedTime, float timeOut)
        {
            _value = value;
            Buffer(bufferedTime, timeOut);
        }

        public static implicit operator T(TimeInputBuffer<T> inputBuffer)
        {
            return inputBuffer.Value;
        }
    }
}
