using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.LifeCycle.Common
{
    public abstract class GameModuleInstaller : MonoBehaviour, IGameModuleInstaller
    {
        public abstract void Install(DiContainer container);
    }
}