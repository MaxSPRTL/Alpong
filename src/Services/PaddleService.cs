using Godot;
using System;
using Constants.Paddle;

namespace Services
{
    public static class PaddleService
    {

        public static KinematicBody2D GetRandomNodePaddle()
        {
            PositionName paddlePosition = (PositionName)Utils.Rand.GetRandom().Next(Enum.GetValues(typeof(PositionName)).Length);
            return GetNodePaddle(paddlePosition);
        }

        public static KinematicBody2D GetNodePaddle(PositionName position = PositionName.BOTTOM)
        {
            switch (position)
            {
                case PositionName.TOP:
                    KinematicBody2D paddleTop = Factories.PaddleInstance.GetHorizontal();
                    paddleTop.Position = PositionVector.Top.Vector;
                    return paddleTop;

                case PositionName.LEFT:
                    KinematicBody2D paddleLeft = Factories.PaddleInstance.GetVertical();
                    paddleLeft.Position = PositionVector.Left.Vector;
                    return paddleLeft;

                case PositionName.RIGHT:
                    KinematicBody2D paddleRight = Factories.PaddleInstance.GetVertical();
                    paddleRight.Position = PositionVector.Right.Vector;
                    return paddleRight;

                default:
                case PositionName.BOTTOM:
                    KinematicBody2D paddleBottom = Factories.PaddleInstance.GetHorizontal();
                    paddleBottom.Position = PositionVector.Bottom.Vector;
                    return paddleBottom;
            }
        }
    }
}