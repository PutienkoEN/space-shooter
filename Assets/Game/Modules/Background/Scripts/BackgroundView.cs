using UnityEngine;

namespace SpaceShooter.Background
{
    public sealed class BackgroundView : MonoBehaviour, IBackgroundView
    {
        private Material _backgroundMaterial;
        private const string MAP_KEY = "_BaseMap";

        private void Awake()
        {
           _backgroundMaterial = GetComponent<Renderer>().material;
        }

        public void ScrollBackground(Vector2 offset)
        {
            _backgroundMaterial.SetTextureOffset(MAP_KEY, offset);
        }
        
    }
}