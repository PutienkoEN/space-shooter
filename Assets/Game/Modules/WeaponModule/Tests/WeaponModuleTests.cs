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
    // [TestFixture]
    // public class WeaponModuleTests : ZenjectUnitTestFixture
    // {
    //     private Mock<IWeaponCreator> _mockWeaponCreator;
    //     private WeaponConfig _testWeaponConfig;
    //     private ProjectileConfig _testProjectileConfig;
    //     private GameObject _testPlayer;
    //     
    //     [SetUp]
    //     public void SetupTestData()
    //     {
    //         _mockWeaponCreator = new Mock<IWeaponCreator>();
    //         _testProjectileConfig = ScriptableObject.CreateInstance<ProjectileConfig>();
    //         _testWeaponConfig = ScriptableObject.CreateInstance<WeaponConfig>();
    //         var weaponPrefab = new GameObject("WeaponPrefab").AddComponent<WeaponView>();
    //         _testWeaponConfig.GetType()
    //             .GetField("projectileConfig", BindingFlags.NonPublic | BindingFlags.Instance)
    //             ?.SetValue(_testWeaponConfig, _testProjectileConfig);
    //         _testWeaponConfig.GetType()
    //             .GetField("prefab", BindingFlags.NonPublic | BindingFlags.Instance)
    //             ?.SetValue(_testWeaponConfig, weaponPrefab);
    //         
    //         _testPlayer = new GameObject("Player");
    //         
    //         Container.Bind<BulletSpawner>().AsSingle();
    //         Container.BindFactory<float, BulletEntity, BulletEntity.Factory>().AsSingle();
    //         Container.Bind<IFactory<float, BulletEntity>>().To<BulletEntity.Factory>().FromResolve();
    //     }
    //
    //     [Test]
    //     public void WhenWeaponControllerCreated_AndAllArgumentsPassed_CreateWeaponShouldBeCalled()
    //     {
    //         //Arrange
    //     
    //         //Act
    //         WeaponController weaponController = new WeaponController(
    //             _testWeaponConfig,
    //             _mockWeaponCreator.Object, 
    //             _testPlayer.transform, 
    //             (LayerMask)_testPlayer.gameObject.layer);
    //     
    //         //Assert
    //         _mockWeaponCreator.Verify(
    //             creator => creator.CreateWeapon(_testWeaponConfig, _testPlayer.transform, _testPlayer.gameObject.layer),
    //             Times.Once);
    //     }
    //
    //     [Test]
    //     public void WhenCreateWeaponIsCalled_AndAllDataIsConfigued_ThenWeaponShouldBeCreated()
    //     {
    //         // Arrange
    //         var bulletSpawner = Container.Resolve<BulletSpawner>();
    //         var weaponFactory = new TestWeaponFactory(bulletSpawner);
    //         WeaponCreator weaponCreator = new WeaponCreator(weaponFactory);
    //
    //         // Act
    //         WeaponComponent result = weaponCreator.CreateWeapon(
    //             _testWeaponConfig, _testPlayer.transform, (LayerMask)_testPlayer.gameObject.layer)
    //             as WeaponComponent;
    //
    //         // Assert
    //         Assert.IsNotNull(result);
    //     }
    // }
    //
    // public class TestWeaponFactory : PlaceholderFactory
    // <WeaponConfig, Transform[], int, WeaponComponent>
    // {
    //     private BulletSpawner _bulletSpawner;
    //
    //     [Inject]
    //     public TestWeaponFactory(BulletSpawner bulletSpawner)
    //     {
    //         _bulletSpawner = bulletSpawner;
    //     }
    //     public override WeaponComponent Create(WeaponConfig config, Transform[] parent, int layer)
    //     {
    //         return new WeaponComponent(_bulletSpawner, config, parent);
    //     }
    // }
}