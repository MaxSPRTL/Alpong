using Godot;

namespace Factories
{
    public abstract class Factory<T>
    {
        protected PackedScene _scene = null;
        protected Resource _script = null;
        protected string _scenePath;
        protected string _scriptPath;

        public Factory(string scenePath, string scriptPath)
        {
            this._scenePath = scenePath;
            this._scriptPath = scriptPath;
        }

        protected PackedScene GetScene()
        {
            if (_scene == null)
            {
                _scene = GD.Load<PackedScene>(_scenePath);
            }
            return _scene;
        }

        protected Resource GetScript()
        {
            if (_script == null)
            {
                _script = GD.Load(_scriptPath);
            }
            return _script;
        }

        protected ulong GetInstanceIdWithScript()
        {
            Node instance = this.GetScene().Instance();
            ulong instanceId = instance.GetInstanceId();
            instance.SetScript(this.GetScript());
            return instanceId;
        }

        public abstract T GetInstance();
    }
}