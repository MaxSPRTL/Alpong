using Godot;

namespace Factories
{
    public class Paddle
    {
        private static PackedScene _paddleScene = null;

        private static PackedScene GetPaddleScene()
        {
            if (_paddleScene == null)
            {
                _paddleScene = GD.Load<PackedScene>("res://src/Scenes/Entities/Paddle/Paddle.tscn");
            }
            return _paddleScene;
        }

        public static KinematicBody2D GetHorizontalPaddle()
        {
            string scriptName = Constants.Scripts.Paddle.PaddleHorizontal.Value;
            return GetInstance(scriptName);
        }

        public static KinematicBody2D GetVerticalPaddle()
        {
            string scriptName = Constants.Scripts.Paddle.PaddleVertical.Value;
            return GetInstance(scriptName);
        }

        private static KinematicBody2D GetInstance(string scriptName)
        {
            KinematicBody2D paddleInstance = (KinematicBody2D)GetPaddleScene().Instance();
            ulong paddleInstanceId = paddleInstance.GetInstanceId();


            Resource script = GD.Load(scriptName);
            paddleInstance.SetScript(script);

            return (KinematicBody2D)GD.InstanceFromId(paddleInstanceId);
        }
    }
}