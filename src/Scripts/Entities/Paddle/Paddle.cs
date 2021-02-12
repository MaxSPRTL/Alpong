using Godot;

namespace Scripts.Entities
{
    public abstract class Paddle : KinematicBody2D
    {
        protected int _speed = 150;
        protected float _rotation = 0;

        public override void _Ready()
        {
            base._Ready();
            RotationDegrees += _rotation;
        }

        public void Move(Vector2 movementVector, float delta) {
            MoveAndCollide(movementVector.Normalized() * delta * _speed);
        }

        public void Destroy()
        {
            GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred("disabled", true);
            CallDeferred("free");
        }
    }
}