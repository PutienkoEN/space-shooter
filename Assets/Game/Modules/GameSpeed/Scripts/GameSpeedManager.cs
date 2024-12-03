using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Game.Modules.GameSpeed;
using Zenject;

namespace SpaceShooter.Game.GameSpeed
{
    public class GameSpeedManager : IGameSpeedManager
    {
        public event Action OnNormalSpeed;
        public event Action OnSlowDown;
        private const float ZeroSpeed = 0f;

        private readonly float _gameSpeedScaleBase;
        private readonly float _gameSpeedScaleSlowdown;

        private readonly float _timeForFullSlowDown;
        private readonly float _timeForFullSpeedup;

        private readonly IGameAudioSpeedManager _gameAudioSpeedManager;
        private readonly IGameTimeScaleManager _gameTimeScaleManager;

        private Sequence _gameSpeedSequence;

        [Inject]
        public GameSpeedManager(
            float gameSpeedScaleBase,
            float gameSpeedScaleSlowdown,
            float timeForFullSlowDown,
            float timeForFullSpeedup,
            IGameAudioSpeedManager gameAudioSpeedManager,
            IGameTimeScaleManager gameTimeScaleManager)
        {
            _gameSpeedScaleBase = gameSpeedScaleBase;
            _gameSpeedScaleSlowdown = gameSpeedScaleSlowdown;
            _timeForFullSlowDown = timeForFullSlowDown;
            _timeForFullSpeedup = timeForFullSpeedup;
            _gameAudioSpeedManager = gameAudioSpeedManager;
            _gameTimeScaleManager = gameTimeScaleManager;
        }

        public void StopTime()
        {
            _gameSpeedSequence?.Kill();
            _gameTimeScaleManager.ChangeTimeScale(ZeroSpeed);
        }

        public void ResumeTime()
        {
            _gameSpeedSequence?.Kill();
            _gameTimeScaleManager.ChangeTimeScale(_gameSpeedScaleBase);
        }

        public void StartSlowdown()
        {
            CreateGameSpeedSequence(_gameSpeedScaleSlowdown, _timeForFullSlowDown);
            OnSlowDown?.Invoke();
        }

        public void StopSlowdown()
        {
            CreateGameSpeedSequence(_gameSpeedScaleBase, _timeForFullSpeedup);
            OnNormalSpeed?.Invoke();
        }

        private void CreateGameSpeedSequence(float scale, float duration)
        {
            _gameSpeedSequence?.Kill();

            var changeTimeScale = _gameTimeScaleManager.ChangeTimeScale(scale, duration);
            var changePitch = _gameAudioSpeedManager.ChangePitch(scale, duration);

            _gameSpeedSequence = DOTween
                .Sequence()
                .Join(changeTimeScale)
                .Join(changePitch)
                .SetEase(Ease.InOutQuad)
                .OnComplete(() => _gameSpeedSequence = null);
        }
    }
}