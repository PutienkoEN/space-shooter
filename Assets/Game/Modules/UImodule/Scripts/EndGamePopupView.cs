using Game.Modules.UImodule.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Modules.UImodule
{
    public class EndGamePopupView : MonoBehaviour, IPopup
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