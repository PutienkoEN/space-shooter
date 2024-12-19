using System;
using System.Collections.Generic;
using Game.Modules.LevelInterfaces.Scripts;
using NUnit.Framework;
using SpaceShooter.Game.Level;
using SpaceShooter.Game.Level.Events;

namespace Game.Modules.Level.Tests
{
    [TestFixture]
    public class LevelManagerTest
    {
        [TestCase(2, 0, 1)]
        [TestCase(3, 1, 2)]
        public void WhenNextLevelCalled_AndThereIsNextLevel_ShouldUpdateCurrentLevel_AndReturnTrue(
            int numberOfLevels,
            int initialCurrentLevel,
            int resultCurrentLevel)
        {
            // Arrange
            var levelManager = ConfigureLevelManagerWithLevels(numberOfLevels);
            // And
            var levelData = new LevelData
            {
                currentLevel = initialCurrentLevel
            };
            levelManager.SetLevelData(levelData);

            // Act
            var result = levelManager.NextLevel();

            // Assert
            Assert.AreEqual(resultCurrentLevel, levelData.currentLevel);
            Assert.IsTrue(result);
        }

        [TestCase(1, 0, 0)]
        [TestCase(2, 1, 1)]
        public void WhenNextLevelCalled_AndThereIsNoNextLevel_ShouldNotUpdateNextLevel_AndReturnFalse(
            int numberOfLevels,
            int initialCurrentLevel,
            int resultCurrentLevel)
        {
            // Arrange
            var levelManager = ConfigureLevelManagerWithLevels(numberOfLevels);
            // And
            var levelData = new LevelData
            {
                currentLevel = initialCurrentLevel
            };
            levelManager.SetLevelData(levelData);

            // Act
            var result = levelManager.NextLevel();

            // Assert
            Assert.AreEqual(resultCurrentLevel, levelData.currentLevel);
            Assert.IsFalse(result);
        }

        [TestCase(2, 0, 0)]
        [TestCase(3, 1, 1)]
        public void WhenHasNextLevelCalled_AndThereIsNextLevel_ShouldNotUpdateCurrentLevel_AndReturnTrue(
            int numberOfLevels,
            int initialCurrentLevel,
            int resultCurrentLevel)
        {
            // Arrange
            var levelManager = ConfigureLevelManagerWithLevels(numberOfLevels);
            // And
            var levelData = new LevelData
            {
                currentLevel = initialCurrentLevel
            };
            levelManager.SetLevelData(levelData);

            // Act
            var result = levelManager.HasNextLevel();

            // Assert
            Assert.AreEqual(resultCurrentLevel, levelData.currentLevel);
            Assert.IsTrue(result);
        }

        [TestCase(1, 0, 0)]
        [TestCase(2, 1, 1)]
        public void WhenHasNextLevelCalled_AndThereIsNoNextLevel_CurrentLevelShouldNotChange_AndShouldReturnFalse(
            int numberOfLevels,
            int initialCurrentLevel,
            int resultCurrentLevel)
        {
            // Arrange
            var levelManager = ConfigureLevelManagerWithLevels(numberOfLevels);
            // And
            var levelData = new LevelData
            {
                currentLevel = initialCurrentLevel
            };
            levelManager.SetLevelData(levelData);

            // Act
            var result = levelManager.HasNextLevel();

            // Assert
            Assert.AreEqual(resultCurrentLevel, levelData.currentLevel);
            Assert.IsFalse(result);
        }

        [TestCase(2, 0, 1)]
        [TestCase(3, 1, 2)]
        public void WhenFinishCurrentLevelCalled_AndThereIsNextLevel_MaxLevelShouldBeSetToCurrentLevel(
            int numberOfLevels,
            int initialCurrentLevel,
            int resultMaxLevel)
        {
            // Arrange
            var levelManager = ConfigureLevelManagerWithLevels(numberOfLevels);
            // And
            var levelData = new LevelData
            {
                currentLevel = initialCurrentLevel
            };
            levelManager.SetLevelData(levelData);

            // Act
            levelManager.FinishCurrentLevel();

            // Assert
            Assert.AreEqual(resultMaxLevel, levelData.maxReachedLevel);
        }

