using System;

namespace Dre0Dru.GameInput
{
    public abstract class ButtonFilter
    {
        private readonly Button _button;

        public abstract bool CanBeTriggered { get; }

        protected Button Button => _button;

        protected ButtonFilter(Button button)
        {
            _button = button;
        }

        public static implicit operator bool(ButtonFilter buttonFilter)
        {
            return buttonFilter.CanBeTriggered;
        }
    }
    
    public abstract class ButtonFilter<T>
    {
        private readonly Button<T> _button;

        public abstract bool CanBeTriggered { get; }

        protected Button<T> Button => _button;

        protected ButtonFilter(Button<T> button)
        {
            _button = button;
        }
        
        public static implicit operator bool(ButtonFilter<T> buttonFilter)
        {
            return buttonFilter.CanBeTriggered;
        }
    }
    
    public  class ButtonDelegateFilter : ButtonFilter
    {
        private readonly Func<Button, bool> _filterFunc;

        public ButtonDelegateFilter(Button button, Func<Button, bool> filterFunc) : base(button)
        {
            _filterFunc = filterFunc;
        }

        public override bool CanBeTriggered => _filterFunc(Button);
    }
    
    public  class ButtonDelegateFilter<T> : ButtonFilter<T>
    {
        private readonly Func<Button<T>, bool> _filterFunc;

        public ButtonDelegateFilter(Button<T> button, Func<Button<T>, bool> filterFunc) : base(button)
        {
            _filterFunc = filterFunc;
        }

        public override bool CanBeTriggered => _filterFunc(Button);
    }
}
