using System;
using Factories;
using Scripts.Entities;

namespace Services
{
    public static class PaddleService
    {

        public static Paddle GetNodePaddle(Constants.Side position)
        {
            switch (position)
            {
                case Constants.Side.TOP:
                    PaddleHorizontal paddleTop = new PaddleHorizontalFactory().GetInstance();
                    paddleTop.Position = Constants.Paddle.Position.Top;
                    return paddleTop;

                case Constants.Side.RIGHT:
                    PaddleVertical paddleRight = new PaddleVerticalFactory().GetInstance();
                    paddleRight.Position = Constants.Paddle.Position.Right;
                    return paddleRight;

                case Constants.Side.BOTTOM:
                    PaddleHorizontal paddleBottom = new PaddleHorizontalFactory().GetInstance();
                    paddleBottom.Position = Constants.Paddle.Position.Bottom;
                    return paddleBottom;

                case Constants.Side.LEFT:
                    PaddleVertical paddleLeft = new PaddleVerticalFactory().GetInstance();
                    paddleLeft.Position = Constants.Paddle.Position.Left;
                    return paddleLeft;

                default:
                    throw new ArgumentException("Argument is not handle by switch", nameof(position));

            }
        }
    }
}