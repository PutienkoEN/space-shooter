using UnityEngine;
using UnityEngine.UI;

namespace Game.Modules.MainMenu.Scripts
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button continueButton;
        [SerializeField] private Button startButton;
        [SerializeField] private Button exitButton;

        public Button ContinueButton => continueButton;
        public Button StartButton => startButton;
        public Button ExitButton => exitButton;
    }
}