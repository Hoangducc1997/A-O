using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public void openLevel(int level)
    {
        AudioManager.Instance.PlaySFX("ChooseLevel");
        string levelName = "Level " + level;
        SceneManager.LoadScene(levelName);
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


    //public Slider _musicSliderMenu, _musicSliderLevel, _sfxSlider;


    ////private void Start()
    ////{
    ////    LoadAudioSettings();
    ////}

    

    ////private void LoadAudioSettings()
    ////{
       
    ////    if (PlayerGameData.Instance != null)
    ////    {
    ////        _musicSliderMenu.value = PlayerGameData.Instance.musicVolumeMenu;
    ////        _musicSliderLevel.value = PlayerGameData.Instance.musicVolumeLevel;
    ////        _sfxSlider.value = PlayerGameData.Instance.sfxVolume;
           
    ////    }
    ////    else
    ////    {
    ////        PlayerGameData.Instance = SaveManager.Load();
    ////    }
    ////}




    ////private void SaveAudioSettings()
    ////{
    ////    PlayerGameData.Instance.SaveSetting(
    ////        _musicSliderMenu.value,
    ////        _musicSliderLevel.value,
    ////        _sfxSlider.value
    ////    );
    ////}


    //public void MuteMenuMusic()
    //{
    //    AudioManager.Instance.MuteMenuMusic();
    //   // SaveAudioSettings();
    //}

    //public void UnmuteMenuMusic()
    //{
    //    AudioManager.Instance.UnmuteMenuMusic();
    //    //SaveAudioSettings();
    //}

    //public void MuteLevelMusic()
    //{
    //    AudioManager.Instance.MuteLevelMusic();
    //    //SaveAudioSettings();
    //}

    //public void UnmuteLevelMusic()
    //{
    //    AudioManager.Instance.UnmuteLevelMusic();
    //   // SaveAudioSettings();
    //}

    //public void MuteSFX()
    //{
    //    AudioManager.Instance.MuteSFX();
    //   // SaveAudioSettings();
    //}

    //public void UnmuteSFX()
    //{
    //    AudioManager.Instance.UnmuteSFX();
    //    //SaveAudioSettings();
    //}

    //// Các hàm kiểm tra trạng thái âm thanh
    //private bool IsMenuMusicMuted()
    //{
    //    return AudioManager.Instance.IsMenuMusicMuted();
    //}

    //private bool IsLevelMusicMuted()
    //{
    //    return AudioManager.Instance.IsLevelMusicMuted();
    //}

    //private bool IsSfxMuted()
    //{
    //    return AudioManager.Instance.IsSfxMuted();
    //}

    //public void MusicVolumeMenu()
    //{
    //    if (AudioManager.Instance != null)
    //    {
    //        AudioManager.Instance.musicVolumeMenu(_musicSliderMenu.value);
    //       // SaveAudioSettings();
    //    }
    //    else
    //    {
    //        Debug.LogWarning("AudioManager.Instance is null. Unable to set music volume.");
    //    }
    //}

    //public void MusicVolumeLevel()
    //{
    //    if (AudioManager.Instance != null)
    //    {
    //        AudioManager.Instance.musicVolumeLevel(_musicSliderLevel.value);
    //       // SaveAudioSettings();
    //    }
    //}

    //public void SfxVolume()
    //{
    //    if (AudioManager.Instance != null)
    //    {
    //        AudioManager.Instance.sfxVolume(_sfxSlider.value);
    //       // SaveAudioSettings();
    //    }
    //}
}
