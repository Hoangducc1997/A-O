using UnityEngine;
using UnityEngine.SceneManagement;
public class AIMovementDU: MonoBehaviour
{
    [SerializeField] public float speed = 0.8f;
    [SerializeField] public float range = 3f;
    float startingY;
    int dir = 1;

    // Start is called before the first frame update
    void Start()
    {
        startingY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime * dir);
        if (transform.position.y < startingY || transform.position.y > startingY + range)
            dir *= -1;
    }
}
