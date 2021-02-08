using System;
using Factories;
using Scripts.Entities;

namespace Services
{
    public static class PaddleService
    {

        public static Paddle GetRandomNodePaddle()
        {
            Constants.Side paddlePosition = (Constants.Side)Utils.Rand._random.Next(Enum.GetValues(typeof(Constants.Side)).Length);
            return GetNodePaddle(paddlePosition);
        }

        public static Paddle GetNodePaddle(Constants.Side position = Constants.Side.BOTTOM)
        {
            switch (position)
            {
                case Constants.Side.TOP:
                    PaddleHorizontal paddleTop = new PaddleHorizontalFactory().GetInstance();
                    paddleTop.Position = Constants.Paddle.Position.Top;
                    return paddleTop;

                case Constants.Side.LEFT:
                    PaddleVertical paddleLeft = new PaddleVerticalFactory().GetInstance();
                    paddleLeft.Position = Constants.Paddle.Position.Left;
                    return paddleLeft;

                case Constants.Side.RIGHT:
                    PaddleVertical paddleRight = new PaddleVerticalFactory().GetInstance();
                    paddleRight.Position = Constants.Paddle.Position.Right;
                    return paddleRight;

                default:
                case Constants.Side.BOTTOM:
                    PaddleHorizontal paddleBottom = new PaddleHorizontalFactory().GetInstance();
                    paddleBottom.Position = Constants.Paddle.Position.Bottom;
                    return paddleBottom;
            }
        }
    }
}