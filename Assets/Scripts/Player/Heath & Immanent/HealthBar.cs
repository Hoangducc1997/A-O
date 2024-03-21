using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [SerializeField] private HealthManager playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    public Image CurrentHealthBar => currentHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        totalHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}
