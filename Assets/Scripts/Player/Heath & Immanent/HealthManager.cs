using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
  
    public float currentHealth { get; private set ; }
 
    private Animator anim;
    private bool death;


    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Phương thức sẽ được gọi khi Animation Event kích hoạt
    public void OnPlayerGameOverAnimationEvent()
    {
        // Gọi hàm gameOver trong MenuManager
        FindObjectOfType<GameManagerLevel>()?.gameOver();
        
    }

    //Hàm kiểm soát lượng tim của player
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if(currentHealth > 0)
        {
            AudioManager.Instance.PlaySFX("Hurt");
            anim.SetTrigger("PlayerDeathTemporary");
            StartCoroutine(PlayerDeathTemporary());        
        }
        else
        {
            if(!death)
            {
                AudioManager.Instance.PlaySFX("GameOver");
                anim.SetTrigger("PlayerGameOver");
                GetComponent<Player>().enabled = false;
                death = true;
            }         
        }

            //Hàm bất tử 3 giây 
            IEnumerator PlayerDeathTemporary()
        {
            Physics2D.IgnoreLayerCollision(7, 8, true);
            for (int i = 0; i < numberOfFlashes; i++)
            {
                spriteRenderer.color = new Color(1, 0, 0, 0.5f);
                yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
                spriteRenderer.color = Color.white;
                yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2)); ;
            }
            Physics2D.IgnoreLayerCollision(7, 8, false);
        }
    }


    //Hàm tăng tim cho player
    public void addHealth(float _value)
    {
        float adjustedValue = _value / 10f; // Chia giá trị cho 10
        currentHealth = Mathf.Clamp(currentHealth + _value, 0 , startingHealth);
    }
}
