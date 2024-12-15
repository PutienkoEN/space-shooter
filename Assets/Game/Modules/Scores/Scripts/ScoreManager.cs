using System;

namespace Game.Modules.Scores
{
    public class ScoreManager
    {
        public event Action<long> OnScoreUpdate;

        private long _currentScore;

        public void AddScore(long score)
        {
            _currentScore += score;
            OnScoreUpdate?.Invoke(_currentScore);
        }
    }
}