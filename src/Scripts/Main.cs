using Godot;
using Factories;
using Scripts.Entities;
using Scripts.Blocks;
using System.Collections.Generic;
using Logic;
using Services;

namespace Scripts
{
    public class Main : Node2D
    {
        private const float BallSpawnWaitTime = 3f;
        private List<Player> _players = new List<Player>();

        public override void _Ready()
        {
            base._Ready();

            this.InitSignals();
        }

        private void InitSignals()
        {
            GetNode(Constants.WallName.Left).Connect("BodyEntered", this, nameof(OnWallBodyEntered));
            GetNode(Constants.WallName.Right).Connect("BodyEntered", this, nameof(OnWallBodyEntered));
            GetNode(Constants.WallName.Top).Connect("BodyEntered", this, nameof(OnWallBodyEntered));
            GetNode(Constants.WallName.Bottom).Connect("BodyEntered", this, nameof(OnWallBodyEntered));

            GetNode<Timer>("BallSpawnTimer").Connect("timeout", this, nameof(OnBallSpawnTimerTimeout));
            GetNode<HUD>("HUD").Connect("StartGame", this, nameof(NewGame));
        }

        private void NewGame()
        {
            this.AddPlayer(Constants.Side.BOTTOM, new Human());
            // this.AddPlayer(Constants.Side.TOP, new Computer());
            this.AddBall();
            this.StartBallSpawner();
            GetNode<AudioStreamPlayer>("Music").Play();
        }

        private void AddPlayer(Constants.Side side, Player player)
        {
            Wall wall = (Wall)GetNode(WallsService.GetWallNameBySide(side));
            player.Init(side, wall);
            CallDeferred("add_child", player);
            _players.Add(player);
        }

        private void StartBallSpawner()
        {
            Timer ballSpawnTimer = GetNode<Timer>("BallSpawnTimer");
            ballSpawnTimer.WaitTime = BallSpawnWaitTime;
            ballSpawnTimer.Start();
        }

        public void OnBallSpawnTimerTimeout()
        {
            this.AddBall();
        }

        private void AddBall()
        {
            Ball ball = new BallFactory().GetInstance();
            Vector2 viewportCenter = GetViewportRect().Size / 2;
            ball.Position = viewportCenter;
            CallDeferred("add_child", ball);
            ball.Connect("BallHitPaddle", this, nameof(OnBallHittingPaddle));
        }

        public void OnBallHittingPaddle()
        {
            this.PlayRandomBallSound();
        }

        private void PlayRandomBallSound()
        {
            int rand = Utils.Rand.Random.Next(0, 3);

            switch (rand)
            {
                case 0:
                    GetNode<AudioStreamPlayer>("BallHitPaddle1").Play();
                    break;
                case 1:
                    GetNode<AudioStreamPlayer>("BallHitPaddle2").Play();
                    break;
                case 2:
                    GetNode<AudioStreamPlayer>("BallHitPaddle3").Play();
                    break;
                default:
                    break;
            }
        }

        public void OnWallBodyEntered(Node body, Constants.Side side)
        {
            if (body is Ball ball)
            {
                this.HandleWallWhenBallEntered(side, ball);
            }
        }

        private void HandleWallWhenBallEntered(Constants.Side side, Ball ball)
        {
            Player player = this.FoundPlayerForSide(side);
            if (player != null)
            {
                this.PlayRandomLoosingLifeSound();
                player.Hit();
                ball.Destroy();
                this.RemovePlayersWithoutLives();
                this.HandleEndGame();
            }
        }

        private void PlayRandomLoosingLifeSound()
        {
            if (Utils.Rand.Random.Next(0, 2) == 0)
            {
                GetNode<AudioStreamPlayer>("LoosingLife1").Play();
            }
            else
            {
                GetNode<AudioStreamPlayer>("LoosingLife2").Play();
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

        private void RemovePlayersWithoutLives()
        {
            for (int playerIndex = _players.Count - 1; playerIndex > -1; playerIndex--)
            {
                if (_players[playerIndex].NbLives <= 0)
                {
                    _players[playerIndex].Destroy();
                    _players.RemoveAt(playerIndex);
                }
            }
        }

        private void HandleEndGame()
        {
            if (_players.Count == 0)
                this.EndGame();
        }

        private void EndGame()
        {
            GetNode<AudioStreamPlayer>("Music").Stop();
            this.RemoveAllBalls();
            this.StopBallSpawner();
            GetNode<HUD>("HUD").ShowGameOver();
        }

        private void RemoveAllBalls()
        {
            GetTree().CallGroup(Constants.Group.Balls, "Destroy");
        }

        private void StopBallSpawner()
        {
            Timer ballSpawnTimer = GetNode<Timer>("BallSpawnTimer");
            ballSpawnTimer.Stop();
        }
    }
}
