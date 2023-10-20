using UnityEngine;
using UnityEngine.InputSystem;

namespace Dre0Dru.GameInput
{
    public static partial class GameInputExtensions
    {
        public static void UpdatePressedState(this ButtonState buttonState)
        {
            buttonState.PressFrame = Time.frameCount;
            buttonState.PressTime = Time.realtimeSinceStartup;
        }
        
        public static void UpdateReleasedState(this ButtonState buttonState)
        {
            buttonState.ReleaseFrame = Time.frameCount;
            buttonState.ReleaseTime = Time.realtimeSinceStartup;
        }

        public static bool IsPressed(this ButtonState buttonState)
        {
            return buttonState.ReleaseFrame < buttonState.PressFrame;
        }
        
        public static bool WasPressedThisFrame(this ButtonState buttonState)
        {
            return buttonState.PressFrame == Time.frameCount;
        }

        public static float HoldTime(this ButtonState buttonState)
        {
            if (buttonState.IsPressed())
            {
                return Time.realtimeSinceStartup - buttonState.PressTime;
            }
          
            return buttonState.ReleaseTime - buttonState.PressTime;
        }

        public static bool WasHeldFor(this ButtonState buttonState, float seconds)
        {
            return buttonState.HoldTime() >= seconds;
        }

        public static bool WasTapped(this ButtonState buttonState, float tapDurationSeconds)
        {
            return !buttonState.IsPressed() && !buttonState.WasHeldFor(tapDurationSeconds) &&
                   buttonState.WasPressedInLast(tapDurationSeconds);
        }

        public static bool WasPressedInLast(this ButtonState buttonState, float seconds)
        {
            return Time.realtimeSinceStartup - buttonState.PressTime <= seconds;
        }
    }
}
