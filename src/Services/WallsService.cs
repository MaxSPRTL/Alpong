using System;

namespace Services
{
    public static class WallsService
    {
        public static string GetWallNameBySide(Constants.Side side)
        {
            switch (side)
            {
                case Constants.Side.TOP:
                    return Constants.WallName.Top;
                case Constants.Side.RIGHT:
                    return Constants.WallName.Right;
                case Constants.Side.BOTTOM:
                    return Constants.WallName.Bottom;
                case Constants.Side.LEFT:
                    return Constants.WallName.Left;
                default:
                    throw new ArgumentException("Parameter has no equivalent of WallName");
            }
        }
    }
}