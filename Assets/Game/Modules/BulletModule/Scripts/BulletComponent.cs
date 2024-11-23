using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace Game.Modules.BulletModule.Scripts
{
    public class BulletComponent : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<BulletComponent>
        {
        }
    }
}