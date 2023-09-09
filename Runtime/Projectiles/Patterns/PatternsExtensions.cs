using Dre0Dru.MathExtensions;
using UnityEngine;

namespace Dre0Dru.Projectiles.Patterns
{
    public static class PatternsExtensions
    {
        public static (Vector3 direction, Vector3 position) ToDirectionAndPositionY(this PatternOutput patternOutput,
            Transform transform)
        {
            return (patternOutput.ToDirectionY(transform), patternOutput.ToPositionY(transform));
        }

        public static Vector3 ToDirectionY(this PatternOutput patternOutput, Transform transform)
        {
            return VectorExtensions
                .CalculateDirectionFromAngle2D(patternOutput.Angle + transform.eulerAngles.y)
                .ToVector3XZ(transform.position.y);
        }

        public static Vector3 ToPositionY(this PatternOutput patternOutput, Transform transform)
        {
            return transform.position + transform.right * patternOutput.Offset.x +
                   transform.forward * patternOutput.Offset.y;
        }
    }
}
