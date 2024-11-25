using System;
using System.Linq;
using Game.Modules.BulletModule.Scripts;
using Game.Modules.ShootingModule.Scripts;
using Moq;
using NUnit.Framework;
using SpaceShooter.Game.Components;
using UnityEngine;
using Zenject;

namespace Game.Modules.BulletModule.Tests
{
    [TestFixture]
    public class BulletModuleTests : ZenjectUnitTestFixture
    {
        [SetUp]
        public void Setup()
        {
            GameObject testBullet = new GameObject();
            BulletView view = testBullet.AddComponent<BulletView>();
            Transform bulletTransform = testBullet.transform;
            float speed = 10f;
            
            Container.Bind<BulletView>().FromInstance(view).AsSingle();
            Container.Bind<BulletController>().AsCached();
            Container.BindFactory<float, BulletEntity, BulletEntity.Factory>().AsSingle();
            Container.Bind<BulletSpawner>().AsSingle();
            Container.Bind<MoveComponent>().AsSingle().WithArguments(bulletTransform, speed);
            Container.Bind<BulletEntity>().AsSingle();
        }
        
        [Test]
        public void WhenLaunchBulletIsCalled_AndTransformArgumentIsNull_ThenThrowException()
        {
            // Arrange
            BulletSpawner bulletSpawner = Container.Resolve<BulletSpawner>();
        
            // Act && Assert
            Assert.Throws<ArgumentNullException>(()=> bulletSpawner.LaunchBullet(null, 10));
        }
        
    }
}