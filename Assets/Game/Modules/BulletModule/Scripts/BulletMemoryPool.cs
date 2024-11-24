using UnityEngine;
using Zenject;

namespace Game.Modules.BulletModule.Scripts
{
    public class BulletMemoryPool : MonoMemoryPool<BulletView>
    {
        public BulletMemoryPool()
        {
            Debug.Log("BulletMemoryPool constructed");
        }
        protected override void OnCreated(BulletView item)
        {
            base.OnCreated(item);
            // Initialize any bullet-specific settings if needed
            item.gameObject.SetActive(false); // Start inactive
        }

        protected override void OnSpawned(BulletView item)
        {
            base.OnSpawned(item);
            item.gameObject.SetActive(true); // Activate when spawned
        }

        protected override void OnDespawned(BulletView item)
        {
            base.OnDespawned(item);
            item.gameObject.SetActive(false); // Deactivate when despawned
        }
    }
}