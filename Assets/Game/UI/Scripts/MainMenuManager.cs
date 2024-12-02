using UnityEngine;
using Zenject;

namespace Game.UI.Scripts
{
    public class MainMenuManager : IInitializable
    {
        private readonly Animator _animator;
        private const string IsOpen = "Open";
        private int _isOpenId;

        public MainMenuManager(Animator animator)
        {
            _animator = animator;
        }

        public void Initialize()
        {
            _isOpenId = Animator.StringToHash(IsOpen);
            _animator.SetBool(_isOpenId, true);
        }
    }
}