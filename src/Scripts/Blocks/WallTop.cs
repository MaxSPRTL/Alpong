namespace Scripts.Blocks
{
    public abstract class WallTop : Wall
    {
        public override void _Ready()
        {
            base._Ready();
            Side = Constants.Side.TOP;
        }
    }
}