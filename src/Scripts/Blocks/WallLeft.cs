namespace Scripts.Blocks
{
    public abstract class WallLeft : Wall
    {
        public override void _Ready()
        {
            base._Ready();
            Side = Constants.Side.LEFT;
        }
    }
}