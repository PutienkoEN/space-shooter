using System;
using UnityEngine;

namespace Game.Modules.Components
{
    public class GameAreaCollider : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var obj = other.GetComponentInParent<IGameAreaEnter>();
            obj?.OnEnter();
        }

        private void OnTriggerExit(Collider other)
        {
            var obj = other.GetComponentInParent<IGameAreaExit>();
            obj?.OnExit();
        }
    }

    public interface IGameAreaEnter
    {
        public void OnEnter();
    }

    public interface IGameAreaExit
    {
        public void OnExit();
    }
}