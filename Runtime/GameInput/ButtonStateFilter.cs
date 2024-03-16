using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

namespace Dre0Dru.GameInput
{
    public interface IButtonStateFilter<in TButtonState>
        where TButtonState : IButtonState
    {
        bool IsValid(TButtonState buttonState);
    }

    [Serializable]
    public class ButtonStateCompositeFilter<TButtonState> : IButtonStateFilter<TButtonState>
        where TButtonState : IButtonState
    {
        [SerializeReference]
        private List<IButtonStateFilter<TButtonState>> _filters = new();

        public ButtonStateCompositeFilter()
        {
        }

        public ButtonStateCompositeFilter(List<IButtonStateFilter<TButtonState>> filters)
        {
            _filters = filters;
        }

        public ButtonStateCompositeFilter(params IButtonStateFilter<TButtonState>[] filters)
        {
            _filters = new List<IButtonStateFilter<TButtonState>>(filters);
        }

        public bool IsValid(TButtonState buttonState)
        {
            foreach (var filter in _filters)
            {
                if (!filter.IsValid(buttonState))
                {
                    return false;
                }
            }

            return true;
        }

        public ButtonStateCompositeFilter<TButtonState> Add(IButtonStateFilter<TButtonState> filter)
        {
            _filters.Add(filter);
            return this;
        }
    }

    [Serializable]
    public class ButtonStateDelegateFilter<TButtonState> : IButtonStateFilter<TButtonState>
        where TButtonState : IButtonState
    {
        private Func<TButtonState, bool> _filterFunc;

        public Func<TButtonState, bool> FilterFunc
        {
            get => _filterFunc;
            set => _filterFunc = value;
        }

        [RequiredMember]
        public ButtonStateDelegateFilter()
        {
        }

        public ButtonStateDelegateFilter(Func<TButtonState, bool> filterFunc)
        {
            _filterFunc = filterFunc;
        }

        public bool IsValid(TButtonState buttonState)
        {
            return _filterFunc(buttonState);
        }
    }

    [Serializable]
    public class ButtonStateHoldFilter<TButtonState> : IButtonStateFilter<TButtonState>
        where TButtonState : IButtonState
    {
        [SerializeField]
        private float _holdDurationSeconds;

        [RequiredMember]
        public ButtonStateHoldFilter() : this(0.5f)
        {
        }

        public ButtonStateHoldFilter(float holdDurationSeconds)
        {
            _holdDurationSeconds = holdDurationSeconds;
        }

        public bool IsValid(TButtonState buttonState)
        {
            return buttonState.WasHeldFor(_holdDurationSeconds);
        }
    }

    [Serializable]
    public class ButtonStateTapFilter<TButtonState> : IButtonStateFilter<TButtonState>
        where TButtonState : IButtonState
    {
        [SerializeField]
        private float _tapDurationSeconds;

        [RequiredMember]
        public ButtonStateTapFilter() : this(0.5f)
        {
        }

        public ButtonStateTapFilter(float tapDurationSeconds)
        {
            _tapDurationSeconds = tapDurationSeconds;
        }

        public bool IsValid(TButtonState buttonState)
        {
            return buttonState.WasTapped(_tapDurationSeconds);
        }
    }

    [Serializable]
    public class ButtonStatePressFilter<TButtonState> : IButtonStateFilter<TButtonState>
        where TButtonState : IButtonState
    {
        [RequiredMember]
        public ButtonStatePressFilter()
        {
        }

        public bool IsValid(TButtonState buttonState)
        {
            return buttonState.IsPressed();
        }
    }
    
    [Serializable]
    public class ButtonStateWasPressedFilter<TButtonState> : IButtonStateFilter<TButtonState>
        where TButtonState : IButtonState
    {
        [RequiredMember]
        public ButtonStateWasPressedFilter()
        {
        }

        public bool IsValid(TButtonState buttonState)
        {
            return buttonState.WasPressedThisFrame();
        }
    }
    
    [Serializable]
    public class ButtonStatePressedInLastFilter<TButtonState> : IButtonStateFilter<TButtonState>
        where TButtonState : IButtonState
    {
        [SerializeField]
        private float _seconds;
        
        [RequiredMember]
        public ButtonStatePressedInLastFilter() : this(0.5f)
        {
        }

        public ButtonStatePressedInLastFilter(float seconds)
        {
            _seconds = seconds;
        }

        public bool IsValid(TButtonState buttonState)
        {
            return buttonState.WasPressedInLast(_seconds);
        }
    }
}
