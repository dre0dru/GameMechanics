namespace Dre0Dru.GameStats
{
    public interface IBaseStat<TValue>
    {
        TValue GetBaseValue();
        void SetBaseValue(TValue value);
    }
}
