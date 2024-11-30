using Game.Modules.BulletModule.Scripts;
using Moq;
using NUnit.Framework;

namespace Game.Modules.CollisionModule.Scripts.Tests
{
    
    [TestFixture]
    public class CollisionModuleTests
    {
        CollisionProcessor _collisionProcessor;
        
        [SetUp]
        public void Setup()
        {
            _collisionProcessor = new CollisionProcessor();
        }

        [Test]
        public void WhenNewEventAdded_AndEventHasAKey_ThenCollisionProcessorDictionaryShouldContainIt()
        {
            // Arrange
            var mockEvent = new Mock<ICollisionEvent>();
            var mockKey = 123;
            mockEvent.Setup(e => e.GetEventKey()).Returns(mockKey);

            // Act
            _collisionProcessor.AddCollisionEvent(mockEvent.Object);

            // Assert
            Assert.IsTrue(_collisionProcessor.NewEvents.ContainsKey(mockKey));
        }
        
        [Test]
        public void WhenAddingNewEvent_AndKeysIsDuplicate_ShouldNotAddEvent()
        {
            // Arrange
            var mockEvent1 = new Mock<ICollisionEvent>();
            var mockEvent2 = new Mock<ICollisionEvent>();
            var mockKey = 123;
            mockEvent1.Setup(e => e.GetEventKey()).Returns(mockKey);
            mockEvent2.Setup(e => e.GetEventKey()).Returns(mockKey);

            _collisionProcessor.AddCollisionEvent(mockEvent1.Object);

            // Act
            _collisionProcessor.AddCollisionEvent(mockEvent2.Object);

            // Assert
            Assert.AreEqual(1, _collisionProcessor.NewEvents.Count);
        }
        
        [Test]
        public void WhenEventProcessed_AndEventIsInNewEventsList_ThenEventShouldBeRemovedFromNewEventsList()
        {
            // Arrange
            var mockEvent = new Mock<ICollisionEvent>();
            var mockKey = 123;

            mockEvent.Setup(e => e.GetEventKey()).Returns(mockKey);
            var collisionProcessor = new CollisionProcessor();
            collisionProcessor.AddCollisionEvent(mockEvent.Object);

            // Act
            collisionProcessor.Tick(0.1f);

            // Assert
            Assert.IsFalse(collisionProcessor.NewEvents.ContainsKey(mockKey));
        }
    }
}