using System;
using Constants.Paddle;
using Factories;
using Scripts.Entities;

namespace Services
{
    public static class PaddleService
    {

        public static Paddle GetRandomNodePaddle()
        {
            PositionName paddlePosition = (PositionName)Utils.Rand._random.Next(Enum.GetValues(typeof(PositionName)).Length);
            return GetNodePaddle(paddlePosition);
        }

        public static Paddle GetNodePaddle(PositionName position = PositionName.BOTTOM)
        {
            switch (position)
            {
                case PositionName.TOP:
                    PaddleHorizontal paddleTop = new PaddleHorizontalFactory().GetInstance();
                    paddleTop.Position = PositionVector.Top;
                    return paddleTop;

                case PositionName.LEFT:
                    PaddleVertical paddleLeft = new PaddleVerticalFactory().GetInstance();
                    paddleLeft.Position = PositionVector.Left;
                    return paddleLeft;

                case PositionName.RIGHT:
                    PaddleVertical paddleRight = new PaddleVerticalFactory().GetInstance();
                    paddleRight.Position = PositionVector.Right;
                    return paddleRight;

                default:
                case PositionName.BOTTOM:
                    PaddleHorizontal paddleBottom = new PaddleHorizontalFactory().GetInstance();
                    paddleBottom.Position = PositionVector.Bottom;
                    return paddleBottom;
            }
        }
    }
}