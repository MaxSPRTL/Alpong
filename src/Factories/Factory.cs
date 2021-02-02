using Godot;

namespace Factories
{
    public abstract class Factory<T>
    {
        protected PackedScene _scene = null;

        protected string _scenePath;

        public Factory(string scenePath)
        {
            this._scenePath = scenePath;
        }

        protected PackedScene GetScene()
        {
            if (_scene == null)
            {
                _scene = GD.Load<PackedScene>(_scenePath);
            }
            return _scene;
        }

        protected ulong AttachScript(string scriptName) {
            Node instance = GetScene().Instance();
            ulong instanceId = instance.GetInstanceId();

            Resource script = GD.Load(scriptName);
            instance.SetScript(script);

            return instanceId;
        }

        public abstract T GetInstance();
    }
}