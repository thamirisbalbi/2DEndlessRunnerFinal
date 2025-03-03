using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverMenuController : MonoBehaviour
{
    public void OnStartClick() //restart button
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnExitClick() //exitbutton
    {
        SceneManager.LoadScene("StartScene");
    }
}
