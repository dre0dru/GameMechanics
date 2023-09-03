using UnityEngine;

namespace Dre0Dru.Projectiles.Patterns
{
    public static class BurstPatternsExtensions
    {
        public static float CalculateAngle2D(this BurstPattern2D burstPattern, int index, float initialAngle)
        {
            var randomSpread = Random.value * burstPattern.RandomSpread;
            var currentAngle = initialAngle - burstPattern.RecenterAngle;
            currentAngle += burstPattern.AngleStep * index + randomSpread;

            return currentAngle;
        }

        public static float[] CalculateAngles2D(this BurstPattern2D burstPattern, float initialAngle)
        {
            var result = new float[burstPattern.Count];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = burstPattern.CalculateAngle2D(i, initialAngle);
            }

            return result;
        }
        
        public static int CalculateAngles2DNonAlloc(this BurstPattern2D burstPattern, float initialAngle, float[] angles)
        {
            var count = Mathf.Min(angles.Length, burstPattern.Count);
            
            for (int i = 0; i < count; i++)
            {
                angles[i] = burstPattern.CalculateAngle2D(i, initialAngle);
            }

            return count;
        }
    }
}
