namespace Scripts.Blocks
{
    public abstract class WallRight : Wall
    {
        public override void _Ready()
        {
            base._Ready();
            Side = Constants.Side.RIGHT;
        }
    }
}