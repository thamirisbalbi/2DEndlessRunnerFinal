using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class HighScoreTextController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;
    private int highScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void OnEnable()
    {
        highScore = PlayerPrefs.GetInt("highscore");
        highScoreText.text = "High Score: " + highScore.ToString();
    }
    
}
