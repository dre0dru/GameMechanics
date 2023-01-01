namespace Dre0Dru.GameStats
{
    public static class StatsExtensions
    {
        public static bool TryGetStat<TKey, TStat>(this IAttribute<TKey, TStat> attribute, TKey key, out TStat stat)
        {
            if (attribute.HasStat(key))
            {
                stat = attribute.GetStat(key);
                return true;
            }

            stat = default;
            return false;
        } 
        
        public static bool TryGetAttribute<TKey, TAttribute>(this IAttributeGroup<TKey, TAttribute> attributeGroup, 
            TKey key, out TAttribute attribute)
        {
            if (attributeGroup.HasAttribute(key))
            {
                attribute = attributeGroup.GetAttribute(key);
                return true;
            }

            attribute = default;
            return false;
        } 
    }
}
