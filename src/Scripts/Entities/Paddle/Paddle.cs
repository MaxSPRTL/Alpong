using Godot;

namespace Scripts.Entities.Paddle
{
    public abstract class Paddle : KinematicBody2D
    {
        protected int _speed = 150;
        private float _rotation = 0;

        public override void _Ready()
        {
            base._Ready();
            RotationDegrees += _rotation;
        }

        public override void _PhysicsProcess(float delta)
        {
            Vector2 movement = this.GetMovement();
            MoveAndCollide(movement * delta);
        }

        public abstract Vector2 GetMovement();
    }
}