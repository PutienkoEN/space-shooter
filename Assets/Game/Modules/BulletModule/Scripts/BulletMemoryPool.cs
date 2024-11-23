using UnityEngine;
using Zenject;

namespace Game.Modules.BulletModule.Scripts
{
    public class BulletMemoryPool : MonoMemoryPool<BulletComponent>
    {
        public BulletMemoryPool()
        {
            Debug.Log("BulletMemoryPool constructed");
        }
        protected override void OnCreated(BulletComponent item)
        {
            base.OnCreated(item);
            // Initialize any bullet-specific settings if needed
            item.gameObject.SetActive(false); // Start inactive
        }

        protected override void OnSpawned(BulletComponent item)
        {
            base.OnSpawned(item);
            item.gameObject.SetActive(true); // Activate when spawned
        }

        protected override void OnDespawned(BulletComponent item)
        {
            base.OnDespawned(item);
            item.gameObject.SetActive(false); // Deactivate when despawned
        }
    }
}