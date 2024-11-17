// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-16
// <file>: WaveQueueSystemTest.cs
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Game.Modules.Wave.Interface;
using Moq;
using NUnit.Framework;

namespace Game.Modules.Wave.Tests.Editor
{
    [TestFixture]
    internal sealed class WaveQueueSystemTest
    {
        private Mock<IWave> _waveMock1;
        private Mock<IWave> _waveMock2;
        private Mock<IListWaveConfig> _waveConfigMock;
        private WaveQueueSystem _waveQueueSystem;
        
        [SetUp]
        public void SetUp()
        {
            _waveConfigMock = new Mock<IListWaveConfig>();
            
            _waveMock1 = new Mock<IWave>();
            _waveMock2 = new Mock<IWave>();
            
            _waveMock1.Setup(w => w.StartWave());
            _waveMock2.Setup(w => w.StartWave());
            
            var waveDataMock1 = new Mock<IWaveData>();
            var waveDataMock2 = new Mock<IWaveData>();
            
            _waveConfigMock.Setup(x => x.GetListWaveConfig())
                .Returns(new List<IWaveData> { waveDataMock1.Object, waveDataMock2.Object });
            
            waveDataMock1.Setup(wd => wd.GetWave()).Returns(_waveMock1.Object);
            waveDataMock2.Setup(wd => wd.GetWave()).Returns(_waveMock2.Object);
            
            _waveQueueSystem = new WaveQueueSystem(_waveConfigMock.Object);
        }
        
        [Test]
        public void Given_ValidWaveConfig_When_WaveQueueSystemIsCreated_Then_QueueShouldContainWaves()
        {
            // Arrange
            var waveDataMock = new Mock<IWaveData>();
            var waveMock = new Mock<IWave>();
            waveDataMock.Setup(x => x.GetWave()).Returns(waveMock.Object);
            
            var validWaveConfig = new Mock<IListWaveConfig>();
            validWaveConfig.Setup(x => x.GetListWaveConfig()).Returns(new List<IWaveData> { waveDataMock.Object });
    
            // Act
            var waveQueueSystem = new WaveQueueSystem(validWaveConfig.Object);
    
            // Assert
            Assert.AreEqual(1, waveQueueSystem.CountWaves, "Wave queue should contain one wave.");
        }
        
        [Test]
        public void Given_EmptyWaveConfig_When_WaveQueueSystemIsCreated_Then_QueueShouldBeEmpty()
        {
            // Arrange
            var emptyWaveConfig = new Mock<IListWaveConfig>();
            emptyWaveConfig.Setup(x => x.GetListWaveConfig()).Returns(new List<IWaveData>());
    
            // Act
            var waveQueueSystem = new WaveQueueSystem(emptyWaveConfig.Object);
    
            // Assert
            Assert.AreEqual(0, waveQueueSystem.CountWaves, "Wave queue should be empty.");
        }
        
        [Test]
        public void Given_NullWaveConfig_When_WaveQueueSystemIsCreated_Then_ArgumentNullExceptionShouldBeThrown()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new WaveQueueSystem(null), "Constructor should throw ArgumentNullException when passed null.");
        }
        
        [Test]
        public void Given_DefaultWaveConfig_When_WaveQueueSystemIsCreated_Then_ArgumentNullExceptionShouldBeThrown()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentNullException>(() => new WaveQueueSystem(default), "Constructor should throw ArgumentNullException when passed default value.");
        }
        
        [Test]
        public void Given_GameStart_When_OnGameStartCalled_Then_TheNextWaveShouldStart()
        {
            // Act & Arrange 
            _waveQueueSystem.OnGameStart();
    
            // Assert
            _waveMock1.Verify(w => w.StartWave(), Times.Once, "Next wave should start when the game starts.");
        }
        
        [Test]
        public void Given_GameIsPlaying_When_OnGamePauseCalled_Then_GameShouldPause()
        {
            // Arrange
            _waveQueueSystem.OnGameStart();

            // Act
            _waveQueueSystem.OnGamePause();

            // Assert
            Assert.IsFalse(_waveQueueSystem.IsPlaying, "Game should be paused when OnGamePause is called.");
        }
        
        [Test]
        public void Given_GameIsPaused_When_OnGameResumeCalled_Then_GameShouldResume()
        {
            // Arrange
            _waveQueueSystem.OnGameStart();
            _waveQueueSystem.OnGamePause();

            // Act
            _waveQueueSystem.OnGameResume();

            // Assert
            Assert.IsTrue(_waveQueueSystem.IsPlaying, "Game should resume when OnGameResume is called.");
        }
        
        [Test]
        public void Given_AllWavesCompleted_When_WavesQueueFinished_Then_OnWaveQueueFinishedEventShouldBeTriggered()
        {
            // Arrange
            var isQueueFinished = false;
            _waveQueueSystem.OnGameStart();
            _waveQueueSystem.OnWaveQueueFinished += () =>
            {
                isQueueFinished = true;
            };
            
            // Act
            _waveMock1.Raise(w => w.OnWaveFinished += null);
            _waveMock2.Raise(w => w.OnWaveFinished += null);
            
            // Assert
            Assert.IsTrue(isQueueFinished, "OnWaveQueueFinished should be triggered after all waves are completed.");
            Assert.IsTrue(_waveQueueSystem.CountWaves == 0, "Queue should be Empty");
        }
        
        [Test]
        public void Given_WavesInQueue_When_DisposeCalled_Then_WavesShouldBeDisposedAndQueueShouldBeCleared()
        {
            // Arrange
            _waveQueueSystem.OnGameStart();

            // Act
            _waveQueueSystem.Dispose();
    
            // Assert
            Assert.IsTrue(_waveQueueSystem.CountWaves == 0, "Queue should be cleared after dispose.");
        }
        
        [Test]
        public void Given_GamePausedAndResumedMultipleTimes_When_GameContinues_Then_CurrentWaveResumesAndNextWaveDoesNotStart()
        {
            // Arrange
            _waveQueueSystem.OnGameStart();
    
            // Act
            _waveQueueSystem.OnGamePause();
            _waveQueueSystem.OnGameResume();
            _waveQueueSystem.OnGamePause();
            _waveQueueSystem.OnGameResume();
    
            // Assert
            _waveMock1.Verify(w => w.StartWave(), Times.Once, "First wave should start when the game starts.");
            _waveMock2.Verify(w => w.StartWave(), Times.Never, "The next wave does not start when pausing and resuming.");
        }
    }
}