using System;

namespace Dre0Dru.GameInput
{
    public interface IButtonStateFilter
    {
        bool IsValid { get; }
    }

    public abstract class ButtonStateFilter<TButtonState> : IButtonStateFilter
        where TButtonState : IButtonState
    {
        public abstract bool IsValid { get; }

        protected TButtonState ButtonState { get; }

        protected ButtonStateFilter(TButtonState buttonState)
        {
            ButtonState = buttonState;
        }

        public static implicit operator bool(ButtonStateFilter<TButtonState> buttonFilter)
        {
            return buttonFilter.IsValid;
        }
    }

    public class ButtonStateDelegateFilter<TButtonState> : ButtonStateFilter<TButtonState>
        where TButtonState : IButtonState
    {
        private readonly Func<TButtonState, bool> _filterFunc;

        public ButtonStateDelegateFilter(TButtonState buttonState, Func<TButtonState, bool> filterFunc) : base(
            buttonState)
        {
            _filterFunc = filterFunc;
        }

        public override bool IsValid => _filterFunc(ButtonState);
    }

    public class ButtonStateHoldFilter : ButtonStateFilter<IButtonState>
    {
        private readonly float _holdDurationSeconds;

        public ButtonStateHoldFilter(IButtonState buttonState, float holdDurationSeconds) : base(buttonState)
        {
            _holdDurationSeconds = holdDurationSeconds;
        }

        public override bool IsValid => ButtonState.WasHeldFor(_holdDurationSeconds);
    }

    public class ButtonStateTapFilter : ButtonStateFilter<IButtonState>
    {
        private readonly float _tapDurationSeconds;

        public ButtonStateTapFilter(IButtonState buttonState, float tapDurationSeconds) : base(buttonState)
        {
            _tapDurationSeconds = tapDurationSeconds;
        }

        public override bool IsValid => ButtonState.WasTapped(_tapDurationSeconds);
    }

    public class ButtonStatePressFilter : ButtonStateFilter<IButtonState>
    {
        public ButtonStatePressFilter(IButtonState buttonState) : base(buttonState)
        {
        }

        public override bool IsValid => ButtonState.IsPressed();
    }
}
