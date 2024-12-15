using System;
using Game.Modules.Common.Interfaces;

namespace Game.PickupModule.Scripts
{
    public interface IPickupView : IEntityView, ICollidable
    {
        public event Action<PickupItem> OnPickupTaken;
    }
}