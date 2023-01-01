namespace Dre0Dru.StatusEffects
{
    public interface IEffectable<in TId, in TSource>
    {
        void ApplyEffect(TId id, TSource source);

        void CancelEffect(TId id);

        bool HasEffect(TId id);
    }
}
