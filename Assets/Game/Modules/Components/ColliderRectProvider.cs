using UnityEngine;

namespace Game.Modules.BulletModule.Scripts
{
    public sealed class ColliderRectProvider : IRectProvider
    {
        private Rect _colliderRect;
        
        public Rect GetColliderRect(Collider collider)
        {
            if (collider == null)
            {
                return Rect.zero;
            }
            Bounds colliderBounds = collider.bounds;
            if (_colliderRect == Rect.zero)
            {
                _colliderRect = CreateNewRect(colliderBounds);
            }
            else
            {
                UpdateRect(colliderBounds);
            }
            
            return _colliderRect;
        }

        private void UpdateRect(Bounds colliderBounds)
        {
            _colliderRect.x = colliderBounds.min.x;
            _colliderRect.y = colliderBounds.min.y;
            _colliderRect.width = colliderBounds.size.x;
            _colliderRect.height = colliderBounds.size.y;
        }

        private Rect CreateNewRect(Bounds colliderBounds)
        {
            return new Rect(
                colliderBounds.min.x,
                colliderBounds.min.y,
                colliderBounds.size.x,
                colliderBounds.size.y);
        }
    }

    public interface IRectProvider
    {
        public Rect GetColliderRect(Collider collider);
    }
}