using Godot;
using Scripts.Entities;

namespace Factories
{
    public class PaddleVerticalFactory : Factory<PaddleVertical>
    {
        public PaddleVerticalFactory() : base(Constants.Scene.Paddle, Constants.Script.PaddleVertical) { }

        public override PaddleVertical GetInstance()
        {
            return (PaddleVertical)GD.InstanceFromId(base.GetInstanceIdWithScript());
        }
    }
}