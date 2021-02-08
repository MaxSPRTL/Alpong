using Godot;
using System;

namespace Services
{
    public static class LabelsService
    {

        public static Label GetLivesLabelNode(Constants.Side side)
        {
            Label livesLabel = new Label();

            livesLabel.SetSize(new Vector2(16, 16));
            livesLabel.Align = Label.AlignEnum.Center;
            livesLabel.Valign = Label.VAlign.Center;

            Vector2 labelPosition = LabelsService.GetLivesLabelPositionBySide(side);
            livesLabel.SetPosition(labelPosition);

            return livesLabel;
        }
        public static Vector2 GetLivesLabelPositionBySide(Constants.Side side)
        {
            {
                switch (side)
                {
                    case Constants.Side.TOP:
                        return Constants.Labels.Position.Top;
                    case Constants.Side.RIGHT:
                        return Constants.Labels.Position.Right;
                    case Constants.Side.BOTTOM:
                        return Constants.Labels.Position.Bottom;
                    case Constants.Side.LEFT:
                        return Constants.Labels.Position.Left;
                    default:
                        throw new ArgumentException("Parameter has no equivalent of Label position");
                }
            }
        }
    }
}