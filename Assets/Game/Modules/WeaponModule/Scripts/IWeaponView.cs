using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public interface IWeaponView
    {
        public void SubscribeToOnDestroy(IWeaponDestructible destructible);
        public void PlayShootSound();
        public Transform[] GetFirePoints();
    }
}