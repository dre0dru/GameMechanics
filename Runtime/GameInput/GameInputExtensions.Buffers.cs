using UnityEngine;

namespace Dre0Dru.GameInput
{
    public static partial class GameInputExtensions
    {
        public static void Buffer(this TimeBuffer inputBuffer)
        {
            inputBuffer.Buffer(Time.time);
        }

        public static void Buffer(this TimeBuffer inputBuffer, float timeOut)
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

        public static void Buffer(this TimeBuffer inputBuffer,
            Button inputButton)
        {
            inputBuffer.Buffer(inputButton.PressTime);
        }

        public static void Buffer(this TimeBuffer inputBuffer,
            Button inputButton, float timeOut)
        {
            inputBuffer.Buffer(inputButton.PressTime, timeOut);
        }

        public static void Buffer<T>(this TimeInputBuffer<T> inputBuffer,
            Button<T> inputButton)
        {
            inputBuffer.Buffer(inputButton.Value, inputButton.PressTime);
        }

        public static void Buffer<T>(this TimeInputBuffer<T> inputBuffer,
            Button<T> inputButton, float timeOut)
        {
            inputBuffer.Buffer(inputButton.Value, inputButton.PressTime, timeOut);
        }

        public static bool CanBeConsumed(this TimeBuffer inputBuffer)
        {
            return inputBuffer.CanBeConsumed(Time.time);
        }

        public static void Consume(this TimeBuffer inputBuffer)
        {
            inputBuffer.Consume(Time.time);
        }

        public static bool TryToConsume(this TimeBuffer inputBuffer)
        {
            return inputBuffer.TryToConsume(Time.time);
        }

        public static bool TryToConsume(this TimeBuffer inputBuffer, float time)
        {
            if (inputBuffer.CanBeConsumed(time))
            {
                inputBuffer.Consume(time);
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
                inputBuffer.Consume(time);
                value = inputBuffer.Value;
                return true;
            }

            value = default;
            return false;
        }
    }
}
