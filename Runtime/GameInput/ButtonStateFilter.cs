using System;

namespace Dre0Dru.GameInput
{
    //TODO hold, press, tap filters
    public abstract class ButtonStateFilter
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

    public abstract class ButtonStateFilter<T>
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
}
