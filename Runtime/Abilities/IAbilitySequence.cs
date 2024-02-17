namespace Abilities
{
    public interface IAbilitySequence
    {
        SequenceStatus Status { get; }
        void Begin();
        void Process(float dt);
        void Interrupt();
        void Finish();
        void Reset();
    }
}
