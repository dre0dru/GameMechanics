using System.Collections.Generic;

namespace Dre0Dru.StatusEffects
{
    public interface IRenewStrategy
    {
        void Renew(List<EffectStackData> stackedData, float duration);
    }
}
