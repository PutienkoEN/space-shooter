using UnityEngine;

namespace BackgroundModule
{
    public class BackgroundScroller
    {
        private float _scrollSpeed;
        private Material _material;
        private const string MAP_KEY = "_BaseMap";
        private float _offset;

        private void CalculateScrollSpeed(float deltaTime)
        {
            _offset += (deltaTime * _scrollSpeed *-1) / 10f;
        }

        public void SetScrollSpeed(float value)
        {
            _scrollSpeed = value;
        }

        public void SetMaterial(Material material)
        {
            _material = material;
        }

        public void OnUpdate(float deltaTime)
        {
            CalculateScrollSpeed(deltaTime);
            _material.SetTextureOffset(MAP_KEY, new Vector2(0, _offset));
        }
    }
}