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
    public class BulletModuleTests
    {
        private TestBulletFactory _bulletFactory;
        private BulletSpawner _bulletSpawner;
        private BulletController _bulletController;
        private WorldCoordinates _worldCoordinates;
        private Camera _camera;

        [SetUp]
        public void SetupTestData()
        {
            _camera = Camera.main;
            SetupCamera(_camera);
            
            _bulletFactory = new TestBulletFactory();
            _bulletSpawner = new BulletSpawner(_bulletFactory);
            _worldCoordinates = new WorldCoordinates(_camera);
            _bulletController = new BulletController(_bulletSpawner);
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
            int layerMask = firePoint.layer;
        
            // Act
            _bulletSpawner.LaunchBullet(firePoint.transform, 10f, 10);
            
            // Assert
            Assert.AreEqual(1, _bulletController.Bullets.Count);
        }

        [Test]
        public void WhenBulletIsOutOfBounds_AddItWasLaunched_RemoveBulletFromList()
        {
            // Arrange
            GameObject firePoint = new GameObject();
            int layerMask = firePoint.layer;
            _bulletSpawner.LaunchBullet(firePoint.transform, 10f, 10);
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
            int layerMask = firePoint.layer;
            _bulletSpawner.LaunchBullet(firePoint.transform, 10f, 10);
            _bulletSpawner.LaunchBullet(firePoint.transform, 10f,  10);
            _bulletSpawner.LaunchBullet(firePoint.transform, 10f,  10);
            
            MoveComponent bullet1MoveComponent = _bulletFactory.Bullets[0].MoveComponent;
            MoveComponent bullet3MoveComponent = _bulletFactory.Bullets[2].MoveComponent;
            
            //Act
            bullet1MoveComponent.MoveToDirection(new Vector3(1,1,0), 1);
            bullet3MoveComponent.MoveToDirection(new Vector3(1,1,0), 1);
            Physics.SyncTransforms();
            
            _bulletController.Tick(1f);
            
            // Assert
            Assert.AreEqual(1, _bulletController.Bullets.Count);
        }
    }
    
    public class TestBulletFactory : IFactory<float, BulletEntity>
    {
        public readonly Dictionary<int, BulletComponents> Bullets = new();
        
        private int _bulletCount = 0;
        
        public BulletEntity Create(float speed)
        {
            var bulletObj = new GameObject("BulletView");
            Collider bulletCollider = bulletObj.AddComponent<SphereCollider>();
            BulletView bulletView = bulletObj.AddComponent<BulletView>();
            MoveComponent bulletMoveComponent = new MoveComponent(bulletView.transform, speed);
            WorldCoordinates worldCoordinates = new WorldCoordinates(Camera.main);
            IRectProvider rectProvider = new ColliderRectProvider();
            BoundsCheckComponent boundsCheckComponent = new BoundsCheckComponent(worldCoordinates, rectProvider);
            DealDamageComponent dealDamageComponent = new DealDamageComponent();
            BulletEntity bulletEntity = new BulletEntity(
                bulletView, 
                bulletMoveComponent, 
                boundsCheckComponent,
                dealDamageComponent);
            
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