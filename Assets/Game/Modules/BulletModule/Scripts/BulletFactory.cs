using Zenject;

namespace Game.Modules.BulletModule.Scripts
{
    //ToDo : Possibly remove.
    public class BulletFactory : IBulletFactory
    {
        private readonly IFactory<float, BulletEntity> _factory;

        public BulletFactory(IFactory<float, BulletEntity> factory)
        {
            _factory = factory;
        }

        public BulletEntity Create(float bulletSpeed)
        {
           return  _factory.Create(bulletSpeed);
        }
    }

    public interface IBulletFactory
    {
        public BulletEntity Create(float bulletSpeed);
    }
}