using Game.Modules.ShootingModule.Scripts;
using UnityEngine;

namespace Game.Modules.WeaponModule
{
    public class UpTargetStrategy : ITargetStrategy
    {
        public Vector3 GetTarget()
        {
            return Vector3.up;
        }
    }
}