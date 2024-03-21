using UnityEngine;
using UnityEngine.UI;

public class UnlockLevel : MonoBehaviour
{
    public Button[] buttons;        // Levels
    public Animator[] levelAnimators;   // Animator của mỗi button tương ứng với mỗi level

    private void Awake()
    {
        // Xóa dữ liệu lưu trữ PlayerPrefs khi cần thiết
        // Gọi hàm này từ nơi nào đó trong code của bạn khi bạn muốn xóa dữ liệu
        //ClearPlayerPrefs();

        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;

            // Kích hoạt animation tương ứng của mỗi button nếu muốn
            if (i < levelAnimators.Length && levelAnimators[i] != null)
            {
                if (i == 1)
                {
                    levelAnimators[i].SetTrigger("Lock 1");
                }
                if (i == 2)
                {
                    levelAnimators[i].SetTrigger("Lock 2");
                }
                if (i == 3)
                {
                    levelAnimators[i].SetTrigger("Lock 3");
                }
                if (i == 4)
                {
                    levelAnimators[i].SetTrigger("Lock 4");
                }
                if (i == 5)
                {
                    levelAnimators[i].SetTrigger("Lock 5");
                }
            }
        }
    }

    // Hàm để xóa dữ liệu PlayerPrefs
    public void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("PlayerPrefs data cleared.");
    }
   
}

