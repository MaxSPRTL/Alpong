using Godot;
using Scripts.Entities;

namespace Factories
{
    public class BallFactory : Factory<Ball>
    {
        public BallFactory() : base(Constants.Scene.Ball, Constants.Script.Ball) { }

        public override Ball GetInstance()
        {
            return (Ball)GD.InstanceFromId(base.GetInstanceIdWithScript());
        }
    }
}