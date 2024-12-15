using System;

namespace Game.Modules.Scores
{
    public class ScoreManager
    {
        public event Action<long> OnScoreUpdate;
        
        private long currentScore;

        public void AddScore(int score)
        {
            currentScore += score;
            OnScoreUpdate?.Invoke(currentScore);
        }
    }
}