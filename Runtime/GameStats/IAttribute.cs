namespace Dre0Dru.GameStats
{
    //TODO remove this interface?
    public interface IAttribute<in TKey, out TStat>
    {
        public TStat this[TKey key] => GetStat(key);
        
        TStat GetStat(TKey key);

        bool HasStat(TKey key);
    }
}
