using UnityEngine;
using UnityEngine.UI;

public class BuyMaps : MonoBehaviour
{
    public CoinDiamondManager coinDiamondManager; // Tham chiếu đến CoinDiamondManager
    public UnlockLevel unlockLevel; // Tham chiếu đến UnlockLevel

    public Button[] buttons;        // Levels
    public Animator[] levelAnimators;   // Animator của mỗi button tương ứng với mỗi level
    // Số lượng kim cương cần để mở khóa level
    public int diamondCost;

    // Trong phương thức BuyMapAndUnlock, sử dụng levelAnimators từ unlockLevel để kích hoạt trigger
    public void BuyMapAndUnlock()
    {
        if (coinDiamondManager != null && coinDiamondManager.HasEnoughDiamondsForPurchase(diamondCost))
        {
            coinDiamondManager.changeScoreDiamond(PlayerGameData.Instance.PlayerData.totalDiamond - diamondCost);

            buttons[2].interactable = true;

            // Kiểm tra xem mảng levelAnimators có đủ phần tử không
            if (levelAnimators != null )
            {
                // Kích hoạt animation "Lock 3" tại index 2 của mảng levelAnimators
                levelAnimators[2].SetTrigger("Lock 3");
            }
            else
            {
                Debug.LogError("Không đủ animator để mở khóa level 3.");
            }
            //PlayerGameData.Instance.AddNewMap(); // Lưu trữ dữ liệu gameData         
        }
        else
        {
            Debug.Log("Không đủ kim cương để mở map!");
        }
    }
}
