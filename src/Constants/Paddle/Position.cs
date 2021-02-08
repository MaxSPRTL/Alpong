using Godot;

namespace Constants.Paddle
{
    public sealed class Position
    {

        public static Vector2 Top { get { return new Vector2(213, 14); } }
        public static Vector2 Bottom { get { return new Vector2(213, 226); } }
        public static Vector2 Left { get { return new Vector2(110, 120); } }
        public static Vector2 Right { get { return new Vector2(322, 120); } }
    }
}