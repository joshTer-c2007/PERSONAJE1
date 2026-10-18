using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Salud del Enemigo")]
    public int MaxHealth = 3;
    public int currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Aquí puedes agregar efectos, partículas o sumar puntos si lo deseas
        Destroy(gameObject);
    }
}