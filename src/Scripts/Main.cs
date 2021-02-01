using Godot;
using Services;

namespace Scripts
{
    public class Main : Node2D
    {
        public override void _Ready()
        {
            base._Ready();
            this.InitPaddles();
        }

        private void InitPaddles()
        {
            AddChild(PaddleService.GetRandomNodePaddle());
        }
    }
}
