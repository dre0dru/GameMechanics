using System;
using UnityEngine;

namespace Dre0Dru.GameInput
{
    public interface IInputTimeBuffer
    {
        float TimeOut { get; set; }
        bool IsConsumed { get; }
        float ValidUntilTime { get; }
        void Buffer(float bufferedTime);
        void Buffer(float bufferedTime, float timeOut);
        bool CanBeConsumed(float time);
        void Consume(float time);
    }

    public interface IInputTimeBuffer<T> : IInputTimeBuffer
    {
        T Value { get; }
        void Buffer(T value, float bufferedTime);
        void Buffer(T value, float bufferedTime, float timeOut);
    }
    
    [Serializable]
    public class InputTimeBuffer : IInputTimeBuffer
    {
        [SerializeField]
        private float _timeOut;

        [SerializeField]
        private float _bufferedTime = float.MinValue;

        [SerializeField]
        private float _consumeTime = float.MinValue;

        public float TimeOut
        {
            get => _timeOut;
            set => _timeOut = value;
        }

        public bool IsConsumed => _consumeTime >= _bufferedTime;

        public float ValidUntilTime => _bufferedTime + _timeOut;

        public InputTimeBuffer() : this(default)
        {
            
        }
        
        public InputTimeBuffer(float timeOut)
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
            Buffer(bufferedTime);
        }

        public bool CanBeConsumed(float time)
        {
            return !IsConsumed && time <= ValidUntilTime;
        }

        public void Consume(float time)
        {
            _consumeTime = time;
        }
    }

    [Serializable]
    public class InputTimeBuffer<T> : InputTimeBuffer, IInputTimeBuffer<T>
    {
        [SerializeField]
        private T _value;

        public T Value => _value;

        public InputTimeBuffer() : this(default, default)
        {
        }
        
        public InputTimeBuffer(float timeout) : this(default, timeout)
        {
        }
        
        public InputTimeBuffer(T value) : this(value, default)
        {
        }

        public InputTimeBuffer(T value, float timeOut) : base(timeOut)
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

        public static implicit operator T(InputTimeBuffer<T> inputBuffer)
        {
            return inputBuffer.Value;
        }
    }
}
