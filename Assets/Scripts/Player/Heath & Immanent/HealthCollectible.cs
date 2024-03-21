using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue;
    [SerializeField] private AudioClip CollectibleHeart;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AudioManager.Instance.PlaySFX("Heart");
            collision.GetComponent<HealthManager>().addHealth(healthValue);
            gameObject.SetActive(false); //Xóa tim khi player đã nhận
        }
    }
}
