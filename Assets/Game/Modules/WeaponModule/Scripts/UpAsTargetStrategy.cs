using Game.Modules.ShootingModule.Scripts;
using UnityEngine;

namespace Game.Modules.WeaponModule
{
    public class UpAsTargetStrategy : ITargetStrategy
    {
        public Vector3 GetShootDirection(Transform shootPoint)
        {
            return Vector3.up;
        }
    }
}