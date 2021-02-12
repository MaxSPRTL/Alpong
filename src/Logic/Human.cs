using Godot;

namespace Logic
{
    public class Human : Player
    {

        protected override Vector2 GetHorizontalMovement()
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

            return velocity;
        }

        protected override Vector2 GetVerticalMovement()
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

            return velocity;
        }
    }
}