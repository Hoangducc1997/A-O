using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManagerMain : MonoBehaviour
{
    public AudioSource musicSources;
    public AudioSource sfxSources;

    public AudioClip[] musicClips;

    [System.Serializable]
    public class SoundS
    {
        public string name;  // Tên của âm thanh
        public AudioClip clip; // Clip âm thanh
    }


    public SoundS[] sfxClips;

    private bool audioPlaying = false;
    public void Home()
    {

        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }

    private void Awake()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void OnSceneUnloaded(Scene scene)
    {
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        PlayMusic(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        // Kiểm tra xem âm thanh còn đang phát hay không
        if (musicSources.isPlaying || sfxSources.isPlaying)
        {
            audioPlaying = true;
        }
        else
        {
            audioPlaying = false;
        }

        // Hủy AudioManagerMain nếu không có âm thanh nào đang phát
        if (!audioPlaying)
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(int sceneIndex)
    {
        // Kiểm tra xem có âm nhạc nào được gán cho scene này không
        if (sceneIndex < musicClips.Length && musicClips[sceneIndex] != null)
        {
            musicSources.clip = musicClips[sceneIndex];
            musicSources.Play();
        }
    }

    public void PlaySFX(string name)
    {
        // Tìm âm thanh trong danh sách theo tên và chơi nó
        SoundS sfx = System.Array.Find(sfxClips, s => s.name == name);
        if (sfx != null)
        {
            sfxSources.PlayOneShot(sfx.clip);
            Debug.Log("Yes");
        }
        else
        {
            Debug.LogWarning("SFX clip with name " + name + " not found!");
        }
    }

}
