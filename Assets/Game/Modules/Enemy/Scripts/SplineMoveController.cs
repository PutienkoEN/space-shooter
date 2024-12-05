using UnityEngine.Splines;
using Zenject;

namespace SpaceShooter.Game.Enemy
{
    public class SplineMoveController
    {
        private readonly SplineAnimate _splineAnimate;

        [Inject]
        public SplineMoveController(SplineAnimate splineAnimate, SplineContainer splineContainer, float speed)
        {
            _splineAnimate = splineAnimate;

            _splineAnimate.AnimationMethod = SplineAnimate.Method.Speed;
            _splineAnimate.MaxSpeed = speed;
            _splineAnimate.Container = splineContainer;
        }

        public void StartMove()
        {
            _splineAnimate.Play();
        }
    }
}