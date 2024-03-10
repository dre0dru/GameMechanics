using System;
using UnityEngine.InputSystem;

namespace Dre0Dru.GameInput
{
    public static partial class GameInputExtensions
    {
        public static void
            UpdatePressedStateFromContext(this IButtonState buttonState, InputAction.CallbackContext ctx) =>
            buttonState.UpdatePressedState();

        public static void
            UpdateReleasedStateFromContext(this IButtonState buttonState, InputAction.CallbackContext ctx) =>
            buttonState.UpdateReleasedState();

        public static void AddButtonState(this InputAction inputAction, IButtonState buttonState,
            Action<InputAction.CallbackContext> onPerformed = null,
            Action<InputAction.CallbackContext> onCancelled = null)
        {
            inputAction.performed += buttonState.UpdatePressedStateFromContext;
            inputAction.canceled += buttonState.UpdateReleasedStateFromContext;

            if (onPerformed != null)
            {
                inputAction.performed += onPerformed;
            }

            if (onCancelled != null)
            {
                inputAction.canceled += onCancelled;
            }
        }

        public static void RemoveButtonState(this InputAction inputAction, IButtonState buttonState,
            Action<InputAction.CallbackContext> onPerformed = null,
            Action<InputAction.CallbackContext> onCancelled = null)
        {
            inputAction.performed -= buttonState.UpdatePressedStateFromContext;
            inputAction.canceled -= buttonState.UpdateReleasedStateFromContext;

            if (onPerformed != null)
            {
                inputAction.performed -= onPerformed;
            }

            if (onCancelled != null)
            {
                inputAction.canceled -= onCancelled;
            }
        }
    }
}
