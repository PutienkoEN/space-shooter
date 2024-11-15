using System.Collections.Generic;
using SpaceShooter.Background;
using SpaceShooter.Background.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Game.Modules.Background.Scripts
{
    public class BackgroundsPresenterInstantiator
    {
        public BackgroundsPresenterInstantiator(DiContainer container, BackgroundLayersConfig backgroundLayersConfig)
        {
            BindBackgroundPresenters(container, backgroundLayersConfig);
        }
        
        private void BindBackgroundPresenters(DiContainer container, BackgroundLayersConfig backgroundLayersConfig)
        {
            List<IBackgroundPresenter> presentersList = new();
            foreach (var backgroundConfig in backgroundLayersConfig.configs)
            {
                BackgroundPresenter presenter = container.Instantiate<BackgroundPresenter>(
                    new object[] { backgroundConfig.material, backgroundConfig.speed });
                presentersList.Add(presenter);
            }
            container.Bind<List<IBackgroundPresenter>>().FromInstance(presentersList).AsSingle();
        }
    }
}