using System;

namespace Game.Modules.Common.Interfaces
{
    public interface ISimpleEntity
    {
        public event Action<ISimpleEntity> OnDestroy;
        public void OnUpdate(float deltaTime);
        public void Destroy();
    }
}