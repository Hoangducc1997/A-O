using UnityEngine;
using UnityEngine.UI;

public class ImmanentBar : MonoBehaviour
{
    [SerializeField] private ImmanentManager playerImmanent;
    [SerializeField] private Image totalImmanentBar;
    [SerializeField] private Image currentImmanentBar;

    // Start is called before the first frame update
    void Start()
    {
        totalImmanentBar.fillAmount = 1; // Đặt fillAmount của totalImmanentBar thành 1 để đảm bảo đầy đủ ban đầu.
    }

    // Update is called once per frame
    void Update()
    {
        // Đặt fillAmount của currentImmanentBar tương ứng với giá trị totalImmanent của playerImmanent
        currentImmanentBar.fillAmount = playerImmanent.currentImmanent ;
    }
}
