using Godot;

namespace Scripts.Entities
{
    public class Ball : KinematicBody2D
    {
        private int _speed = 200;
        public Vector2 Velocity = new Vector2();
        public bool IsStarted = false;

        public void Start(Vector2 position, float direction)
        {
            Rotation = direction;
            Position = position;
            Velocity = new Vector2(_speed, 0).Rotated(Rotation);
            IsStarted = true;
        }

        public override void _PhysicsProcess(float delta)
        {
            KinematicCollision2D collision = MoveAndCollide(Velocity * delta);
            this.HandleCollision(collision);
        }

        public void HandleCollision(KinematicCollision2D collision)
        {
            if (collision == null)
            {
                return;
            }

            Velocity = Velocity.Bounce(collision.Normal);
        }

        public void OnVisibilityNotifier2DScreenExited()
        {
            QueueFree();
        }

        public void Delete()
        {
            GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred("disabled", true);
            CallDeferred("free");
        }
    }
}