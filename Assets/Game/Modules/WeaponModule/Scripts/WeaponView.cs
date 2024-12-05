using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public class WeaponView : MonoBehaviour, IWeaponView
    {
        public Transform[] firePoints;

        public Transform[] GetFirePoints()
        {
            return firePoints;
        }
    }

    public interface IWeaponView
    {
        public Transform[] GetFirePoints();
    }
}