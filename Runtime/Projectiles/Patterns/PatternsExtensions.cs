using Dre0Dru.MathExtensions;
using UnityEngine;

namespace Dre0Dru.Projectiles.Patterns
{
    public static class PatternsExtensions
    {
        public static Vector3 ToDirectionXZ(this PatternOutput patternOutput, Transform transform)
        {
            return VectorExtensions
                .CalculateDirectionFromAngle2D(patternOutput.Angle + transform.eulerAngles.y)
                .ToVector3XZ(transform.position.y);
        }

        public static Vector3 ToPositionXZ(this PatternOutput patternOutput, Transform transform)
        {
            return transform.position + transform.right * patternOutput.Offset.x +
                   transform.forward * patternOutput.Offset.y;
        }
    }
}
