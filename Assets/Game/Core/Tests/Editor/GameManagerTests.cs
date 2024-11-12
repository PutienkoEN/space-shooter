// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-12
// <file>: GameManagerTests.cs
// ------------------------------------------------------------------------------

using Moq;
using NUnit.Framework;
using SpaceShooter.Game.Core.Base;
using SpaceShooter.Game.Core.Common;

namespace SpaceShooter.Game.Core.Tests.Editor
{
    public sealed class GameManagerTests
    {
        private GameManager _gameManager;
        private Mock<IGameStartListener> _mockStartListener;
        private Mock<IGamePauseListener> _mockPauseListener;
        private Mock<IGameResumeListener> _mockResumeListener;
        private Mock<IGameFinishListener> _mockFinishListener;

        [SetUp]
        public void Setup()
        {
            _gameManager = new GameManager();
            _mockStartListener = new Mock<IGameStartListener>();
            _mockPauseListener = new Mock<IGamePauseListener>();
            _mockResumeListener = new Mock<IGameResumeListener>();
            _mockFinishListener = new Mock<IGameFinishListener>();
        }

        [Test]
        public void StartGame_ShouldInvokeOnGameStart_OnAllStartListeners()
        {
            // Arrange
            _gameManager.AddListener(_mockStartListener.Object);
            _gameManager.AddListener(_mockPauseListener.Object);

            // Act
            _gameManager.StartGame();

            // Assert
            _mockStartListener.Verify(listener => listener.OnGameStart(), Times.Once);
            _mockPauseListener.Verify(listener => listener.OnGamePause(), Times.Never);
        }

        [Test]
        public void PauseGame_ShouldInvokeOnGamePause_OnAllPauseListeners()
        {
            // Arrange
            _gameManager.AddListener(_mockPauseListener.Object);

            // Act
            _gameManager.StartGame(); // переход в состояние PLAY
            _gameManager.PauseGame();
            _gameManager.PauseGame();

            // Assert
            _mockPauseListener.Verify(listener => listener.OnGamePause(), Times.Once);
        }

        [Test]
        public void ResumeGame_ShouldInvokeOnGameResume_OnAllResumeListeners()
        {
            // Arrange
            _gameManager.AddListener(_mockResumeListener.Object);

            // Act
            _gameManager.StartGame();
            _gameManager.PauseGame();
            _gameManager.ResumeGame();
            _gameManager.ResumeGame();

            // Assert
            _mockResumeListener.Verify(listener => listener.OnGameResume(), Times.Once);
        }

        [Test]
        public void FinishGame_ShouldInvokeOnGameFinish_OnAllFinishListeners()
        {
            // Arrange
            _gameManager.AddListener(_mockFinishListener.Object);

            // Act
            _gameManager.StartGame();
            _gameManager.FinishGame();
            _gameManager.FinishGame();

            // Assert
            _mockFinishListener.Verify(listener => listener.OnGameFinish(), Times.Once);
        }

        [Test]
        public void StartGame_ShouldNotInvokeOnGameStart_WhenAlreadyStarted()
        {
            // Arrange
            _gameManager.AddListener(_mockStartListener.Object);

            // Act
            _gameManager.StartGame(); // Первый вызов StartGame
            _gameManager.StartGame(); // Повторный вызов StartGame

            // Assert
            _mockStartListener.Verify(listener => listener.OnGameStart(), Times.Once);
        }
    }
}