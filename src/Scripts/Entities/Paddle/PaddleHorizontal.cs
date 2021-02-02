using Godot;

namespace Scripts.Entities
{
    public class PaddleHorizontal : Paddle
    {
        public override Vector2 GetMovement()
        {
            Vector2 velocity = new Vector2();

            if (Input.IsActionPressed("ui_right"))
            {
                velocity.x += 1;
            }

            if (Input.IsActionPressed("ui_left"))
            {
                velocity.x -= 1;
            }

            velocity = velocity.Normalized() * _speed;
            return velocity;
        }

    }
}