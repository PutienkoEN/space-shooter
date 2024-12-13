using System;

namespace Game.Modules.Common.Interfaces
{
    public interface IEntity
    {
        public event Action<bool> OnInGameStateChanged;
        public void Update(float deltaTime);
    }
}