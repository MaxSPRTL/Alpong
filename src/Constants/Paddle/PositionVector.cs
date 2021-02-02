using Godot;

namespace Constants.Paddle
{
    public sealed class PositionVector
    {

        public static Vector2 Top { get { return new Vector2(213, 8); } }
        public static Vector2 Bottom { get { return new Vector2(213, 232); } }
        public static Vector2 Left { get { return new Vector2(101, 120); } }
        public static Vector2 Right { get { return new Vector2(325, 120); } }
    }
}