using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Diamond : MonoBehaviour
{
  
    public int diamondValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        CoinDiamondManager coinDiamondManager = CoinDiamondManager.instance;

        if (coinDiamondManager != null && other.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX("Diamond");   
            coinDiamondManager.changeScoreDiamond(diamondValue);
        }
    }

}
