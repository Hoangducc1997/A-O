using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FinishPoint : MonoBehaviour
{
    [SerializeField] private GameObject nextLevelPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            nextLevelPanel.SetActive(true);
            //UnlockNewLevel();
            //SceneController.instance.nextLevel();
        }
    }

    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }

    public void NextLevel()
    {
        UnlockNewLevel();
        SceneController.instance.nextLevel();
    }
}