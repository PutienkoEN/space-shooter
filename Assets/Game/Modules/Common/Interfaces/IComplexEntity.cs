using System;

namespace Game.Modules.Common.Interfaces
{
    public interface IComplexEntity
    {
        public event Action<bool> OnInGameStateChanged;
        public void OnUpdate(float deltaTime);
    }
}