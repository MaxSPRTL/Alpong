using Godot;

namespace Scripts.Entities
{
    public class Ball : KinematicBody2D
    {
        private int _speed = 100;

        private Vector2 _velocity = new Vector2();

        public void Start(Vector2 position, float direction)
        {
            Rotation = direction;
            Position = position;
            _velocity = new Vector2(_speed, 0).Rotated(Rotation);
        }

        public override void _PhysicsProcess(float delta)
        {
            KinematicCollision2D collision = MoveAndCollide(_velocity * delta);
            this.HandleCollision(collision);
        }

        public void HandleCollision(KinematicCollision2D collision)
        {
            if (collision == null)
            {
                return;
            }

            _velocity = _velocity.Bounce(collision.Normal);
        }
    }
}