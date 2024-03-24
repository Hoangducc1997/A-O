using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerLevel : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject tutorialPanel; // Inner the pauseMenu

    public void openLevel(int level)
    {
        AudioManager.Instance.PlaySFX("ChooseLevel");
        string levelName = "Level " + level;
        SceneManager.LoadScene(levelName);
    }

    public void Pause()
    {
        // Hiển thị menu pause
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        // Tắt menu pause
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Home()
    {

        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }

    public void gameOver()
    {
        gameOverPanel.SetActive(true);
    }   

    public void Tutorial()
    {
        tutorialPanel.SetActive(true);
    }

    public void Restart()
    {
        CoinDiamondManager.instance.ResetScores();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

}