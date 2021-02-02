using System;

namespace Utils
{
    public sealed class Rand
    {
        public readonly static Random _random = new Random();

        public static float RandRange(float min, float max)
        {
            return (float)_random.NextDouble() * (max - min) + min;
        }
    }
}