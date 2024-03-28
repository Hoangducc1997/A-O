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


    //Button sound
    [SerializeField] private Slider _musicSliderMenu, _musicSliderLevel, _sfxSlider;
    public void MuteMenuMusic()
    {
        AudioManager.Instance.MuteMenuMusic();
        // SaveAudioSettings();
    }

    public void UnmuteMenuMusic()
    {
        AudioManager.Instance.UnmuteMenuMusic();
        //SaveAudioSettings();
    }

    public void MuteLevelMusic()
    {
        AudioManager.Instance.MuteLevelMusic();
        //SaveAudioSettings();
    }

    public void UnmuteLevelMusic()
    {
        AudioManager.Instance.UnmuteLevelMusic();
        // SaveAudioSettings();
    }

    public void MuteSFX()
    {
        AudioManager.Instance.MuteSFX();
        // SaveAudioSettings();
    }

    public void UnmuteSFX()
    {
        AudioManager.Instance.UnmuteSFX();
        //SaveAudioSettings();
    }

    // Các hàm kiểm tra trạng thái âm thanh
    private bool IsMenuMusicMuted()
    {
        return AudioManager.Instance.IsMenuMusicMuted();
    }

    private bool IsLevelMusicMuted()
    {
        return AudioManager.Instance.IsLevelMusicMuted();
    }

    private bool IsSfxMuted()
    {
        return AudioManager.Instance.IsSfxMuted();
    }

    public void MusicVolumeMenu()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.musicVolumeMenu(_musicSliderMenu.value);
            // SaveAudioSettings();
        }
        else
        {
            Debug.LogWarning("AudioManager.Instance is null. Unable to set music volume.");
        }
    }

    public void MusicVolumeLevel()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.musicVolumeLevel(_musicSliderLevel.value);
            // SaveAudioSettings();
        }
    }

    public void SfxVolume()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.sfxVolume(_sfxSlider.value);
            // SaveAudioSettings();
        }
    }

}