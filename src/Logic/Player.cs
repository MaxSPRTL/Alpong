using Scripts.Entities;
using Scripts.Blocks;
using Godot;

namespace Logic
{
    public abstract class Player : Node
    {
        public Constants.Side Side;
        public int NbLives = 10;
        public Paddle Paddle;
        public Wall Wall;
        public Label LivesLabel;

        public virtual void Init(Constants.Side side, Wall wall)
        {
            this.Side = side;
            this.Wall = wall;

            Label livesLabel = Services.LabelsService.GetLivesLabelNode(side);
            this.LivesLabel = livesLabel;
            CallDeferred("add_child", LivesLabel);

            Paddle paddle = Services.PaddleService.GetNodePaddle(side);
            this.Paddle = paddle;
            CallDeferred("add_child", Paddle);

            this.UpdateLivesLabel();
        }

        public void UpdateLivesLabel()
        {
            this.LivesLabel.Text = this.NbLives.ToString();
        }

        public void Hit()
        {
            this.NbLives -= 1;
            this.UpdateLivesLabel();
        }

        public void Destroy()
        {
            this.Paddle.Destroy();
            this.LivesLabel.CallDeferred("free");
            CallDeferred("free");
        }

        public override void _PhysicsProcess(float delta)
        {
            Vector2 movement = this.GetMovement();
            this.Paddle.Move(movement, delta);
        }

        protected Vector2 GetMovement()
        {
            if (this.Paddle is PaddleHorizontal)
            {
                return this.GetHorizontalMovement();
            }
            else
            {
                return this.GetVerticalMovement();
            }
        }

        protected abstract Vector2 GetHorizontalMovement();

        protected abstract Vector2 GetVerticalMovement();

    }
}