        [TestCase(1, 0, 0)]
        [TestCase(2, 1, 1)]
        public void WhenFinishCurrentLevelCalled_AndThereIsNoNextLevel_MaxLevelShouldBeSetToCurrentLevel(
            int numberOfLevels,
            int initialCurrentLevel,
            int resultMaxLevel)
        {
            // Arrange
            var levelManager = ConfigureLevelManagerWithLevels(numberOfLevels);
            // And
            var levelData = new LevelData
            {
                currentLevel = initialCurrentLevel
            };
            levelManager.SetLevelData(levelData);

            // Act
            levelManager.FinishCurrentLevel();

            // Assert
            Assert.AreEqual(resultMaxLevel, levelData.maxReachedLevel);
        }

        [TestCase(3, 0, 2)]
        [TestCase(3, 1, 2)]
        public void WhenLoadMaxLevelCalled_AndThereIsEnoughLevels_CurrentLevel_ShouldBeOverridenByMaxLevelValue(
            int numberOfLevels,
            int initialCurrentLevel,
            int maxLevelReached)
        {
            // Arrange
            var levelManager = ConfigureLevelManagerWithLevels(numberOfLevels);
            // And
            var levelData = new LevelData
            {
                currentLevel = initialCurrentLevel,
                maxReachedLevel = maxLevelReached
            };
            levelManager.SetLevelData(levelData);

            // Act
            levelManager.LoadMaxLevel();

            // Assert
            Assert.AreEqual(levelData.currentLevel, levelData.maxReachedLevel);
        }

        [TestCase(3, 0, 4)]
        [TestCase(3, 4, 4)]
        public void
            WhenLoadMaxLevelCalled_AndThereIsNotEnoughLevels_CurrentLevel_ShouldBeOverridenByMaxLevelAvailable(
                int numberOfLevels,
                int initialCurrentLevel,
                int maxLevelReached)
        {
            // Arrange
            var levelManager = ConfigureLevelManagerWithLevels(numberOfLevels);
            // And
            var levelData = new LevelData
            {
                currentLevel = initialCurrentLevel,
                maxReachedLevel = maxLevelReached
            };
            levelManager.SetLevelData(levelData);

            // Act
            levelManager.LoadMaxLevel();

            // Assert
            Assert.AreEqual(levelData.currentLevel, numberOfLevels);
        }

        [Test]
        public void WhenLoadFirstLevelCalled_AndThereIsNoLevels_ShouldThrowException()
        {
            // Arrange
            var levelManager = ConfigureLevelManagerWithLevels(0);
            // And
            var levelData = new LevelData();
            levelManager.SetLevelData(levelData);

            // Act
            var argumentException = Assert.Throws<ArgumentException>(() => levelManager.LoadFirstLevel());
            
            // Assert
            Assert.AreEqual("There is no available levels!",argumentException.Message);
        }
        
        [Test]
        public void WhenLoadFirstLevelCalled_AndThereIsLevels_ShouldSetCurrentLevelToZero()
        {
            // Arrange
            var levelManager = ConfigureLevelManagerWithLevels(1);
            // And
            var levelData = new LevelData();
            levelManager.SetLevelData(levelData);

            // Act
            levelManager.LoadFirstLevel();

            // Assert
            Assert.AreEqual(0, levelData.currentLevel);
        }
        
        private static LevelManager ConfigureLevelManagerWithLevels(int numberOfLevels)
        {
            List<ILevelConfigData> levelConfigDataList = new();
            for (var i = 0; i < numberOfLevels; i++)
            {
                levelConfigDataList.Add(new LevelConfigData(new List<ILevelEventData>()));
            }

            var levelConfigList = new LevelConfigListData(levelConfigDataList);
            return new LevelManager(levelConfigList);
        }
    }
}