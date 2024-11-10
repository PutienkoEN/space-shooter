using UnityEngine;
using Zenject;

namespace BackgroundModule
{
    public class BackgroundView : MonoBehaviour
    {
        private BackgroundScroller _backgroundScroller;
        
        [Inject]
        public void Construct(BackgroundScroller backgroundScroller)
        {
            _backgroundScroller = backgroundScroller;
            if (TryGetComponent<Renderer>(out Renderer rendererComponent))
            {
                Debug.Log("material : " + rendererComponent.material);
                _backgroundScroller.SetMaterial(rendererComponent.material);
            }
            else
            {
                Debug.LogWarning("No renderer component found when building BackgroundView.");
            }
        }

        private void Update()
        {
            _backgroundScroller?.OnUpdate(Time.deltaTime);
        }
    }
}