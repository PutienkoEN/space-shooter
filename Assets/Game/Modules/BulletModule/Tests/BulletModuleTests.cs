using System;
using System.Collections.Generic;
using Game.Modules.BulletModule.Scripts;
using Game.Modules.ShootingModule.Scripts;
using NUnit.Framework;
using SpaceShooter.Game.CameraUtility;
using SpaceShooter.Game.Components;
using UnityEngine;
using Zenject;

namespace Game.Modules.BulletModule.Tests
{
    [TestFixture]
    public class BulletModuleTests : ZenjectUnitTestFixture
    {
        private TestBulletFactory _bulletFactory;
        private BulletSpawner _bulletSpawner;
        private BulletController _bulletController;
        private WorldCoordinates _worldCoordinates;
        private Camera _camera;
        private BoundsCheckComponent _boundsCheckComponent;

        [SetUp]
        public void SetupTestData()
        {
            _camera = Camera.main;
            SetupCamera(_camera);
            
            _bulletFactory = new TestBulletFactory();
            _bulletSpawner = new BulletSpawner(_bulletFactory);
            _worldCoordinates = new WorldCoordinates(_camera);
            _bulletController = new BulletController(_bulletSpawner,_worldCoordinates);
            _boundsCheckComponent = new BoundsCheckComponent(_worldCoordinates);
        }

        //Helper method
        private void SetupCamera(Camera camera)
        {
            camera.orthographic = true; // Use orthographic projection
            camera.orthographicSize = 0.5f; // Half the height of the viewport in world units
            camera.aspect = 1f; // Set the aspect ratio to 1 (square)
            camera.transform.position = new Vector3(0, 0, -10f);
        }
        
        //Helper method
        public Rect CreateRect(Collider collider)
        {
            Rect bulletRect = new Rect(
                collider.bounds.min.x,
                collider.bounds.min.y,
                collider.bounds.size.x,
                collider.bounds.size.y);
            
            return bulletRect;
        }
        
        [Test]
        public void WhenLaunchBulletIsCalled_AndBulletControllerIsCreated_ThenBulletAddedToBulletController()
        {
            // Arrange
            GameObject firePoint = new GameObject();
            LayerMask layerMask = (LayerMask)firePoint.layer;
        
            // Act
            _bulletSpawner.LaunchBullet(firePoint.transform, 10f, layerMask);
            
            // Assert
            Assert.AreEqual(1, _bulletController.Bullets.Count);
        }

        [Test]
        public void WhenBulletIsOutOfBounds_AddItWasLaunched_RemoveBulletFromList()
        {
            // Arrange
            GameObject firePoint = new GameObject();
            LayerMask layerMask = (LayerMask)firePoint.layer;
            _bulletSpawner.LaunchBullet(firePoint.transform, 10f, layerMask);
            MoveComponent moveComponent = _bulletFactory.Bullets[0].MoveComponent;
        
            // Act
            moveComponent.MoveToDirection(new Vector3(1,2,3), 10);
            Physics.SyncTransforms();
            
            _bulletController.Tick(10f);
            
            // Assert
            Assert.AreEqual(0, _bulletController.Bullets.Count);
        }

        [Test]
        public void WhenRandomBulletsAreDestroyed_AndSeveralBulletsLaunched_ThenBulletControllerShouldCorrectlyRemoveThem()
        {
            //Arrange
            GameObject firePoint = new GameObject();
            LayerMask layerMask = (LayerMask)firePoint.layer;
            _bulletSpawner.LaunchBullet(firePoint.transform, 10f, layerMask);
            _bulletSpawner.LaunchBullet(firePoint.transform, 10f, layerMask);
            _bulletSpawner.LaunchBullet(firePoint.transform, 10f, layerMask);
            
            MoveComponent bullet1MoveComponent = _bulletFactory.Bullets[0].MoveComponent;
            MoveComponent bullet3MoveComponent = _bulletFactory.Bullets[2].MoveComponent;
            
            //Act
            
            bullet1MoveComponent.MoveToDirection(new Vector3(1,2,3), 10);
            bullet3MoveComponent.MoveToDirection(new Vector3(1,2,3), 10);
            Physics.SyncTransforms();
            
            _bulletController.Tick(10f);
            
            // Assert
            Assert.AreEqual(1, _bulletController.Bullets.Count);
        }

        [Test]
        public void TestCollision()
        {
            
        }
    }
    
    public class TestBulletFactory : IFactory<float, LayerMask, BulletEntity>
    {
        public Dictionary<int, BulletComponents> Bullets = new();
        
        private int _bulletCount = 0;
        
        public BulletEntity Create(float speed, LayerMask layerMask)
        {
            var bulletObj = new GameObject("BulletView");
            Collider bulletCollider = bulletObj.AddComponent<SphereCollider>();
            BulletView bulletView = bulletObj.AddComponent<BulletView>();
            MoveComponent bulletMoveComponent = new MoveComponent(bulletView.transform, speed);
            WorldCoordinates worldCoordinates = new WorldCoordinates(Camera.main);
            BoundsCheckComponent boundsCheckComponent = new BoundsCheckComponent(worldCoordinates);
            BulletEntity bulletEntity = new BulletEntity(bulletView, bulletMoveComponent, boundsCheckComponent);
            
            BulletComponents components = new BulletComponents(
                bulletEntity,
                bulletMoveComponent, 
                bulletView,
                bulletCollider,
                boundsCheckComponent);
            
            Bullets[_bulletCount] = components;
            _bulletCount++;

            return bulletEntity;
        }
    }

    public struct BulletComponents
    {
        public BulletEntity BulletEntity;
        public MoveComponent MoveComponent;
        public BulletView BulletView;
        public Collider BulletCollider;
        public BoundsCheckComponent BoundsCheckComponent;
        
        public BulletComponents(
            BulletEntity bulletEntity,
            MoveComponent bulletMoveComponent, 
            BulletView bulletView, 
            Collider bulletCollider, 
            BoundsCheckComponent boundsCheckComponent)
        {
            MoveComponent = bulletMoveComponent;
            BulletView = bulletView;
            BulletCollider = bulletCollider;
            BulletEntity = bulletEntity;
            BoundsCheckComponent = boundsCheckComponent;
        }
    }
}