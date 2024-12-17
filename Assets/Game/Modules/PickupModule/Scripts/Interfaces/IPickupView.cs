using System;
using Game.Modules.Common.Interfaces;

namespace Game.PickupModule.Scripts
{
    public interface IPickupView : IEntityView, ICollidable, IBoundsCheckable
    {
        public void SetActive(bool value);
        public event Action OnPickupTaken;
    }
}