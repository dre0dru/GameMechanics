using UnityEngine;

namespace Dre0Dru.GameInput
{
    public static class GameInputExtensions
    {
        public static void OnPress(this InputButton inputButton)
        {
            inputButton.OnPress(Time.time, Time.frameCount);
        }

        public static void OnHold(this InputButton inputButton)
        {
            inputButton.OnHold(Time.time, Time.frameCount);
        }

        public static bool IsPressed(this InputButton inputButton)
        {
            return inputButton.LastHoldFrame == Time.frameCount;
        }

        public static bool WasPressedThisFrame(this InputButton inputButton)
        {
            return inputButton.PressFrame == Time.frameCount;
        }

        public static bool WasPressedInLastSeconds(this InputButton inputButton, float seconds)
        {
            return Time.time - inputButton.PressTime <= seconds;
        }

        public static bool WasPressedInLastFrames(this InputButton inputButton, int frames)
        {
            return Time.frameCount - inputButton.PressFrame <= frames;
        }

        public static void Buffer(this TimeInputBuffer inputBuffer)
        {
            inputBuffer.Buffer(Time.time);
        }

        public static void Buffer(this TimeInputBuffer inputBuffer, float timeOut)
        {
            inputBuffer.Buffer(Time.time, timeOut);
        }

        public static void Buffer<T>(this TimeInputBuffer<T> inputBuffer, T value)
        {
            inputBuffer.Buffer(value, Time.time);
        }

        public static void Buffer<T>(this TimeInputBuffer<T> inputBuffer, T value, float timeOut)
        {
            inputBuffer.Buffer(value, Time.time, timeOut);
        }

        public static void BufferIfWasPressedThisFrame<T>(this TimeInputBuffer<T> inputBuffer, InputButton<T> inputButton)
        {
            if (inputButton.WasPressedThisFrame())
            {
                inputBuffer.Buffer(inputButton.Value, inputButton.PressTime);
            }
        }

        public static void BufferIfWasPressedThisFrame<T>(this TimeInputBuffer<T> inputBuffer, InputButton<T> inputButton, float timeOut)
        {
            if (inputButton.WasPressedThisFrame())
            {
                inputBuffer.Buffer(inputButton.Value, inputButton.PressTime, timeOut);
            }
        }

        public static bool CanBeConsumed(this TimeInputBuffer inputBuffer)
        {
            return inputBuffer.CanBeConsumed(Time.time);
        }

        public static bool TryToConsume(this TimeInputBuffer inputBuffer)
        {
            return inputBuffer.TryToConsume(Time.time);
        }

        public static bool TryToConsume(this TimeInputBuffer inputBuffer, float time)
        {
            if (inputBuffer.CanBeConsumed(time))
            {
                inputBuffer.Consume();
                return true;
            }

            return false;
        }

        public static bool TryToConsume<T>(this TimeInputBuffer<T> inputBuffer, out T value)
        {
            return inputBuffer.TryToConsume(Time.time, out value);
        }

        public static bool TryToConsume<T>(this TimeInputBuffer<T> inputBuffer, float time, out T value)
        {
            if (inputBuffer.CanBeConsumed(time))
            {
                inputBuffer.Consume();
                value = inputBuffer.Value;
                return true;
            }

            value = default;
            return false;
        }
    }
}
