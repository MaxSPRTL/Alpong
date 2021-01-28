namespace Constants.Scripts
{
    public sealed class Paddle
    {
        private Paddle(string value) { Value = value; }

        public string Value { get; set; }

        public static Paddle PaddleHorizontal { get { return new Paddle("res://src/Scripts/Entities/Paddle/PaddleHorizontal.cs"); } }
        public static Paddle PaddleVertical { get { return new Paddle("res://src/Scripts/Entities/Paddle/PaddleVertical.cs"); } }
    }
}