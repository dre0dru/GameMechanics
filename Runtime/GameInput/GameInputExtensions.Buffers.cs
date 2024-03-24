using UnityEngine;

namespace Dre0Dru.GameInput
{
    public static partial class GameInputExtensions
    {
        public static void Buffer(this IInputTimeBuffer inputBuffer)
        {
            inputBuffer.Buffer(Time.realtimeSinceStartup);
        }

        public static void Buffer(this IInputTimeBuffer inputBuffer, float timeOut)
        {
            inputBuffer.Buffer(Time.realtimeSinceStartup, timeOut);
        }

        public static void Buffer<T>(this IInputTimeBuffer<T> inputBuffer, T value)
        {
            inputBuffer.Buffer(value, Time.realtimeSinceStartup);
        }

        public static void Buffer<T>(this IInputTimeBuffer<T> inputBuffer, T value, float timeOut)
        {
            inputBuffer.Buffer(value, Time.realtimeSinceStartup, timeOut);
        }

        public static void Buffer(this IInputTimeBuffer inputBuffer,
            IButtonState buttonState)
        {
            inputBuffer.Buffer(buttonState.PressTime);
        }

        public static void Buffer(this IInputTimeBuffer inputBuffer,
            IButtonState buttonState, float timeOut)
        {
            inputBuffer.Buffer(buttonState.PressTime, timeOut);
        }

        public static void Buffer<T>(this IInputTimeBuffer<T> inputBuffer,
            IButtonState<T> buttonState)
        {
            inputBuffer.Buffer(buttonState.Value, buttonState.PressTime);
        }

        public static void Buffer<T>(this IInputTimeBuffer<T> inputBuffer,
            IButtonState<T> buttonState, float timeOut)
        {
            inputBuffer.Buffer(buttonState.Value, buttonState.PressTime, timeOut);
        }

        public static bool CanBeConsumed(this IInputTimeBuffer inputBuffer)
        {
            return inputBuffer.CanBeConsumed(Time.realtimeSinceStartup);
        }

        public static void Consume(this IInputTimeBuffer inputBuffer)
        {
            inputBuffer.Consume(Time.realtimeSinceStartup);
        }

        public static bool TryToConsume(this IInputTimeBuffer inputBuffer)
        {
            return inputBuffer.TryToConsume(Time.realtimeSinceStartup);
        }

        public static bool TryToConsume(this IInputTimeBuffer inputBuffer, float time)
        {
            if (inputBuffer.CanBeConsumed(time))
            {
                inputBuffer.Consume(time);
                return true;
            }

            return false;
        }

        public static bool TryToConsume<T>(this IInputTimeBuffer<T> inputBuffer, out T value)
        {
            return inputBuffer.TryToConsume(Time.realtimeSinceStartup, out value);
        }

        public static bool TryToConsume<T>(this IInputTimeBuffer<T> inputBuffer, float time, out T value)
        {
            if (inputBuffer.CanBeConsumed(time))
            {
                inputBuffer.Consume(time);
                value = inputBuffer.Value;
                return true;
            }

            value = default;
            return false;
        }
    }
}
