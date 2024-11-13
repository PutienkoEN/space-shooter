using System;
using SpaceShooter.Background.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Background
{
    public sealed class BackgroundInstantiator : MonoBehaviour
    {
        [SerializeField] private ConfigBackgrounds configBackgrounds;
        [SerializeField] private Transform parent;
        
        private BackgroundController _backgroundController;

        [Inject]
        private void Construct(BackgroundController backgroundController)
        {
            _backgroundController = backgroundController;
        }
        private void Awake()
        {
            InstantiateBackgrounds();
        }

        private void InstantiateBackgrounds()
        {
            if (configBackgrounds == null)
            {
                Debug.LogError("No background configs found");
                return;
            }
            foreach (var backgroundConfig in configBackgrounds.configs)
            {
                BackgroundView backgroundView = Instantiate(backgroundConfig.prefab, parent).GetComponent<BackgroundView>();
                backgroundView.transform.position = new Vector3(0, 0, backgroundConfig.zDistance);
                BackgroundPresenter presenter = new BackgroundPresenter(
                    backgroundView,
                    backgroundConfig.speed);
                _backgroundController.AddToList(presenter);
            }
        }
    }
}