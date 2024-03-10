using System;
using UnityEngine;

namespace Dre0Dru.GameInput
{
    [Serializable]
    public class BufferedButtonState : IButtonState, IInputTimeBuffer
    {
        [SerializeField]
        private ButtonState _buttonState;

        [SerializeField]
        private InputTimeBuffer _inputTimeBuffer;

        public float PressTime
        {
            get => _buttonState.PressTime;
            set => _buttonState.PressTime = value;
        }

        public int PressFrame
        {
            get => _buttonState.PressFrame;
            set => _buttonState.PressFrame = value;
        }

        public float ReleaseTime
        {
            get => _buttonState.ReleaseTime;
            set => _buttonState.ReleaseTime = value;
        }

        public int ReleaseFrame
        {
            get => _buttonState.ReleaseFrame;
            set => _buttonState.ReleaseFrame = value;
        }

        public float TimeOut
        {
            get => _inputTimeBuffer.TimeOut;
            set => _inputTimeBuffer.TimeOut = value;
        }

        public bool IsConsumed => _inputTimeBuffer.IsConsumed;

        public float ValidUntilTime => _inputTimeBuffer.ValidUntilTime;

        public BufferedButtonState() : this(default)
        {
            
        }
        
        public BufferedButtonState(float timeout)
        {
            _buttonState = new ButtonState();
            _inputTimeBuffer = new InputTimeBuffer(timeout);
        }
        
        public void Buffer(float bufferedTime)
        {
            _inputTimeBuffer.Buffer(bufferedTime);
        }

        public void Buffer(float bufferedTime, float timeOut)
        {
            _inputTimeBuffer.Buffer(bufferedTime, timeOut);
        }

        public bool CanBeConsumed(float time)
        {
            return _inputTimeBuffer.CanBeConsumed(time);
        }

        public void Consume(float time)
        {
            _inputTimeBuffer.Consume(time);
        }
    }
}
