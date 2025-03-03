using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ScoreTextController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score;
    private int highScore;
    private float timer;
    void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "Score: " + score.ToString();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5f) //a cada 5seg
        {
            score += 100;
            scoreText.text = "Score: " + score.ToString();
            timer = 0;
        }
    }

    void OnDisable()
    {
        if (highScore < score)
            PlayerPrefs.SetInt("highscore", score); //passo score para a outra cena de gameOver
                                                    //  e comparo com o highScore armazenado
                                                    //passo essa informação para a tela de gameover
    }
}
