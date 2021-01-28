using Godot;

namespace Constants.Paddle
{
    public sealed class Position
    {
        private Position(Vector2 value) { Value = value; }

        public Vector2 Value { get; set; }

        public static Position Top { get { return new Position(new Vector2(213, 8)); } }
        public static Position Bottom { get { return new Position(new Vector2(213, 232)); } }
        public static Position Left { get { return new Position(new Vector2(101, 120)); } }
        public static Position Right { get { return new Position(new Vector2(325, 120)); } }
    }
}