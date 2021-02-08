using Scripts.Entities;
using Scripts.Blocks;
using Services;
using Godot;

namespace Logic
{
    public abstract class Player
    {
        public Constants.Side Side;
        public Paddle Paddle;
        public Wall Wall;
        public int NbLives;
        public Label LivesLabel;

        public Player(Constants.Side side, Wall wall, Label livesLabel)
        {
            this.Side = side;
            this.Paddle = PaddleService.GetNodePaddle(side);
            this.Wall = wall;
            this.NbLives = 10;
            this.LivesLabel = livesLabel;
            this.LivesLabel.Text = this.NbLives.ToString();
        }

        public void Hit()
        {
            this.NbLives -= 1;
            this.LivesLabel.Text = this.NbLives.ToString();
        }

        public void Destroy()
        {
            this.Paddle.Destroy();
            this.LivesLabel.CallDeferred("free");
        }
    }
}