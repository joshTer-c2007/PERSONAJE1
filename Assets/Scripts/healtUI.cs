using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [Header("Referencias")]
    public Health playerHealth; // Arrastra aquí a tu personaje

    [Header("Imágenes de Vidas (Corazones)")]
    public Image[] hearts; // Arrastra aquí tus imágenes de corazones desde el Canvas

    void Update()
    {
        if (playerHealth == null) return;

        // Recorre todas las imágenes de los corazones
        for (int i = 0; i < hearts.Length; i++)
        {
            // Si el índice es menor a la vida actual, muestra el corazón; si no, lo oculta
            if (i < playerHealth.currentHealth)
            {
                hearts[i].enabled = true;  // Muestra el corazón
            }
            else
            {
                hearts[i].enabled = false; // Oculta el corazón
            }
        }
    }
}