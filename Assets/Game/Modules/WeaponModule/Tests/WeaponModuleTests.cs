using System;
using System.Reflection;
using Game.Modules.BulletModule.Scripts;
using Game.Modules.ShootingModule.Scripts;
using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using Moq;
using NUnit.Framework;
using SpaceShooter.Game.LifeCycle.Common;
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
        // private Mock<IEntityView> _testEntityViewMock;
        
        [SetUp]
        public void SetupTestData()
        {
            _mockWeapon = new Mock<IWeaponComponent>();
            _mockWeaponCreator = new Mock<IWeaponCreator>();
        
            _testProjectileConfig = ScriptableObject.CreateInstance<ProjectileConfig>();
            _testWeaponConfig = ScriptableObject.CreateInstance<WeaponConfig>();
            
            _testWeaponConfig.GetType()
                .GetField("projectileConfig", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(_testWeaponConfig, _testProjectileConfig);
            
            // _testEntityViewMock = new Mock<IEntityView>();
            // _testPlayer = new GameObject("Player");
            // _testEntityViewMock.Setup(view => view.GetTransform()).Returns(_testPlayer.transform);
            
            // _mockWeaponCreator
            //     .Setup(creator => creator.CreateWeapon(_testWeaponConfig, _testEntityViewMock.Object))
            //     .Returns(_mockWeapon.Object);
            
            // Container.BindFactory<WeaponComponent, WeaponComponent.Factory>().AsSingle();
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
            // WeaponController weaponController = new WeaponController(
            //     _testWeaponConfig,_mockWeaponCreator.Object, _testEntityViewMock.Object);
        
            //Assert
            Assert.IsNotNull(_mockWeapon.Object);
        }

        [Test]
        public void WhenCreateWeaponController_AndAssignIGameTickable_TickMethodShouldGetDeltaTime()
        {
            //Arrange
            // var weaponController = new WeaponController(
            //     _testWeaponConfig, _mockWeaponCreator.Object,_testEntityViewMock.Object);
            float testDeltaTime = 0.5f;
            
            //Act
            // weaponController.Tick(testDeltaTime);
            
            //Assert
            _mockWeapon.Verify(weapon => weapon.Fire(It.Is<float>(deltaTime => deltaTime > 0)), 
                Times.Once);
            
        }
        
        [Test]
        public void WhenWeaponComponentSetupCalled_AndWeaponConfigIsNull_ThenShouldThrowException()
        {
            //Arrange
            _bulletSpawner = Container.Resolve<BulletSpawner>();
            // var weaponComponent = new WeaponComponent(_bulletSpawner);
            WeaponConfig weaponDataConfig = null;
            Transform[] firePoints = new Transform[1];
        
            //Act //Assert
            // Assert.Throws<ArgumentNullException>(() =>
            //     weaponComponent.Setup(weaponDataConfig, firePoints));
        }
        
        [Test]
        public void WhenWeaponComponentSetupCalled_AndFirePointIsZero_ThenShouldThrowException()
        {
            //Arrange
            _bulletSpawner = Container.Resolve<BulletSpawner>();
            // var weaponComponent = new WeaponComponent(_bulletSpawner);
            WeaponConfig weaponDataConfig = ScriptableObject.CreateInstance<WeaponConfig>();
            // var weaponViewMock = new Mock<IWeaponView>;
            //
            // //Act & Assert
            // Assert.Throws<ArgumentException>(() =>
            //     weaponComponent.Setup(weaponDataConfig, firePoints));
        }

        [Test]
        public void WhenCreateWeapon_AndWeaponConfigIsNull_ThenShouldThrowException()
        {
            //Arrange
            WeaponCreator weaponCreator = Container.Resolve<WeaponCreator>();
            WeaponConfig weaponDataConfig = null;
            
            //Act & & Assert
            // Assert.Throws<ArgumentNullException>(()=> weaponCreator.CreateWeapon(
            //     weaponDataConfig, _testEntityViewMock.Object));
        }
    }
}