using Godot;
using Scripts.Entities;

namespace Logic
{
    public class Computer : Player
    {
        private Vector2 _previousPaddlePosition;
        private Vector2 _targetPaddlePosition;
        private bool _paddleIsMoving = false;

        protected override Vector2 GetHorizontalMovement()
        {
            return this.GetRandomTargetPosition();
        }

        protected override Vector2 GetVerticalMovement()
        {
            return this.GetRandomTargetPosition();
        }

        private Vector2 GetRandomTargetPosition()
        {
            if (this.Paddle.Position.IsEqualApprox(this._previousPaddlePosition))
            {
                this._paddleIsMoving = false;
            }

            this._previousPaddlePosition = this.Paddle.Position;

            if (!_paddleIsMoving)
            {
                this._paddleIsMoving = true;
                this._targetPaddlePosition = new Vector2();

                if (this.Paddle is PaddleHorizontal)
                {
                    this._targetPaddlePosition.x = Utils.Rand.Random.Next(-1, 2);
                }
                else
                {
                    this._targetPaddlePosition.y = Utils.Rand.Random.Next(-1, 2);
                }

            }

            return this._targetPaddlePosition;
        }
    }
}