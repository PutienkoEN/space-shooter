using Game.Modules.Common.Interfaces;
using UnityEngine;

namespace SpaceShooter.Game.Enemy
{
    public interface IEnemyView : IEntityView, ICollidable, IDamageDealer, IDamageable, IBoundsCheckable
    {
        public void SetActive(bool value);
        public void PlayDeathSound();
        
    }
}