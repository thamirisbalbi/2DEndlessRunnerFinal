using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuController : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true); //quando o botão de pause for clicado o menu será ativado
        Time.timeScale = 0; //paro o tempo 
    
    }

    public void Home()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1;
        
    }

    public void Resume()
    {
        pauseMenu.SetActive(false); //fecho pause menu
        Time.timeScale = 1;

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //recarrega a cena ativa
        Time.timeScale = 1;

    }
}