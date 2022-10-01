using UnityEngine;
using TMPro;

public class ScoreTextDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public void UpdateScore(int score)
    {
        scoreText.text = $"SCORE: {score}";
    }
}
