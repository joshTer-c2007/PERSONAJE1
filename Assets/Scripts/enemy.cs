using UnityEngine;

public class enemy : MonoBehaviour
{
    [Header("Enemy Movement")]
    public float speed = 3f;
    private bool movingRight = true;

    [Header("Enemy Detection")]
    public float detectionDistance = 0.5f; // Ajusta según el tamaño de tu enemigo
    public float detectionHeight = 1f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento horizontal
        rb.linearVelocity = new Vector2(speed * (movingRight ? 1 : -1), rb.linearVelocity.y);

        // Dirección actual basada en hacia dónde mira
        float directionMultiplier = movingRight ? 1f : -1f;
        
        // Origen del rayo en la parte delantera de los pies del enemigo
        Vector2 detectionOrigin = (Vector2)transform.position + new Vector2(directionMultiplier * 0.5f, -0.5f);

        // Lanzamos los rayos
        RaycastHit2D isGrounded = Physics2D.Raycast(detectionOrigin, Vector2.down, detectionHeight, groundLayer);
        RaycastHit2D isWall = Physics2D.Raycast(detectionOrigin, new Vector2(directionMultiplier, 0f), detectionDistance, groundLayer);

        // Si no hay suelo adelante o choca con una pared, gira
        if (isGrounded.collider == null || isWall.collider != null)
        {
            flip();
        }
    }

    void flip()
    {
        movingRight = !movingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmosSelected()
    {
        float directionMultiplier = movingRight ? 1f : -1f;
        Vector2 detectionOrigin = (Vector2)transform.position + new Vector2(directionMultiplier * 0.5f, -0.5f);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(detectionOrigin, detectionOrigin + Vector2.down * detectionHeight);
        Gizmos.DrawLine(detectionOrigin, detectionOrigin + new Vector2(directionMultiplier * detectionDistance, 0f));
    }
}