using UnityEngine;
using UnityEngine.UI;

namespace Game.Modules.UImodule
{
    public sealed class EndGamePopupView : MonoBehaviour
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button exitButton;
        
        public Button RestartButton => restartButton;
        public Button ExitButton => exitButton;
        
        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}