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

            if (kb.wKey.isPressed || kb.upArrowKey.isPressed)
            {
                result.y += 1;
            }
            
            if (kb.sKey.isPressed || kb.downArrowKey.isPressed)
            {
                result.y -= 1;
            }
            
            if (kb.dKey.isPressed || kb.rightArrowKey.isPressed)
            {
                result.x += 1;
            }
            
            if (kb.aKey.isPressed || kb.leftArrowKey.isPressed)
            {
                result.x -= 1;
            }

            return result;
        }

        public static Vector2 GetMouseInput2()
        {
            var mouse = UnityEngine.InputSystem.Mouse.current;

            return mouse.delta.ReadValue();
        }

        #else
        public static Vector2 GetInput2()
        {
            var result = Vector2.zero;

            if (Input.GetKey(KeyCode.W))
            {
                result.y += 1;
            }

            if (Input.GetKey(KeyCode.S))
            {
                result.y -= 1;
            }

            if (Input.GetKey(KeyCode.D))
            {
                result.x += 1;
            }

            if (Input.GetKey(KeyCode.A))
            {
                result.x -= 1;
            }

            return result;
        }
        #endif
    }
}
