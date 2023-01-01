namespace Dre0Dru.GameStats
{
    //TODO remove this interface?
    public interface IAttributeGroup<in TKey, out TAttribute>
    {
        public TAttribute this[TKey key] => GetAttribute(key);
        
        TAttribute GetAttribute(TKey key);

        bool HasAttribute(TKey key);
    }
}
