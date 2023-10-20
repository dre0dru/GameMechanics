using System;

namespace Dre0Dru.GameInput
{
    public interface IButtonStateFilter
    {
        bool IsValid { get; }
    }

    public abstract class ButtonStateFilter : IButtonStateFilter
    {
        private readonly ButtonState _button;

        public abstract bool IsValid { get; }

        protected ButtonState Button => _button;

        protected ButtonStateFilter(ButtonState button)
        {
            _button = button;
        }

        public static implicit operator bool(ButtonStateFilter buttonFilter)
        {
            return buttonFilter.IsValid;
        }
    }

    public abstract class ButtonStateFilter<T> : IButtonStateFilter
    {
        private readonly ButtonState<T> _button;

        public abstract bool IsValid { get; }

        protected ButtonState<T> Button => _button;

        protected ButtonStateFilter(ButtonState<T> button)
        {
            _button = button;
        }

        public static implicit operator bool(ButtonStateFilter<T> buttonFilter)
        {
            return buttonFilter.IsValid;
        }
    }

    public class ButtonStateDelegateFilter : ButtonStateFilter
    {
        private readonly Func<ButtonState, bool> _filterFunc;

        public ButtonStateDelegateFilter(ButtonState button, Func<ButtonState, bool> filterFunc) : base(button)
        {
            _filterFunc = filterFunc;
        }

        public override bool IsValid => _filterFunc(Button);
    }

    public class ButtonStateDelegateFilter<T> : ButtonStateFilter<T>
    {
        private readonly Func<ButtonState<T>, bool> _filterFunc;

        public ButtonStateDelegateFilter(ButtonState<T> button, Func<ButtonState<T>, bool> filterFunc) : base(button)
        {
            _filterFunc = filterFunc;
        }

        public override bool IsValid => _filterFunc(Button);
    }

    public class ButtonStateHoldFilter : ButtonStateFilter
    {
        private readonly float _holdDurationSeconds;

        public ButtonStateHoldFilter(ButtonState button, float holdDurationSeconds) : base(button)
        {
            _holdDurationSeconds = holdDurationSeconds;
        }

        public override bool IsValid => Button.WasHeldFor(_holdDurationSeconds);
    }

    public class ButtonStateTapFilter : ButtonStateFilter
    {
        private readonly float _tapDurationSeconds;

        public ButtonStateTapFilter(ButtonState button, float tapDurationSeconds) : base(button)
        {
            _tapDurationSeconds = tapDurationSeconds;
        }

        public override bool IsValid => Button.WasTapped(_tapDurationSeconds);
    }

    public class ButtonStatePressFilter : ButtonStateFilter
    {
        public ButtonStatePressFilter(ButtonState button) : base(button)
        {
        }

        public override bool IsValid => Button.IsPressed();
    }
}
