using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class ImmanentManager : MonoBehaviour
{
    [Header("Immanent")]
 
    [SerializeField] private float startingImmanent ;

    public float currentImmanent { get; private set; }
    public float totalImmanent { get; private set; }

    //private Animator anim;

    //private bool fullImmanent;

    //[Header("iFrames")]
    //[SerializeField] private float iFramesDuration;
    //[SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        startingImmanent = 1;
        //anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
      
    }

    public void addImmanent(float value)
    {
     
        float adjustedValue = value / 10f; // Chia giá trị cho 10
        currentImmanent = Mathf.Clamp(currentImmanent + adjustedValue, 0, startingImmanent);

    }

}



