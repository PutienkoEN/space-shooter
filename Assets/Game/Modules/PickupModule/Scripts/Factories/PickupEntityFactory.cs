using Zenject;

namespace Game.PickupModule.Scripts
{
    public class PickupEntityFactory
    {
        private readonly PickupViewFactory _pickupViewFactory;

        public PickupEntityFactory(PickupViewFactory pickupViewFactory)
        {
            _pickupViewFactory = pickupViewFactory;
        }

        public PickupEntity CreatePickupEntity(PickupCreateData data)
        {
            IPickupViewView iPickupViewView = _pickupViewFactory.Create(data);
            PickupEntity pickupEntity = iPickupViewView.GetComponent<GameObjectContext>().Container.Resolve<PickupEntity>();
            return pickupEntity;
        }
    }
}