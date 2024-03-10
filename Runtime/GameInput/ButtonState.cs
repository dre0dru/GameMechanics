using System;
using UnityEngine;

namespace Dre0Dru.GameInput
{
    public interface IButtonState
    {
        float PressTime { get; set; }
        int PressFrame { get; set; }
        float ReleaseTime { get; set; }
        int ReleaseFrame { get; set; }
    }

    public interface IButtonState<T> : IButtonState
    {
        T Value { get; set; }
    }
    
    //TODO state that can hold previous N states?
    [Serializable]
    public class ButtonState : IButtonState
    {
        [SerializeField]
        private float _pressTime = float.MinValue;

        [SerializeField]
        private int _pressFrame = -1;

        [SerializeField]
        private float _releaseTime = float.MinValue;

        [SerializeField]
        private int _releaseFrame = -1;

        public float PressTime
        {
            get => _pressTime;
            set => _pressTime = value;
        }

        public int PressFrame
        {
            get => _pressFrame;
            set => _pressFrame = value;
        }

        public float ReleaseTime
        {
            get => _releaseTime;
            set => _releaseTime = value;
        }

        public int ReleaseFrame
        {
            get => _releaseFrame;
            set => _releaseFrame = value;
        }
    }

    [Serializable]
    public class ButtonState<T> : ButtonState, IButtonState<T>
    {
        [SerializeField]
        private T _value;

        public T Value
        {
            get => _value;
            set => _value = value;
        }

        public static implicit operator T(ButtonState<T> buttonState)
        {
            return buttonState.Value;
        }
    }
}
