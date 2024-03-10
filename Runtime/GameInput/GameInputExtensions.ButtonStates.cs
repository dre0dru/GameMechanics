using UnityEngine;

namespace Dre0Dru.GameInput
{
    public static partial class GameInputExtensions
    {
        public static void UpdatePressedState(this IButtonState buttonState)
        {
            buttonState.PressFrame = Time.frameCount;
            buttonState.PressTime = Time.realtimeSinceStartup;
        }
        
        public static void UpdateReleasedState(this IButtonState buttonState)
        {
            buttonState.ReleaseFrame = Time.frameCount;
            buttonState.ReleaseTime = Time.realtimeSinceStartup;
        }

        public static bool IsPressed(this IButtonState buttonState)
        {
            return buttonState.ReleaseFrame < buttonState.PressFrame;
        }
        
        public static bool WasPressedThisFrame(this IButtonState buttonState)
        {
            return buttonState.PressFrame == Time.frameCount;
        }

        public static bool WasReleasedThisFrame(this IButtonState buttonState)
        {
            return buttonState.ReleaseFrame == Time.frameCount;
        }

        public static float HoldTime(this IButtonState buttonState)
        {
            if (buttonState.IsPressed())
            {
                return Time.realtimeSinceStartup - buttonState.PressTime;
            }
          
            return buttonState.ReleaseTime - buttonState.PressTime;
        }

        public static bool WasHeldFor(this IButtonState buttonState, float seconds)
        {
            return buttonState.HoldTime() >= seconds;
        }

        public static bool WasTapped(this IButtonState buttonState, float tapDurationSeconds)
        {
            return !buttonState.IsPressed() && !buttonState.WasHeldFor(tapDurationSeconds) &&
                   buttonState.WasPressedInLast(tapDurationSeconds);
        }

        public static bool WasPressedInLast(this IButtonState buttonState, float seconds)
        {
            return Time.realtimeSinceStartup - buttonState.PressTime <= seconds;
        }
    }
}
