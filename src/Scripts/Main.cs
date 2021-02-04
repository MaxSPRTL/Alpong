using Godot;
using Godot.Collections;
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
            this.initSignals();
            this.NewGame();
        }

        public void initSignals()
        {
            GetNode("WallLeft").Connect("BodyEntered", this, nameof(OnWallBodyEntered));
            GetNode("WallRight").Connect("BodyEntered", this, nameof(OnWallBodyEntered));
            GetNode("WallTop").Connect("BodyEntered", this, nameof(OnWallBodyEntered));
            GetNode("WallBottom").Connect("BodyEntered", this, nameof(OnWallBodyEntered));
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

        public void OnWallBodyEntered(Node body, Constants.Side side)
        {
            if (body is Ball ball)
            {
                ball.QueueFree();
            }
        }
    }
}
