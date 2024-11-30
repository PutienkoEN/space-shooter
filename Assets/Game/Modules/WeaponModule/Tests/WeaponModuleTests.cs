using System;
using System.Reflection;
using Game.Modules.BulletModule.Scripts;
using Game.Modules.ShootingModule.Scripts;
using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using Moq;
using NUnit.Framework;
using UnityEngine;
using Zenject;

namespace Game.Modules.WeaponModule.Tests
{
    [TestFixture]
    public class WeaponModuleTests : ZenjectUnitTestFixture
    {
        private Mock<IWeaponCreator> _mockWeaponCreator;
        private Mock<IWeaponComponent> _mockWeapon;
        private WeaponConfig _testWeaponConfig;
        private ProjectileConfig _testProjectileConfig;
        private GameObject _testPlayer;
        private BulletEntity.Factory _bulletFactory;
        private BulletSpawner _bulletSpawner;
        
        [SetUp]
        public override void Setup()
        {
            _mockWeapon = new Mock<IWeaponComponent>();
            _mockWeaponCreator = new Mock<IWeaponCreator>();
        
            _testProjectileConfig = ScriptableObject.CreateInstance<ProjectileConfig>();
            _testWeaponConfig = ScriptableObject.CreateInstance<WeaponConfig>();
            
            _testWeaponConfig.GetType()
                .GetField("projectileConfig", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(_testWeaponConfig, _testProjectileConfig);
            
            _testPlayer = new GameObject("Player");
            
            _mockWeaponCreator
                .Setup(creator => creator.CreateWeapon(_testWeaponConfig, _testPlayer.transform))
                .Returns(_mockWeapon.Object);
            
            Container.BindFactory<WeaponComponent, WeaponComponent.Factory>().AsSingle();
            Container.Bind<WeaponComponent>().AsSingle();
            Container.Bind<WeaponCreator>().AsSingle();
            
            Container.BindFactory<float, BulletEntity, BulletEntity.Factory>().AsSingle();
            Container.Bind<BulletSpawner>().AsSingle();
        }

        [Test]
        public void WhenCreateWeaponController_AndWeaponConfigPassed_SetActiveWeapon()
        {
            //Arrange
            
        
            //Act
            WeaponController weaponController = new WeaponController(
                _testWeaponConfig,_mockWeaponCreator.Object, _testPlayer.transform);
        
            //Assert
            Assert.IsNotNull(_mockWeapon.Object);
        }

        [Test]
        public void WhenCreateWeaponController_AndAssignIGameTickable_TickMethodShouldGetDeltaTime()
        {
            //Arrange
            var weaponController = new WeaponController(
                _testWeaponConfig, _mockWeaponCreator.Object, _testPlayer.transform);
            float testDeltaTime = 0.5f;
            
            //Act
            weaponController.Tick(testDeltaTime);
            
            //Assert
            _mockWeapon.Verify(weapon => weapon.Fire(It.Is<float>(deltaTime => deltaTime > 0)), 
                Times.Once);
            
        }
        
        [Test]
        public void WhenWeaponComponentSetupCalled_AndWeaponConfigIsNull_ThenShouldThrowException()
        {
            //Arrange
            _bulletSpawner = Container.Resolve<BulletSpawner>();
            var weaponComponent = new WeaponComponent(_bulletSpawner);
            WeaponConfig weaponDataConfig = null;
            Transform[] firePoints = new Transform[1];
        
            //Act //Assert
            Assert.Throws<ArgumentNullException>(() =>
                weaponComponent.Setup(weaponDataConfig, firePoints));
        }
        
        [Test]
        public void WhenWeaponComponentSetupCalled_AndFirePointIsZero_ThenShouldThrowException()
        {
            //Arrange
            _bulletSpawner = Container.Resolve<BulletSpawner>();
            var weaponComponent = new WeaponComponent(_bulletSpawner);
            WeaponConfig weaponDataConfig = ScriptableObject.CreateInstance<WeaponConfig>();
            Transform[] firePoints = new Transform[0];
        
            //Act & Assert
            Assert.Throws<ArgumentException>(() =>
                weaponComponent.Setup(weaponDataConfig, firePoints));
        }

        [Test]
        public void WhenCreateWeapon_AndWeaponConfigIsNull_ThenShouldThrowException()
        {
            //Arrange
            WeaponCreator weaponCreator = Container.Resolve<WeaponCreator>();
            WeaponConfig weaponDataConfig = null;
            
            //Act & & Assert
            Assert.Throws<ArgumentNullException>(()=> weaponCreator.CreateWeapon(
                weaponDataConfig, _testPlayer.transform));
        }
    }
}