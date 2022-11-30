namespace Dre0Dru.GameStats
{
    //TODO constrain TAttribute by interface?
    public interface IAttributeGroup<in TKey, out TAttribute>
    {
        public TAttribute this[TKey key] => GetAttribute(key);
        
        TAttribute GetAttribute(TKey key);
    }
}
