﻿using System;
using System.Reflection;
using Game.Modules.ShootingModule.Scripts;
using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using Moq;
using NUnit.Framework;
using UnityEngine;

namespace Game.Modules.WeaponModule.Tests
{
    public class WeaponModuleTests
    {
        private Mock<IWeaponCreator> _mockWeaponCreator;
        private Mock<IWeaponComponent> _mockWeapon;
        private WeaponConfig _testWeaponConfig;
        private ProjectileConfig _testProjectileConfig;
        private GameObject _testPlayer;
        
        [SetUp]
        public void Setup()
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
                .Setup(creator => creator.CreateWeapon(_testWeaponConfig, _testPlayer))
                .Returns(_mockWeapon.Object);
        }

        [Test]
        public void WhenCreateWeaponController_AndWeaponConfigPassed_SetActiveWeapon()
        {
            //Arrange
            
        
            //Act
            WeaponController weaponController = new WeaponController(_testWeaponConfig,_mockWeaponCreator.Object, _testPlayer);

            //Assert
            Assert.IsNotNull(_mockWeapon.Object);
        }

        [Test]
        public void WhenCreateWeaponController_AndAssignIGameTickable_TickMethodShouldGetDeltaTime()
        {
            //Arrange
            var weaponController = new WeaponController(_testWeaponConfig, _mockWeaponCreator.Object, _testPlayer);
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
            var bulletLauncherMock = new Mock<BulletLauncher>();
            var weaponComponent = new WeaponComponent(bulletLauncherMock.Object);
            WeaponConfig weaponConfig = null;
            Transform[] firePoints = new Transform[1];

            //Act //Assert
            Assert.Throws<ArgumentNullException>(() =>
                weaponComponent.Setup(weaponConfig, firePoints));
        }
        
        [Test]
        public void WhenWeaponComponentSetupCalled_AndFirePointIsZero_ThenShouldThrowException()
        {
            //Arrange
            var bulletLauncherMock = new Mock<BulletLauncher>();
            var weaponComponent = new WeaponComponent(bulletLauncherMock.Object);
            WeaponConfig weaponConfig = ScriptableObject.CreateInstance<WeaponConfig>();
            Transform[] firePoints = new Transform[0];

            //Act & Assert
            Assert.Throws<ArgumentException>(() =>
                weaponComponent.Setup(weaponConfig, firePoints));
        }

        [Test]
        public void WhenCreateWeapon_AndWeaponConfigIsNull_ThenShouldThrowException()
        {
            //Arrange
            WeaponCreator weaponCreator = new WeaponCreator();
            WeaponConfig weaponConfig = null;
            
            //Act & & Assert
            Assert.Throws<ArgumentNullException>(()=> weaponCreator.CreateWeapon(weaponConfig, _testPlayer));
        }
        
        [Test]
        public void WhenCreateWeapon_AndPlayerIsNull_ThenShouldThrowException()
        {
            //Arrange
            WeaponCreator weaponCreator = new WeaponCreator();
            GameObject player = null;
            
            //Act & & Assert
            Assert.Throws<ArgumentNullException>(()=> weaponCreator.CreateWeapon(_testWeaponConfig, player));
        }
    }
}