using Godot;

namespace Scripts.Entities.Paddle
{
    public class PaddleVertical : Paddle
    {
        public override void _Ready()
        {
            _rotation = 90;
            base._Ready();
        }
        public override Vector2 GetMovement()
        {
            Vector2 velocity = new Vector2();

            if (Input.IsActionPressed("ui_down"))
            {
                velocity.y += 1;
            }

            if (Input.IsActionPressed("ui_up"))
            {
                velocity.y -= 1;
            }

            velocity = velocity.Normalized() * _speed;
            return velocity;
        }

    }
}