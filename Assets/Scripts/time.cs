using System.Collections;
using UnityEngine;

public class TimedSpikeTrap : MonoBehaviour
{
    [Header("Ajustes del Tiempo")]
    public float waitTime = 2f;
    public float activeTime = 1f;

    [Header("Daño de la trampa")]
    public int damageAmount = 1;

    [Header("Estado Trampa")]
    public bool isDangerous = false;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(TrapRoutine());
    }

    IEnumerator TrapRoutine()
    {
        while (true)
        {
            isDangerous = false;
            yield return new WaitForSeconds(waitTime);

            if (animator != null)
            {
                animator.SetTrigger("active");
            }

            isDangerous = true;
            yield return new WaitForSeconds(activeTime);

            isDangerous = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // Comprobamos si lo que toca la trampa es el Jugador y si los pinchos están activos
        if (other.CompareTag("Player") && isDangerous)
        {
            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                Debug.Log("¡Trampa golpeó al jugador!");
            }
            else
            {
                Debug.LogWarning("El objeto con tag Player no tiene el script Health.");
            }
        }
    }
}