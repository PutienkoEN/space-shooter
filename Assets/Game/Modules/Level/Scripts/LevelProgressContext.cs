namespace Game.Modules.Game
{
    public class LevelProgressContext
    {
        private bool _playerIsDead;
        private bool _enemiesExist;
        private bool _levelEventsExists;
        private LevelProgressState _levelProgressState;

        public bool PlayerIsDead
        {
            set
            {
                _playerIsDead = value;
                _levelProgressState = GetLevelProgressState();
            }
        }

        public bool EnemiesExist
        {
            set
            {
                _enemiesExist = value;
                _levelProgressState = GetLevelProgressState();
            }
        }

        public bool LevelEventsExists
        {
            set
            {
                _levelEventsExists = value;
                _levelProgressState = GetLevelProgressState();
            }
        }

        public bool IsLevelSuccess()
        {
            return _levelProgressState == LevelProgressState.Success;
        }

        public bool IsLevelFinished()
        {
            return _levelProgressState != LevelProgressState.InProgress;
        }

        private LevelProgressState GetLevelProgressState()
        {
            if (_playerIsDead)
            {
                return LevelProgressState.Failed;
            }

            if (_levelEventsExists)
            {
                return LevelProgressState.InProgress;
            }

            if (_enemiesExist)
            {
                return LevelProgressState.InProgress;
            }

            return LevelProgressState.Success;
        }
    }

    enum LevelProgressState
    {
        InProgress,
        Success,
        Failed
    }
}