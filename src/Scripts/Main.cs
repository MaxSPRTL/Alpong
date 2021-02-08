using Godot;
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
            GetNode(Constants.WallName.Left).Connect("BodyEntered", this, nameof(OnWallBodyEntered));
            GetNode(Constants.WallName.Right).Connect("BodyEntered", this, nameof(OnWallBodyEntered));
            GetNode(Constants.WallName.Top).Connect("BodyEntered", this, nameof(OnWallBodyEntered));
            GetNode(Constants.WallName.Bottom).Connect("BodyEntered", this, nameof(OnWallBodyEntered));
            GetNode<Timer>("BallSpawnTimer").Connect("timeout", this, nameof(OnBallSpawnTimerTimeout));
        }

        private void NewGame()
        {
            this.AddPlayer(Constants.Side.BOTTOM);
            this.AddBall();
            this.StartBallSpawner();
        }

        private void AddPlayer(Constants.Side side)
        {
            string wallName = Services.WallsService.GetWallNameBySide(side);
            Wall wall = (Wall)GetNode(wallName);

            Label livesLabel = Services.LabelsService.GetLivesLabelNode(side);

            Player player = new Human(side, wall, livesLabel);

            _players.Add(player);
            CallDeferred("add_child", player.Paddle);
            CallDeferred("add_child", player.LivesLabel);
        }

        private void AddBall()
        {
            Ball ball = new BallFactory().GetInstance();
            Vector2 viewportCenter = GetViewportRect().Size / 2;
            ball.Position = viewportCenter;
            CallDeferred("add_child", ball);
        }

        private void StartBallSpawner()
        {
            Timer ballSpawnTimer = GetNode<Timer>("BallSpawnTimer");
            ballSpawnTimer.WaitTime = 5;
            ballSpawnTimer.Start();
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
                ball.Destroy();
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

        public void OnBallSpawnTimerTimeout()
        {
            this.AddBall();
        }
    }
}
