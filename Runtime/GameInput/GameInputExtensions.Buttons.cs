using UnityEngine;

namespace Dre0Dru.GameInput
{
    public static partial class GameInputExtensions
    {
        public static void OnPress(this Button inputButton)
        {
            inputButton.OnPress(Time.time, Time.frameCount);
        }

        public static void OnHold(this Button inputButton)
        {
            inputButton.OnHold(Time.time, Time.frameCount);
        }

        public static bool WasHeldOnFrame(this Button inputButton, int frame)
        {
            return inputButton.LastHoldFrame == frame;
        }

        public static bool WasHeldThisFrame(this Button inputButton)
        {
            return inputButton.WasHeldOnFrame(Time.frameCount);
        }

        public static bool WasHeldOnTime(this Button inputButton, float time)
        {
            return time <= inputButton.LastHoldTime && time >= inputButton.PressTime;
        }
        
        public static bool WasHeldOnTime(this Button inputButton)
        {
            return inputButton.WasHeldOnTime(Time.time);
        }

        public static bool WasPressedOnFrame(this Button inputButton, int frame)
        {
            return inputButton.PressFrame == frame;
        }
        
        public static bool WasPressedThisFrame(this Button inputButton)
        {
            return inputButton.WasPressedOnFrame(Time.frameCount);
        }

        public static bool WasPressedInLastSeconds(this Button inputButton, float time, float seconds)
        {
            return time - inputButton.PressTime <= seconds;
        }
        
        public static bool WasPressedInLastSeconds(this Button inputButton, float seconds)
        {
            return inputButton.WasPressedInLastSeconds(Time.time, seconds);
        }

        public static bool WasPressedInLastFrames(this Button inputButton, int frame, int lastFramesCount)
        {
            return frame - inputButton.PressFrame <= lastFramesCount;
        }

        public static bool WasPressedInLastFrames(this Button inputButton, int lastFramesCount)
        {
            return inputButton.WasPressedInLastFrames(Time.frameCount, lastFramesCount);
        }

        public static bool WasTappedInLastSeconds(this Button inputButton, float time, float seconds)
        {
            return inputButton.WasPressedInLastSeconds(time, seconds) &&
                   inputButton.HeldForTime < seconds && !inputButton.WasHeldOnTime(time);
        }
        
        public static bool WasTappedInLastSeconds(this Button inputButton, float seconds)
        {
            var time = Time.time;
            return inputButton.WasTappedInLastSeconds(time, seconds);
        }
    }
}
