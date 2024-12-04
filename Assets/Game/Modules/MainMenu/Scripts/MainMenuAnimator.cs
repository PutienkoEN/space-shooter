using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.UI.Scripts
{
    public class MainMenuAnimator
    {
        private readonly Animator _animator;
        
        private const string IsOpen = "Open";
        private const string IsClosed = "Closed";
        private const string GameScene = "GameScene";
        
        private int _isOpenId;
        

        public MainMenuAnimator(Animator animator)
        {
            _animator = animator;
            
            Initialize();
        }

        public void Initialize()
        {
            _isOpenId = Animator.StringToHash(IsOpen);
            _animator.SetBool(_isOpenId, true);
            
        }
        
        public async UniTask HandleStartGameClicked()
        {
            _animator.SetBool(_isOpenId, false);
            await WaitForAnimation();
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