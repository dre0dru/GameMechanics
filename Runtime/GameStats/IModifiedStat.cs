namespace Dre0Dru.GameStats
{
    public interface IModifiedStat<out TValue>
    {
        TValue GetModifiedValue();
    }

    public interface IModifiedStat<out TValue, in TModifier> :
        IModifiedStat<TValue>, IModifiable<TModifier>
    {
    }
}
