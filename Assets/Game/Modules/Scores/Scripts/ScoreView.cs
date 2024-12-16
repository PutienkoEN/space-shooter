using TMPro;
using UnityEngine;

namespace Game.Modules.Scores
{
    public class ScoreView : MonoBehaviour, IScoreView
    {
        [SerializeField] private TMP_Text scoreText;

        public void SetScoreText(string score)
        {
            scoreText.text = score;
        }
    }
}