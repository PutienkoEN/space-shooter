using Input;
using UnityEngine;
using Zenject;

namespace Game.Modules.Character
{
    public class CharacterInstaller : MonoInstaller
    {
        [SerializeField] private GameObject character;
        [SerializeField] private float speed;

        public override void InstallBindings()
        {
            var transform = character.GetComponent<Transform>();

            Container
                .Bind<CharacterMoveComponent>()
                .AsSingle()
                .WithArguments(transform, speed);
        }
    }
}