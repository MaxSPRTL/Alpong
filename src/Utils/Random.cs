using System;

namespace Utils
{
    public sealed class Rand
    {
        private readonly static Random _random = new Random();

        public static Random GetRandom() { return _random; }
    }
}