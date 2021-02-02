using Godot;
using Scripts.Entities;

namespace Factories
{
    public class PaddleVerticalFactory : Factory<PaddleVertical>
    {
        public PaddleVerticalFactory() : base(Constants.Scene.Paddle) { }

        public override PaddleVertical GetInstance()
        {
            string scriptName = Constants.Script.PaddleVertical;
            return (PaddleVertical)GD.InstanceFromId(base.AttachScript(scriptName));
        }
    }
}