using Dre0Dru.Values;

namespace Abilities
{
    public interface IAbilityTrack
    {
        void Begin();
        void Process(ValueChange<float> normalizedProgress);
        void Interrupt();
        void Finish();
    }
}
