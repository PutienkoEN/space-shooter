using UnityEngine;
using Zenject;

namespace Game.Modules.BulletModule.Scripts
{
    public class BulletFacade : MonoBehaviour
    {

        public class Factory : PlaceholderFactory<BulletFacade>
        {
        }
    }
}