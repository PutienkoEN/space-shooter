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
                GameObject obj = Instantiate(backgroundConfig.prefab, parent);
                obj.transform.position = new Vector3(0, 0, backgroundConfig.zDistance);
                Material backgroundMaterial = obj.GetComponent<Renderer>().material;
                BackgroundPresenter presenter = new BackgroundPresenter(
                    backgroundMaterial,
                    backgroundConfig.speed);
                _backgroundController.AddToList(presenter);
            }
        }
    }
}