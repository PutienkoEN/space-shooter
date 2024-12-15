using System;
using Zenject;

namespace Game.Modules.Scores
{
    public class ScoreViewController : IInitializable, IDisposable
    {
        private readonly ScoreManager _scoreManager;
        private readonly IScoreView _scoreView;

        public ScoreViewController(ScoreManager scoreManager, IScoreView scoreView)
        {
            _scoreManager = scoreManager;
            _scoreView = scoreView;
        }

        public void Initialize()
        {
            _scoreManager.OnScoreUpdate += UpdateScoreView;
            _scoreManager.AddScore(0);
        }

        public void Dispose()
        {
            _scoreManager.OnScoreUpdate -= UpdateScoreView;
        }

        private void UpdateScoreView(long score)
        {
            _scoreView.SetScoreText(score.ToString());
        }
    }
}