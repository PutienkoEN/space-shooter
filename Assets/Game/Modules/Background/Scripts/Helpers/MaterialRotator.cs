using System;
using UnityEngine;

namespace SpaceShooter.Background
{
    [RequireComponent(typeof(BackgroundView))]
    public class MaterialRotator : MonoBehaviour
    {
        public float speed;

        private BackgroundView _view;
        private float _offset;

        private void Awake()
        {
           _view = GetComponent<BackgroundView>();
        }

        private void Update()
        {
            _offset += (Time.deltaTime * speed *1) / 10f;
            _view.ScrollBackground(new Vector2(0, _offset));
        }
    }
}