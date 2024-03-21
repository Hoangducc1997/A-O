using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelection : MonoBehaviour
{
    private bool active = false;

    
    public void ChangeLocale(int localeID)
    {
        
        if (active) return;
        StartCoroutine(SetLocale(localeID));

        // Lưu localeID vào PlayerPrefs khi người dùng thay đổi ngôn ngữ
        PlayerPrefs.SetInt("SelectedLocaleID", localeID);
        PlayerPrefs.Save();
    }

    IEnumerator SetLocale(int _localeID)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
        active = false;
    }


    // Hàm để tải lại ngôn ngữ được chọn từ PlayerPrefs khi khởi động
    private void Start()
    {
        //ClearPlayerPrefs();
        // Kiểm tra xem có giá trị localeID đã được lưu trong PlayerPrefs không
        if (PlayerPrefs.HasKey("SelectedLocaleID"))
        {
            int selectedLocaleID = PlayerPrefs.GetInt("SelectedLocaleID");
            StartCoroutine(SetLocale(selectedLocaleID));
        }
    }

    // Hàm để xóa dữ liệu PlayerPrefs
    public void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("PlayerPrefs data cleared.");
    }
}
