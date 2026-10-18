using UnityEngine;

public class Coin : MonoBehaviour
{
    // Contador estático global de monedas recolectadas
    public static int totalMonedas = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detecta si el objeto que entra al trigger es el jugador
        if (collision.CompareTag("Player"))
        {
            totalMonedas++;
            Debug.Log("Monedas recogidas: " + totalMonedas);
            
            // Destruye la moneda de la escena
            Destroy(gameObject);
        }
    }
}