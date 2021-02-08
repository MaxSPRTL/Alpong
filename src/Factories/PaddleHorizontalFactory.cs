using Godot;
using Scripts.Entities;

namespace Factories
{
    public class PaddleHorizontalFactory : Factory<PaddleHorizontal>
    {
        public PaddleHorizontalFactory() : base(Constants.Scene.Paddle, Constants.Script.PaddleHorizontal) { }

        public override PaddleHorizontal GetInstance()
        {
            return (PaddleHorizontal)GD.InstanceFromId(base.GetInstanceIdWithScript());
        }
    }
}