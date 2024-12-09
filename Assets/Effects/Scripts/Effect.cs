using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Effects.Explosion
{
    public abstract class Effect : MonoBehaviour, IEffect
    {
        
        public virtual void Play(Vector3 position, Quaternion rotation, Action callback, CancellationToken token)
        {
            if (token.IsCancellationRequested)
            {
                return;
            }
            Effect instance = Instantiate(position, rotation);
            float duration = instance.GetDuration();
            Delay(instance, duration, callback, token).Forget();
        }
        
        protected abstract float GetDuration();
        
        private Effect Instantiate(Vector3 position, Quaternion rotation)
        {
            return Instantiate(this, position, rotation);
        }
        
        private async UniTaskVoid Delay(Effect instance, float duration, Action callback, CancellationToken token)
        {
            try
            {
                await UniTask.WaitForSeconds(duration, cancellationToken: token);
                callback?.Invoke();
            }
            catch (OperationCanceledException)
            {
                Debug.Log("Effect delay canceled.");
            }
            finally
            {
                instance.Destroy();
            }
        }

        private void Destroy()
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}