namespace Dre0Dru.GameStats
{
    public interface IModifiable<in TModifier>
    {
        void AddModifier(TModifier modifier);

        void RemoveModifier(TModifier modifier);
    }
}
