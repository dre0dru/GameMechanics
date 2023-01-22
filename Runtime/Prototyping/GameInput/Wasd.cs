using UnityEngine;
using UnityEngine.InputSystem;

namespace Dre0Dru.Prototyping.GameInput
{
    public static class Wasd
    {
        public static Vector2 GetInput2()
        {
            #if INPUT_SYSTEM
            var result = Vector2.zero;

            var kb = Keyboard.current;

            if (kb.wKey.isPressed)
            {
                result.y += 1;
            }
            
            if (kb.sKey.isPressed)
            {
                result.y -= 1;
            }
            
            if (kb.dKey.isPressed)
            {
                result.x += 1;
            }
            
            if (kb.aKey.isPressed)
            {
                result.x -= 1;
            }

            return result.normalized;
            #else
            //TODO handle legacy input
            return Vector2.zero;
            #endif
        }

        public static Vector2 GetInput2Smoothed(Vector2 current, float maxDistanceDelta)
        {
            return Vector2.MoveTowards(current, GetInput2(), maxDistanceDelta);
        }

        public static Vector3 GetInput3()
        {
            var input2 = GetInput2();
            return new Vector3(input2.x, 0, input2.y).normalized;
        }
        
        public static Vector3 GetInput3Smoothed(Vector3 current,  float maxDistanceDelta)
        {
            var input2 = GetInput2Smoothed(new Vector2(current.x, current.z), maxDistanceDelta);
            return new Vector3(input2.x, 0, input2.y).normalized;
        }
    }
}
