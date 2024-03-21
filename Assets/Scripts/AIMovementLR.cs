using UnityEngine;
using UnityEngine.SceneManagement;
public class AIMovementLR : MonoBehaviour
{
    [SerializeField] public float speed = 0.8f;
    [SerializeField] public float range = 3f;
    float startingX;
    int dir = 1;

    // Start is called before the first frame update
    void Start()
    {
        startingX = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime * dir);
        if (transform.position.x < startingX || transform.position.x > startingX + range)
            dir *= -1;
    }
}
