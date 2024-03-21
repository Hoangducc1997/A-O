using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public void nextLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        if (currentLevel + 1 >= unlockedLevel)
        {
            PlayerPrefs.SetInt("UnlockedLevel", currentLevel);  // Mở scene tiếp theo
            PlayerPrefs.Save();
        }

        SceneManager.LoadSceneAsync(currentLevel + 1);
       
    }



    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}