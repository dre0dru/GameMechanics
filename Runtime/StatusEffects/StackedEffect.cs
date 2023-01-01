using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.StatusEffects
{
    //TODO how to make it generic without breaking serialization?
    [Serializable]
    public abstract class StackedEffect : IEffect<GameObject>, ICancellableEffect, ITickEffect<float>, IRenewableEffect
    {
        [SerializeField]
        private StackedEffectProperties _properties;

        [SerializeReference, SubclassSelector]
        private IRenewStrategy _renewStrategy = new RenewFirst();

        private GameObject _target;

        private List<EffectStackData> _stackedData;

        protected List<EffectStackData> StackedData => _stackedData;

        public StackedEffectProperties Properties => _properties;

        public int NumberOfStacks => _stackedData.Count;

        public virtual bool IsEnded => NumberOfStacks == 0;

        public GameObject Target => _target;

        public void Apply(GameObject target)
        {
            _stackedData ??= new List<EffectStackData>();
            _target = target;

            OnApply(target);
        }

        public void Push(GameObject source)
        {
            if (TryAddStack(source, out var data))
            {
                OnPush(data);
            }
            else
            {
                Renew();
            }
        }

        public void Pop()
        {
            if (NumberOfStacks > 0)
            {
                Pop(_stackedData.Count - 1);
            }
        }

        public void PopAll()
        {
            for (int i = 0; i < NumberOfStacks; i++)
            {
                Pop();
            }
        }

        public void Tick(float deltaTime)
        {
            if (_properties.Duration <= 0)
            {
                return;
            }

            TickStacks(deltaTime);

            OnTick(deltaTime);
        }

        public void Cancel()
        {
            OnCancel();
            _target = null;
            _stackedData?.Clear();
        }

        public void Renew()
        {
            if (_stackedData.Count > 0 && _properties.RenewOnMaxStack)
            {
                _renewStrategy.Renew(_stackedData, _properties.Duration);
            }

            OnRenew();
        }

        protected void Pop(int index)
        {
            var data = _stackedData[index];
            _stackedData.RemoveAt(index);

            OnPop(data);
        }

        protected virtual void OnApply(GameObject target)
        {
        }

        protected abstract void OnPush(EffectStackData stackData);

        protected abstract void OnPop(EffectStackData stackData);

        protected virtual void OnTick(float deltaTime)
        {
        }

        protected virtual void OnCancel()
        {
        }

        protected virtual void OnRenew()
        {
        }

        private bool TryAddStack(GameObject source, out EffectStackData data)
        {
            if (NumberOfStacks < _properties.MaxStack)
            {
                data = new EffectStackData()
                {
                    Duration = _properties.Duration,
                    Source = source
                };

                _stackedData.Add(data);

                return true;
            }

            data = null;
            return false;
        }

        private void TickStacks(float deltaTime)
        {
            for (int i = NumberOfStacks - 1; i >= 0; i--)
            {
                var stackData = _stackedData[i];

                if (stackData.Duration < 0)
                {
                    Pop(i);
                    break;
                }

                stackData.Duration -= deltaTime;
            }
        }
    }
}
