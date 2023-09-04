using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.Projectiles.Patterns
{
    public static class BurstPatternsExtensions
    {
        public static float[] CalculateAngles2D(this BurstPattern2D burstPattern)
        {
            var result = new float[burstPattern.Count];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = burstPattern.CalculateAngle2D(i);
            }

            return result;
        }
        
        public static int CalculateAngles2DNonAlloc(this BurstPattern2D burstPattern, float[] angles)
        {
            var count = Mathf.Min(angles.Length, burstPattern.Count);
            
            for (int i = 0; i < count; i++)
            {
                angles[i] = burstPattern.CalculateAngle2D(i);
            }

            return count;
        }
        
        public static void CalculateAngles2DNonAlloc(this BurstPattern2D burstPattern, List<float> angles, bool clearList = false)
        {
            if (clearList)
            {
                angles.Clear();
            }
            
            for (int i = 0; i < burstPattern.Count; i++)
            {
                angles.Add(burstPattern.CalculateAngle2D(i));
            }
        }

        public static float TotalDelayTime(this BurstPattern2D burstPattern)
        {
            return burstPattern.Delay * burstPattern.Count;
        }
    }
}
