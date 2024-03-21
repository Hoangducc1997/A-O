using System;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    // Định nghĩa các âm thanh cho từng scene
    public Sound[] scene1MusicSounds;
    public Sound[] scene2MusicSounds;
    public Sound[] scene3MusicSounds;
    // Thêm các scene khác nếu cần thiết

    public Sound[] sfxSounds;

    public AudioSource musicSources;
    public AudioSource musicSources1; // Thêm một AudioSource mới cho âm thanh từ scene2 và scene3
    public AudioSource sfxSources;

    // Mute flags
    private bool sfxMuted = false;
    private bool menuMusicMuted = false;
    private bool levelMusicMuted = false;

    private const string MenuMusicMutedKey = "MenuMusicMuted";
    private const string LevelMusicMutedKey = "LevelMusicMuted";
    private const string SfxMutedKey = "SfxMuted";

    // Khai báo các GameObject tương ứng với âm thanh để lưu trữ
    public GameObject OnSfxButton;
    public GameObject MuteSfxButton;
    public GameObject OnMusicMenuButton;
    public GameObject MuteMusicMenuButton;
    public GameObject OnMusicLevelButton;
    public GameObject MuteMusicLevelButton;

    // Khai báo các biến để lưu trữ cài đặt âm thanh của người chơi
    private const string MusicVolumeMenuKey = "MusicVolumeMenu";
    private const string MusicVolumeLevelKey = "MusicVolumeLevel";
    private const string SfxVolumeKey = "SfxVolume";

    public Slider _musicSliderMenu, _musicSliderLevel, _sfxSlider;

    //Khai báo GameObject dùng để lưu chức năng chọn nhanh âm thanh

    public GameObject Silent;
    public GameObject OnSound;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        // Load cài đặt âm thanh khi khởi động
        LoadAudioSettings();

        UpdateSlider();

        // Cập nhật trạng thái các gameobject dựa trên cài đặt âm thanh đã lưu
        UpdateAdjustSound();

        UpdateChoiceSound();
        // Chơi âm thanh cho scene hiện tại
        PlayMusicForScene(SceneManager.GetActiveScene().name);

        // Đăng ký lắng nghe sự kiện khi scene được load
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Hàm cập nhật trạng thái các gameobject
    private void UpdateAdjustSound()
    {
        OnSfxButton.SetActive(!IsSfxMuted());
        MuteSfxButton.SetActive(IsSfxMuted());
        OnMusicMenuButton.SetActive(!IsMenuMusicMuted());
        MuteMusicMenuButton.SetActive(IsMenuMusicMuted());
        OnMusicLevelButton.SetActive(!IsLevelMusicMuted());
        MuteMusicLevelButton.SetActive(IsLevelMusicMuted());

    }

    private void UpdateChoiceSound()
    {
        Silent.SetActive(!IsSfxMuted() || !IsMenuMusicMuted() || !IsLevelMusicMuted()); // Nút chọn im lặng thì 3 hàm này phải im lặng
        OnSound.SetActive(IsSfxMuted() || IsMenuMusicMuted() || IsLevelMusicMuted());
    }

    private void UpdateSlider()
    {
        // Cập nhật giá trị âm lượng cho Slider của SFX
        if (_sfxSlider != null)
        {
            _sfxSlider.value = sfxSources.volume;
        }

        // Cập nhật giá trị âm lượng cho Slider của Music Menu
        if (_musicSliderMenu != null)
        {
            _musicSliderMenu.value = musicSources.volume;
        }

        // Cập nhật giá trị âm lượng cho Slider của Music Level
        if (_musicSliderLevel != null)
        {
            _musicSliderLevel.value = musicSources1.volume;
        }
    }

    private void PlayMusicForScene(string sceneName)
    {
        Sound[] sounds;
        switch (sceneName)
        {
            case "Menu":
                sounds = scene1MusicSounds;
                break;
            case "Level 1":
                sounds = scene2MusicSounds;
                break;
            case "Level 2":
                sounds = scene3MusicSounds;
                break;
            // Thêm các case cho các scene khác nếu cần thiết
            default:
                sounds = null;
                break;
        }

        // Chơi âm thanh nếu có
        if (sounds != null && sounds.Length > 0)
        {
            if (sceneName == "Menu")
            {
                musicSources.clip = sounds[0].clip;
                musicSources.Play();
                // Đảm bảo rằng musicSources1 đã dừng phát nhạc (nếu có)
                if (musicSources1.isPlaying)
                {
                    musicSources1.Stop();
                }
            }
            else
            {
                musicSources1.clip = sounds[0].clip;
                musicSources1.Play();
                // Đảm bảo rằng musicSources đã dừng phát nhạc (nếu có)
                if (musicSources.isPlaying)
                {
                    musicSources.Stop();
                }
            }
        }
    }

    // Lắng nghe sự kiện khi scene được tải và chơi âm thanh cho scene mới
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene.name);
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSources.PlayOneShot(s.clip);
        }
    }

    private void LoadAudioSettings()
    {
        musicSources.volume = PlayerPrefs.GetFloat(MusicVolumeMenuKey, 1f);
        musicSources1.volume = PlayerPrefs.GetFloat(MusicVolumeLevelKey, 1f);
        sfxSources.volume = PlayerPrefs.GetFloat(SfxVolumeKey, 1f);

        menuMusicMuted = PlayerPrefs.GetInt(MenuMusicMutedKey, 0) == 1;
        levelMusicMuted = PlayerPrefs.GetInt(LevelMusicMutedKey, 0) == 1;
        sfxMuted = PlayerPrefs.GetInt(SfxMutedKey, 0) == 1;

        // Update mute state based on loaded settings
        musicSources.mute = menuMusicMuted;
        musicSources1.mute = levelMusicMuted;
        sfxSources.mute = sfxMuted;

    }
    private void SaveAudioSettings()
    {
            PlayerPrefs.SetFloat(MusicVolumeMenuKey, musicSources.volume);
            PlayerPrefs.SetFloat(MusicVolumeLevelKey, musicSources1.volume);
            PlayerPrefs.SetFloat(SfxVolumeKey, sfxSources.volume);

            PlayerPrefs.SetInt(MenuMusicMutedKey, menuMusicMuted ? 1 : 0);
            PlayerPrefs.SetInt(LevelMusicMutedKey, levelMusicMuted ? 1 : 0);
            PlayerPrefs.SetInt(SfxMutedKey, sfxMuted ? 1 : 0);

            PlayerPrefs.Save();
        
    }
        public void MuteMenuMusic()
    {
        menuMusicMuted = !menuMusicMuted;
        musicSources.mute = menuMusicMuted;
        
        UpdateAdjustSound(); // Cập nhật trạng thái các gameobject sau khi thay đổi trạng thái mute
        SaveAudioSettings();
    }

    public void MuteLevelMusic()
    {
        levelMusicMuted = !levelMusicMuted;
        musicSources1.mute = levelMusicMuted;
        
        UpdateAdjustSound(); // Cập nhật trạng thái các gameobject sau khi thay đổi trạng thái mute
        SaveAudioSettings();
    }

    public void MuteSFX()
    {
        sfxMuted = !sfxMuted;
        sfxSources.mute = sfxMuted;
        
        UpdateAdjustSound(); // Cập nhật trạng thái các gameobject sau khi thay đổi trạng thái mute
        SaveAudioSettings();
    }


    public void UnmuteMenuMusic()
    {
        menuMusicMuted = false;
        musicSources.mute = false;
        
        UpdateAdjustSound();
        SaveAudioSettings();
    }

    public void UnmuteLevelMusic()
    {
        levelMusicMuted = false;
        musicSources1.mute = false;
        
        UpdateAdjustSound();
        SaveAudioSettings();
    }

    public void UnmuteSFX()
    {
        sfxMuted = false;
        sfxSources.mute = false;
        
        UpdateAdjustSound();
        SaveAudioSettings();
    }

    public void musicVolumeMenu(float volume)
    {
        musicSources.volume = volume;
        SaveAudioSettings();
        UpdateSlider();
    }

    public void musicVolumeLevel(float volume)
    {
        musicSources1.volume = volume;
        SaveAudioSettings();
        UpdateSlider();
    }

    public void sfxVolume(float volume)
    {
        sfxSources.volume = volume;
        SaveAudioSettings();
        UpdateSlider();
    }

    public bool IsSfxMuted()
    {
        return sfxMuted;
    }

    public bool IsMenuMusicMuted()
    {
        return menuMusicMuted;
    }

    public bool IsLevelMusicMuted()
    {
        return levelMusicMuted;
    }
}
