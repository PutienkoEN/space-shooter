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
using UnityEngine.TestTools;

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
        
        [Test]
        public void Given_GamePaused_When_WaveFinishes_Then_NextWaveDoesNotStart()
        {
            // Arrange
            _waveQueueSystem.OnGameStart();

            // Act
            _waveQueueSystem.OnGamePause();
            _waveMock1.Raise(w => w.OnWaveFinished += null);

            // Assert
            _waveMock1.Verify(w => w.StartWave(), Times.Once, "First wave should start when the game starts.");
            _waveMock2.Verify(w => w.StartWave(), Times.Never, "Next wave should not start while the game is paused.");
        }
        
        [Test]
        public void Given_GamePausedAndResumed_When_WaveFinishes_Then_NextWaveStarts()
        {
            // Arrange
            _waveQueueSystem.OnGameStart();

            // Act
            _waveQueueSystem.OnGamePause();
            _waveMock1.Raise(w => w.OnWaveFinished += null);
            _waveQueueSystem.OnGameResume();
    
            // Assert
            _waveMock1.Verify(w => w.StartWave(), Times.Once, "First wave should start when the game starts.");
            _waveMock2.Verify(w => w.StartWave(), Times.Once, "Next wave should start after resuming the game.");
        }
        
        [Test]
        public void Given_GamePaused_When_AllWavesFinish_Then_QueueDoesNotTriggerCompletionEvent()
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
            _waveQueueSystem.OnGamePause();
            _waveMock2.Raise(w => w.OnWaveFinished += null);
    
            // Assert
            _waveMock1.Verify(w => w.StartWave(), Times.Once, "First wave should start when the game starts.");
            _waveMock2.Verify(w => w.StartWave(), Times.Once, "Second wave should start after the first wave finishes.");
            Assert.IsFalse(isQueueFinished, "Wave queue should not finish while the game is paused.");
        }
        
        [Test]
        public void Given_GamePausedAndResumed_When_AllWavesFinish_Then_QueueTriggersCompletionEvent()
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
            _waveQueueSystem.OnGamePause();
            _waveMock2.Raise(w => w.OnWaveFinished += null);
            _waveQueueSystem.OnGameResume();
    
            // Assert
            _waveMock1.Verify(w => w.StartWave(), Times.Once, "First wave should start when the game starts.");
            _waveMock2.Verify(w => w.StartWave(), Times.Once, "Second wave should start after the first wave finishes.");
            Assert.IsTrue(isQueueFinished, "Wave queue should trigger completion event after all waves finish.");
        }
        
        [Test]
        public void Given_GameNotStarted_When_OnGamePauseCalled_Then_IsPlayingShouldRemainFalseAndNoWaveStarted()
        {
            // Act
            _waveQueueSystem.OnGamePause();

            // Assert
            _waveMock1.Verify(w => w.StartWave(), Times.Never, "StartWave should not be called for wave 1 when the game is paused before starting.");
            _waveMock2.Verify(w => w.StartWave(), Times.Never, "StartWave should not be called for wave 2 when the game is paused before starting.");
            Assert.IsFalse(_waveQueueSystem.IsPlaying, "IsPlaying should remain false when game is paused before start.");
        }
        
        [Test]
        public void Given_GameStarted_When_OnGameStartCalledAgain_Then_ItShouldNotRestartCurrentWave()
        {
            // Arrange
            _waveQueueSystem.OnGameStart();

            // Act
            _waveQueueSystem.OnGameStart();

            // Assert
            _waveMock1.Verify(w => w.StartWave(), Times.Once, "Wave should not restart when OnGameStart is called again.");
        }
        
        [Test]
        public void Given_WavesFinish_When_OnWaveQueueFinishedInvoked_Then_ItShouldTriggerOnlyOnce()
        {
            //TODO For ignore Debug.LogError() and Debug.LogException()
            LogAssert.ignoreFailingMessages = true;
            
            // Arrange
            var eventCallCount = 0;
            _waveQueueSystem.OnWaveQueueFinished += () => eventCallCount++;
            _waveQueueSystem.OnGameStart();

            // Act
            _waveMock1.Raise(w => w.OnWaveFinished += null);
            _waveMock2.Raise(w => w.OnWaveFinished += null);
            _waveQueueSystem.OnGamePause();
            _waveQueueSystem.OnGameResume();

            // Assert
            Assert.AreEqual(1, eventCallCount, "OnWaveQueueFinished should trigger only once.");
        }
        
        [Test]
        public void Given_WaveQueueSystemDisposed_When_DisposeCalledAgain_Then_ItShouldNotThrowException()
        {
            //TODO For ignore Debug.LogError() and Debug.LogException()
            LogAssert.ignoreFailingMessages = true;
            
            // Arrange
            _waveQueueSystem.Dispose();

            // Act & Assert
            Assert.DoesNotThrow(() => _waveQueueSystem.Dispose(), "Dispose should be idempotent.");
        }
    }
}