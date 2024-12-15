namespace Game.Modules.Scores
{
    public class ScoreComponent
    {
        private readonly ScoreManager _scoreManager;
        private readonly long _scoreAward;

        public ScoreComponent(ScoreManager scoreManager, long scoreAward)
        {
            _scoreManager = scoreManager;
            _scoreAward = scoreAward;
        }

        public void GiveScore()
        {
            _scoreManager.AddScore(_scoreAward);
        }
    }
}