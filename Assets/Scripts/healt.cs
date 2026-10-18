using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("Salud y Vidas")]
    public int maxHealth = 3;
    public int currentHealth;

    [Header("Invulnerabilidad")]
    public float invincibilityDuration = 1f;
    private bool isInvincible = false;

    [Header("Empujón / Knockback")]
    public float knockbackForce = 5f;
    public float knockbackDuration = 0.2f;
    [HideInInspector] public bool isKnockedBack = false;

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si colisiona con un objeto con tag "enemy" y no es invulnerable
        if (collision.gameObject.CompareTag("enemy") && !isInvincible)
        {
            TakeDamage(1, collision.transform.position);
        }
    }

    // Método original para cuando choca con enemigos (con posición para el knockback)
    public void TakeDamage(int amount, Vector2 enemyPosition)
    {
        if (isInvincible) return;

        currentHealth -= amount;
        Debug.Log("Vida actual: " + currentHealth);

        if (animator != null)
        {
            animator.SetTrigger("hurt");
        }

        if (currentHealth <= 0)
        {
            Die();
            return;
        }

        StartCoroutine(ApplyKnockback(enemyPosition));
        StartCoroutine(InvincibilityRoutine());
    }

    // NUEVO MÉTODO: Sobrecarga simple para trampas (como los pinchos) que no requieren posición de enemigo
    public void TakeDamage(int amount)
    {
        if (isInvincible) return;

        currentHealth -= amount;
        Debug.Log("Vida actual (por trampa): " + currentHealth);

        if (animator != null)
        {
            animator.SetTrigger("hurt");
        }

        if (currentHealth <= 0)
        {
            Die();
            return;
        }

        StartCoroutine(InvincibilityRoutine());
    }

    private IEnumerator ApplyKnockback(Vector2 enemyPosition)
    {
        isKnockedBack = true;

        Vector2 direction = ((Vector2)transform.position - enemyPosition).normalized;
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(new Vector2(direction.x, 0.5f).normalized * knockbackForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(knockbackDuration);

        isKnockedBack = false;
    }

    private IEnumerator InvincibilityRoutine()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}