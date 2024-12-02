using System;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using IInitializable = Zenject.IInitializable;

namespace Game.UI.Scripts
{
    public class MainMenuManager : IInitializable, IDisposable
    {
        private readonly Animator _animator;
        private readonly Button _startGameButton;
        private readonly Button _quitGameButton;
        
        private const string IsOpen = "Open";
        private const string IsClosed = "Closed";
        private const string GameScene = "GameScene";
        
        private int _isOpenId;

        public MainMenuManager(
            Animator animator, 
            Button startGameButton, 
            Button quitGameButton)
        {
            _animator = animator;
            _startGameButton = startGameButton;
            _quitGameButton = quitGameButton;
        }

        public void Initialize()
        {
            _isOpenId = Animator.StringToHash(IsOpen);
            _animator.SetBool(_isOpenId, true);
            
            _startGameButton.onClick.AddListener(HandleStartGameClicked);
            _quitGameButton.onClick.AddListener(HandleQuitGameClicked);
        }
        
        public void Dispose()
        {
            _startGameButton.onClick.RemoveListener(HandleStartGameClicked);
            _quitGameButton.onClick.RemoveListener(HandleQuitGameClicked);
        }
        
        private void HandleStartGameClicked()
        {
            _animator.SetBool(_isOpenId, false);
            DelaySceneLoad().Forget();
        }
        
        private async UniTask DelaySceneLoad()
        {
            await WaitForAnimation();
            await SceneManager.LoadSceneAsync(GameScene, LoadSceneMode.Single);
        }

        private void HandleQuitGameClicked()
        {
            Application.Quit();
        }

        private async UniTask WaitForAnimation()
        {
            while (true)
            {
                var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);

                // Exit the loop if "Closed" animation is active and fully completed
                if (stateInfo.IsName(IsClosed) && stateInfo.normalizedTime >= 1f)
                {
                    break;
                }

                await UniTask.Yield();
            }
           
        }
    }
}