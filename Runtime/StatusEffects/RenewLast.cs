using System;
using System.Collections.Generic;

namespace Dre0Dru.StatusEffects
{
    [Serializable, AddTypeMenu("Last")]
    public class RenewLast : IRenewStrategy
    {
        public void Renew(List<EffectStackData> stackedData, float duration)
        {
            stackedData[stackedData.Count - 1].Duration = duration;
        }
    }
}
