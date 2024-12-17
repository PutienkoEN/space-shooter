using UnityEngine;
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

        public IPickupEntity CreatePickupEntity(PickupCreateData data)
        {
            PickupView pickupView = _pickupViewFactory.Create(data);
            return pickupView.GetComponent<GameObjectContext>().Container.Resolve<PickupEntity>();
        }
    }
}