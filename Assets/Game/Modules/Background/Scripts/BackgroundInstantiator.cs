using SpaceShooter.Background.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Background
{
    public class BackgroundInstantiator : MonoBehaviour
    {
        public ConfigBackgrounds configBackgrounds;
        public Transform parent;
        
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
            foreach (var backgroundConfig in configBackgrounds.configs)
            {
                BackgroundView backgroundView = Instantiate(backgroundConfig.prefab, parent).GetComponent<BackgroundView>();
                backgroundView.transform.position = new Vector3(0, 0, backgroundConfig.zDistance);
                BackgroupPresenter presenter = new BackgroupPresenter(
                    backgroundView,
                    backgroundConfig.speed);
                _backgroundController.AddToList(presenter);
            }
        }
    }
}