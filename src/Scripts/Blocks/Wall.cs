using Godot;

namespace Scripts.Blocks
{
    public abstract class Wall : Area2D
    {
        public Constants.Side Side;

        [Signal]
        public delegate void BodyEntered(Node body, Constants.Side side);

        public override void _Ready()
        {
            base._Ready();
            this.Connect("body_entered", this, nameof(OnBodyEntered));
        }

        public void OnBodyEntered(Node body)
        {
            EmitSignal(nameof(BodyEntered), body, Side);
        }
    }
}