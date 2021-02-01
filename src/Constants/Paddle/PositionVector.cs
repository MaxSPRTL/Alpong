using Godot;

namespace Constants.Paddle
{
    public sealed class PositionVector
    {
        private PositionVector(Vector2 vector) { Vector = vector; }

        public Vector2 Vector { get; set; }

        public static PositionVector Top { get { return new PositionVector(new Vector2(213, 8)); } }
        public static PositionVector Bottom { get { return new PositionVector(new Vector2(213, 232)); } }
        public static PositionVector Left { get { return new PositionVector(new Vector2(101, 120)); } }
        public static PositionVector Right { get { return new PositionVector(new Vector2(325, 120)); } }
    }
}