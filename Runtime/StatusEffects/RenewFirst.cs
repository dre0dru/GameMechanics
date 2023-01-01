using System;
using System.Collections.Generic;

namespace Dre0Dru.StatusEffects
{
    [Serializable, AddTypeMenu("First")]
    public class RenewFirst : IRenewStrategy
    {
        public void Renew(List<EffectStackData> stackedData, float duration)
        {
            stackedData[0].Duration = duration;
        }
    }
}
