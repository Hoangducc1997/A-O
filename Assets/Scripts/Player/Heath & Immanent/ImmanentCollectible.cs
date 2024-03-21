using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImmanentCollectible : MonoBehaviour
{
    [Header("Claim grade")]
    [SerializeField] private float GradeImmanent;

    private Animator anim;
    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AudioManager.Instance.PlaySFX("Immanent");

            collision.GetComponent<ImmanentManager>().addImmanent(GradeImmanent);

            gameObject.SetActive(false); //Xóa item khi player đã nhận
            
        }
    }
    //Hàm bất tử 3 giây 
    //IEnumerator PlayerDeathTemporary()
    //{
    //    Physics2D.IgnoreLayerCollision(7, 8, true);
    //    for (int i = 0; i < numberOfFlashes; i++)
    //    {
    //        spriteRenderer.color = new Color(1, 0, 0, 0.5f);
    //        yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
    //        spriteRenderer.color = Color.white;
    //        yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2)); ;
    //    }
    //    Physics2D.IgnoreLayerCollision(7, 8, false);
    //}
}
