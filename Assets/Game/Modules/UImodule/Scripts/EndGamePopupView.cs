﻿using UnityEngine;
using UnityEngine.UI;

namespace Game.Modules.UImodule
{
    public sealed class EndGamePopupView : MonoBehaviour
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private Text endGameScoreText;

        public Button RestartButton => restartButton;
        public Button ExitButton => exitButton;

        public void SetScore(string endGameScore)
        {
            endGameScoreText.text = endGameScore;
        }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}