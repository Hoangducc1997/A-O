using System.Collections;
using UnityEngine;

public class BreakObject : MonoBehaviour
{
    private ParticleSystem particle;

    private int playerCollisionCount = 0;

    private void Awake()
    {
        particle = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCollisionCount++;

            if (playerCollisionCount >= 2)
            {
                StartCoroutine(Break());
            }
        }
    }

    private IEnumerator Break()
    {
        particle.Play();
        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(gameObject);
    }
}
