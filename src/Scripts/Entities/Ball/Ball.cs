using Godot;

namespace Scripts.Entities
{
    public class Ball : KinematicBody2D
    {
        private int _initialSpeed = 100;
        private float _increaseSpeed = 0f;
        public Vector2 Velocity = new Vector2();
        public bool IsStarted = false;

        public override void _EnterTree()
        {
            base._EnterTree();

            AddToGroup(Constants.Group.Balls);
        }

        public override void _Ready()
        {
            base._Ready();

            this.InitSignals();
            float ballDirection = Utils.Rand.RandRange(0, 360);
            this.Start(ballDirection);
            this.StartSpeedTimer();
        }

        public void InitSignals()
        {
            GetNode<Timer>("SpeedTimer").Connect("timeout", this, nameof(OnSpeedTimerTimeout));
        }

        public void OnSpeedTimerTimeout()
        {
            this._increaseSpeed += 0.10f;
            Velocity += (Velocity * this._increaseSpeed);
        }

        private void StartSpeedTimer()
        {
            Timer speedTimer = GetNode<Timer>("SpeedTimer");
            speedTimer.WaitTime = 8;
            speedTimer.Start();
        }


        public void Start(float direction)
        {
            Rotation = direction;
            Velocity = new Vector2(_initialSpeed, 0).Rotated(Rotation);
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

        public void Destroy()
        {
            GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred("disabled", true);
            CallDeferred("free");
        }
    }
}