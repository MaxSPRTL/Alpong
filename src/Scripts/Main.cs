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
                CallDeferred("add_child", player.Paddle);
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
            Vector2 viewportCenter = GetViewportRect().Size / 2;
            ball.Position = viewportCenter;
            CallDeferred("add_child", ball);
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
                player.Hit();
                ball.Delete();
                this.AddBall();
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
    }
}
