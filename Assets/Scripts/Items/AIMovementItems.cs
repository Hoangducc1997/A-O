using UnityEngine;

public class AIMovementItems : MonoBehaviour
{
    public float speed = 0.8f;
    public float range = 3f;
    float startingX;
    int dir = 1;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider1;
    private BoxCollider2D boxCollider2;

    void Start()
    {
        startingX = transform.position.x;
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Lấy tham chiếu tới cả hai BoxCollider2D trong cùng một đối tượng
        BoxCollider2D[] colliders = GetComponentsInChildren<BoxCollider2D>();
        if (colliders.Length >= 2)
        {
            boxCollider1 = colliders[0];
            boxCollider2 = colliders[1];
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime * dir);
        if (transform.position.x < startingX || transform.position.x > startingX + range)
            dir *= -1;

        // Xoay đối tượng dựa trên hướng di chuyển
        Flip();
        // Đảo offset của cả hai BoxCollider2D dựa trên hướng di chuyển
        FlipColliders();
    }

    void Flip()
    {
        spriteRenderer.flipX = (dir < 0);
    }

    void FlipColliders()
    {
        // Nếu đang đi về bên trái, đảo offset của cả hai collider
        if (dir < 0)
        {
            // Đặt offset âm cho BoxCollider1 và BoxCollider2 để dịch về bên trái
            boxCollider1.offset = new Vector2(Mathf.Abs(boxCollider1.offset.x), boxCollider1.offset.y);
            boxCollider2.offset = new Vector2(-Mathf.Abs(boxCollider2.offset.x), boxCollider2.offset.y);
        }
        else // Nếu đang đi về bên phải, đảo lại offset của cả hai collider
        {
            // Đặt offset dương cho BoxCollider1 và BoxCollider2 để dịch về bên phải
            boxCollider1.offset = new Vector2(-Mathf.Abs(boxCollider1.offset.x), boxCollider1.offset.y);
            boxCollider2.offset = new Vector2(Mathf.Abs(boxCollider2.offset.x), boxCollider2.offset.y);
        }
    }
}
