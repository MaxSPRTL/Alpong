using System;

namespace Utils
{
    public sealed class Rand
    {
        public readonly static Random Random = new Random();

        public static float RandRange(float min, float max)
        {
            return (float)Random.NextDouble() * (max - min) + min;
        }
    }
}