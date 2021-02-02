using Godot;
using Scripts.Entities;

namespace Factories
{
    public class BallFactory : Factory<Ball>
    {
        public BallFactory() : base(Constants.Scene.Ball) { }

        public override Ball GetInstance()
        {
            string scriptName = Constants.Script.Ball;
            return (Ball)GD.InstanceFromId(base.AttachScript(scriptName));
        }
    }
}