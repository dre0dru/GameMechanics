using System;
using UnityEngine;

namespace Dre0Dru.GameInput
{
    //TODO wrapper around InputSystem.ButtonControl?
    //TODO something like query builder fo input filtering? like button.WasPressedIn().NotHold() and etc.
    //TODO rename hold and all related extensions
    [Serializable]
    public class InputButton
    {
        [SerializeField]
        private float _pressTime = float.MinValue;
        
        [SerializeField]
        private int _pressFrame = -1;
        
        [SerializeField]
        private float _lastHoldTime = float.MinValue;

        [SerializeField]
        private int _lastHoldFrame = -1;

        public float PressTime => _pressTime;

        public int PressFrame => _pressFrame;

        public float LastHoldTime => _lastHoldTime;

        public int LastHoldFrame => _lastHoldFrame;

        public float HeldForTime => _lastHoldTime - _pressTime;
        
        public int HeldForFrames => _lastHoldFrame - _pressFrame;

        public void OnPress(float pressTime, int pressFrame)
        {
            _pressTime = pressTime;
            _pressFrame = pressFrame;
        }

        public void OnHold(float holdTime, int holdFrame)
        {
            _lastHoldTime = holdTime;
            _lastHoldFrame = holdFrame;
        }
    }
    
    [Serializable]
    public class InputButton<T> : InputButton
    {
        [SerializeField]
        private T _value;

        public T Value
        {
            get => _value;
            set => _value = value;
        }

        public static implicit operator T(InputButton<T> inputButton)
        {
            return inputButton.Value;
        }
    }
}
