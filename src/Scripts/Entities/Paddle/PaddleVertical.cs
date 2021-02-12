using Godot;

namespace Scripts.Entities
{
    public class PaddleVertical : Paddle
    {
        public override void _Ready()
        {
            _rotation = 90;
            base._Ready();
        }

    }
}