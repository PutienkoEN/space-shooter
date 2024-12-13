using Zenject;

namespace Game.Modules.BulletModule
{
    public class BulletViewFactory
    {
        private readonly DiContainer _container;

        [Inject]
        public BulletViewFactory(DiContainer container)
        {
            _container = container;
        }

        public BulletView Create(BulletView param1, BulletData bulletData)
        {
            var subContainer = _container.CreateSubContainer();

            subContainer.Bind<BulletData>().FromInstance(bulletData).AsSingle();
            return subContainer.InstantiatePrefabForComponent<BulletView>(param1);
        }
    }
}