namespace Scripts.Blocks
{
    public abstract class WallBottom : Wall
    {
        public override void _Ready()
        {
            base._Ready();
            Side = Constants.Side.BOTTOM;
        }
    }
}