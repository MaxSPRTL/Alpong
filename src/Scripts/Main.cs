using Godot;
using Services;
using Factories;
using Scripts.Entities;
using Scripts.Blocks;
using System.Collections.Generic;
using Logic;

namespace Scripts
{
    public class Main : Node2D
    {

        private List<Player> _players = new List<Player>();
        private List<Ball> _balls = new List<Ball>();

        public override void _Ready()
        {
            base._Ready();
            this.initSignals();
            this.NewGame();
        }

        private void initSignals()
        {
            GetNode("WallLeft").Connect("BodyEntered", this, nameof(OnWallBodyEntered));
            GetNode("WallRight").Connect("BodyEntered", this, nameof(OnWallBodyEntered));
            GetNode("WallTop").Connect("BodyEntered", this, nameof(OnWallBodyEntered));
            GetNode("WallBottom").Connect("BodyEntered", this, nameof(OnWallBodyEntered));
        }

        private void NewGame()
        {
            this.AddPlayer(Constants.Side.BOTTOM);
            this.AddBall();
            this.StartBalls();
        }

        private void AddPlayer(Constants.Side side)
        {
            Player player = null;

            switch (side)
            {
                case Constants.Side.TOP:
                    player = GetPlayer(Constants.WallName.Top, side);
                    break;
                case Constants.Side.RIGHT:
                    player = GetPlayer(Constants.WallName.Right, side);
                    break;
                case Constants.Side.BOTTOM:
                    player = GetPlayer(Constants.WallName.Bottom, side);
                    break;
                case Constants.Side.LEFT:
                    player = GetPlayer(Constants.WallName.Left, side);
                    break;
            }

            if (player != null)
            {
                _players.Add(player);
                AddChild(player.Paddle);
            }
        }

        private Player GetPlayer(string wallName, Constants.Side side)
        {
            int nbLives = 10;
            Paddle paddle = PaddleService.GetNodePaddle(side);
            Wall wall = (Wall)GetNode(wallName);
            return new Human(paddle, wall, side, nbLives);
        }

        private void AddBall()
        {
            Ball ball = new BallFactory().GetInstance();
            _balls.Add(ball);
            AddChild(ball);
        }

        private void StartBalls()
        {
            foreach (Ball ball in _balls)
            {
                if (ball.IsStarted) continue;

                float ballDirection = Utils.Rand.RandRange(0, 360);
                Vector2 ballPosition = GetViewportRect().Size / 2;
                ball.Start(ballPosition, ballDirection);
            }
        }

        public void OnWallBodyEntered(Node body, Constants.Side side)
        {
            if (body is Ball ball)
            {
                this.HandleWallWhenBallEntered(side, ball);
            }
        }

        public void HandleWallWhenBallEntered(Constants.Side side, Ball ball)
        {
            Player player = this.FoundPlayerForSide(side);
            if (player != null)
            {
                player.NbLives -= 1;
                this.DeleteBall(ball);
                this.AddBall();
                this.StartBalls();
            }
        }

        private Player FoundPlayerForSide(Constants.Side side)
        {
            foreach (Player player in _players)
            {
                if (player.Side == side) return player;
            }

            return null;
        }

        private void DeleteBall(Ball ball)
        {
            ball.QueueFree();
        }
    }
}
