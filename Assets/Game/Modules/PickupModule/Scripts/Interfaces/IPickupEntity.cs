using System;
using Game.Modules.Common.Interfaces;

namespace Game.PickupModule.Scripts
{
    public interface IPickupEntity : IComplexEntity
    {
        public event Action<IPickupEntity> OnDestroy;
    }
}