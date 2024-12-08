using System;
using System.Threading;
using UnityEngine;

namespace Effects.Explosion
{
    public interface IEffect
    {
        public void Play(
            Vector3 position, 
            Quaternion rotation, 
            Action callback, 
            CancellationToken cancellationToken);
    }
}