namespace Dre0Dru.GameStats
{
    //TODO constrain TStat by interface?
    public interface IAttribute<in TKey, out TStat>
    {
        public TStat this[TKey key] => GetStat(key);
        
        TStat GetStat(TKey key);
    }
}
