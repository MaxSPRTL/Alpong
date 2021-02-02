using Godot;
using Scripts.Entities;

namespace Factories
{
    public class PaddleHorizontalFactory : Factory<PaddleHorizontal>
    {
        public PaddleHorizontalFactory() : base(Constants.Scene.Paddle) { }

        public override PaddleHorizontal GetInstance()
        {
            string scriptName = Constants.Script.PaddleHorizontal;
            return (PaddleHorizontal)GD.InstanceFromId(base.AttachScript(scriptName));
        }
    }
}