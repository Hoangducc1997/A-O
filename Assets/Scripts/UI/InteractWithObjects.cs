using UnityEngine;

public class InteractWithObjects : MonoBehaviour
{
    [SerializeField] private GameObject interactObject1; // Hướng dẫn hiển thị khi gần vùng tương tác
    [SerializeField] private GameObject interactObject2;
    private bool isInRange = false; // Biến kiểm tra xem Player có gần vùng tương tác không

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
            ShowInteractObject();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            HideInteractObject();
        }
    }

    private void Update()
    {
        // Kiểm tra nếu Player gần vùng tương tác và nhấn nút tương tác (vd: Space)
        if (isInRange && Input.GetKeyDown(KeyCode.Space))
        {
            Interact();
        }
    }

    //Khác null để tránh lỗi khi nhân vật đang đứng trong khoảng Tutorial và nhấn Restart
    private void ShowInteractObject()
    {
        if (interactObject1 != null)
        {
            interactObject1.SetActive(true);
        }
        if (interactObject2 != null)
        {
            interactObject2.SetActive(true);
        }
    }

    private void HideInteractObject()
    {
        if (interactObject1 != null)
        {
            interactObject1.SetActive(false);
        }
        if (interactObject2 != null)
        {
            interactObject2.SetActive(false);
        }
    }


    private void Interact()
    {
        // Thực hiện hành động tương tác tại đây (vd: mở cửa, nhận vật phẩm, v.v.)
    }
}
