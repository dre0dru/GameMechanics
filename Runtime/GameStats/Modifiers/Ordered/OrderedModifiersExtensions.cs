using System;

namespace Dre0Dru.GameStats.Modifiers.Ordered
{
    public static class OrderedModifiersExtensions
    {
        public static void AddTo(this OrderedModifier<float> modifier, ref float[] array)
        {
            ResizeArray(modifier, ref array);

            array[modifier.Order] += modifier.Value;
        }
        
        public static void RemoveFrom(this OrderedModifier<float> modifier, ref float[] array)
        {
            ResizeArray(modifier, ref array);

            array[modifier.Order] -= modifier.Value;
        }

        public static float GetValueOrDefault(this float[] array, int index, float defaultValue = 0.0f)
        {
            if (index >= array.Length)
            {
                return defaultValue;
            }

            return array[index];
        }
        
        private static void ResizeArray(OrderedModifier<float> modifier, ref float[] array)
        {
            if (modifier.Order >= array.Length)
            {
                Array.Resize(ref array, modifier.Order + 1);
            }
        }
    }
}
