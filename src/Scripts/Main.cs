using Godot;
using Services;
using Factories;
using Scripts.Entities;

namespace Scripts
{
    public class Main : Node2D
    {

        public override void _Ready()
        {
            base._Ready();
            this.NewGame();
        }

        public void NewGame()
        {
            this.AddPaddle();
            this.AddBall();
        }

        private void AddPaddle()
        {
            AddChild(PaddleService.GetNodePaddle());
        }

        private void AddBall()
        {
            Ball ball = new BallFactory().GetInstance();
            AddChild(ball);

            float ballDirection = Utils.Rand.RandRange(0, 360);
            Vector2 ballPosition = GetViewportRect().Size / 2;
            ball.Start(ballPosition, ballDirection);
        }
    }
}
