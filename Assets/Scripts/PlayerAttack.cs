using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;

    [Header("Configuración de Ataque")]
    public Transform attackPoint;      // Punto desde donde se calcula el golpe
    public float attackRange = 0.5f;   // Radio del círculo de ataque
    public LayerMask enemyLayer;       // Capa para identificar al enemigo
    public int attackDamage = 1;       // Daño que hace el ataque

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Detecta si presionas la tecla Z o haces clic izquierdo para atacar
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetMouseButtonDown(0))
        {
            Atacar();
        }
    }

    void Atacar()
    {
        // 1. Activa la animación de ataque en el Animator
        animator.SetTrigger("atck");

        // 2. Detecta enemigos en un círculo alrededor del attackPoint
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        // 3. Les aplica daño a los enemigos encontrados
        foreach (Collider2D enemy in enemiesHit)
        {
            // Llama al script de vida del enemigo que hicimos antes (EnemyHealth)
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            Debug.Log("¡Golpeaste a un enemigo!");
        }
    }

    // Esto dibuja una esfera roja en Unity para que veas el rango de ataque en el modo Scene
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}