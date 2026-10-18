using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rd;
    public float speed = 5f;
    public float jumpForce = 7f;
    private Animator animator;
    private bool isGrounded;
    private bool facingRight = true;

    // Referencia al script de salud para verificar si hay empujón activo
    private Health playerHealth;

    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        isGrounded = true; 
        animator = GetComponent<Animator>();
        
        // Obtenemos el componente Health del mismo personaje
        playerHealth = GetComponent<Health>();
    }

    void Update()
    {
        // Si el jugador está sufriendo un empujón (knockback), ignoramos las teclas para no anular la física del golpe
        if (playerHealth != null && playerHealth.isKnockedBack) return;

        float moveInput = Input.GetAxis("Horizontal");
        float speedAnim = Mathf.Abs(moveInput);
        rd.linearVelocity = new Vector2(moveInput * speed, rd.linearVelocity.y);
        animator.SetFloat("speed", speedAnim);

        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("jump", true);
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("jump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}