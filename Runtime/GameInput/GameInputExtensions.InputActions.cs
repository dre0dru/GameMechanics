using UnityEngine.InputSystem;

namespace Dre0Dru.GameInput
{
    public static partial class GameInputExtensions
    {
        public static void UpdatePressedStateFromContext(this ButtonState buttonState, InputAction.CallbackContext ctx) =>
            buttonState.UpdatePressedState();

        public static void UpdateReleasedStateFromContext(this ButtonState buttonState, InputAction.CallbackContext ctx) =>
            buttonState.UpdateReleasedState();

        public static void AddButtonState(this InputAction inputAction, ButtonState buttonState)
        {
            inputAction.performed += buttonState.UpdatePressedStateFromContext;
            inputAction.canceled += buttonState.UpdateReleasedStateFromContext;
        }

        public static void RemoveButtonState(this InputAction inputAction, ButtonState buttonState)
        {
            inputAction.performed -= buttonState.UpdatePressedStateFromContext;
            inputAction.canceled -= buttonState.UpdateReleasedStateFromContext;
        }
    }
}
