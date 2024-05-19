using UnityEngine;

namespace Dre0Dru.GameInput
{
    public static class Wasd
    {
        #if INPUT_SYSTEM
        public static Vector2 GetInput2()
        {
            var result = Vector2.zero;

            var kb = UnityEngine.InputSystem.Keyboard.current;

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

            return result;
        }
        #endif
    }
}
