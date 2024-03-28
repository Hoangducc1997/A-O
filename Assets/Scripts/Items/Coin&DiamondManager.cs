using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CoinDiamondManager : MonoBehaviour
{
    public static CoinDiamondManager instance;
    [SerializeField] public Text Cointext;
    [SerializeField] public Text[] Diamondtext; // Đổi Diamondtext thành một mảng
    [SerializeField] private Text CoinRequirementText; // Mục tiêu qua vòng mới

    [SerializeField] public GameObject BoxFinal;

    GameManagerLevel gameManagerLevel;
    private int coinScore;
    private int diamondScore = 0;

    private bool boxFinalDestroyed;
    private int[] coinsDestroyBoxFinal = { 5, 19, 35, 55, 79, 100 }; // Mảng số lượng coin cần ở mỗi cấp độ

    void Start()
    {
        //UpdateUIDiamondText();
        if (instance == null)
        {
            instance = this;
            coinScore = 0;

            boxFinalDestroyed = false; // Đặt giá trị ban đầu

            int currentLevel = SceneManager.GetActiveScene().buildIndex - 2;
            if (CoinRequirementText != null && currentLevel < coinsDestroyBoxFinal.Length)
            {
                // Cập nhật giá trị của coinRequirementText dựa trên cấp độ hiện tại
                CoinRequirementText.text = "  / " + coinsDestroyBoxFinal[currentLevel].ToString();
            }
        }

    }

    public void changeScoreCoin(int coinValue)
    {
        coinScore += coinValue;

        if (Cointext != null)
        {
            Cointext.text = ": " + coinScore.ToString();
        }
        CheckAndDestroyBoxFinal();

    }

    public void changeScoreDiamond(int diamondValue)
    {
        diamondScore += diamondValue; // Cộng dồn điểm kim cương vào biến diamondScore

        if (Diamondtext != null)
        {
            foreach (Text text in Diamondtext) // Cập nhật mỗi phần tử trong mảng Diamondtext
            {
                text.text = ": " + diamondScore.ToString(); // Hiển thị điểm kim cương lên UI
            }
        }

        if (PlayerGameData.Instance != null)
        {
            PlayerGameData.Instance.AddDimond(diamondValue);
        }
        else
        {
            Debug.LogError("PlayerGameData.Instance is null");
        }

    }


    public bool HasEnoughDiamondsForPurchase(int diamondCost)
    {
        return PlayerGameData.Instance.PlayerData.totalDiamond >= diamondCost;
    }

    public void ResetScores()
    {
        coinScore = 0;
     
        boxFinalDestroyed = false; // Đặt lại giá trị khi reset
        UpdateUICoinText();
     
    }

    private void UpdateUICoinText()
    {
        // Cập nhật text UI ở đây
        if (Cointext != null)
        {
            Cointext.text = ": " + coinScore.ToString();
        }
    }

    private void UpdateUIDiamondText()
    {
        if (Diamondtext != null)
        {
            foreach (Text text in Diamondtext) // Cập nhật mỗi phần tử trong mảng Diamondtext
            {
                text.text = ": " + PlayerGameData.Instance.PlayerData.totalDiamond.ToString();
                //SaveManager.Save(PlayerGameData.Instance);
            }
        }
       
    }

    public void CheckAndDestroyBoxFinal()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex - 2;

        Debug.Log("Coin Score: " + coinScore);
        Debug.Log("BoxFinal Destroyed: " + boxFinalDestroyed);
            
        if (coinScore >= coinsDestroyBoxFinal[currentLevel] && !boxFinalDestroyed)
        {
            Debug.Log("Destroying BoxFinal");   
            boxFinalDestroyed = true;
            Destroy(BoxFinal);
        }
    }
}
