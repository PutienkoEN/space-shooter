using System;
using Game.Modules.Common.Interfaces;
using UnityEngine.Splines;
using Zenject;

namespace SpaceShooter.Game.Enemy
{
    public class SplineMoveController : IDisposable
    {
        private readonly SplineAnimate _splineAnimate;
        private readonly IEnemyEntity _entity;

        [Inject]
        public SplineMoveController(
            SplineAnimate splineAnimate, 
            SplineContainer splineContainer, 
            float speed,
            IEnemyEntity entity)
        {
            _splineAnimate = splineAnimate;
            _entity = entity;
            
            _splineAnimate.AnimationMethod = SplineAnimate.Method.Speed;
            _splineAnimate.MaxSpeed = speed;
            _splineAnimate.Container = splineContainer;
            
            _entity.OnStateChanged += StartMove;
        }

        public void StartMove(bool _)
        {
            _splineAnimate.Play();
        }


        public void Dispose()
        {
            _entity.OnStateChanged -= StartMove;
        }
    }
}