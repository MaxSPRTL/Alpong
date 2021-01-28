using Godot;

namespace Scripts
{
    public class Main : Node2D
    {
        public override void _Ready()
        {
            base._Ready();
            this.InitPaddles();
        }

        private void InitPaddles()
        {
            this.AddPaddle(Factories.Paddle.GetHorizontalPaddle(), Constants.Paddle.Position.Top.Value);
            this.AddPaddle(Factories.Paddle.GetHorizontalPaddle(), Constants.Paddle.Position.Bottom.Value);
        }

        private void AddPaddle(KinematicBody2D paddleInstance, Vector2 paddlePosition)
        {
            paddleInstance.Position = paddlePosition;
            AddChild(paddleInstance);
        }
    }
}
