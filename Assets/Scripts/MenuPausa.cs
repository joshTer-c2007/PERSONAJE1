using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [Header("Panel de Pausa")]
    public GameObject panelPausa; // Arrastra aquí tu PanelMenu desde la Jerarquía

    private bool juegoPausado = false;

    void Update()
    {
        // Opcional: Puedes presionar Escape para pausar/reanudar el juego si lo deseas
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }

    // Método para el botón REANUDAR
    public void Reanudar()
    {
        if (panelPausa != null)
        {
            panelPausa.SetActive(false); // Oculta el menú de pausa
        }

        Time.timeScale = 1f; // Restaura el tiempo del juego a la normalidad
        juegoPausado = false;
    }

    void Pausar()
    {
        if (panelPausa != null)
        {
            panelPausa.SetActive(true); // Muestra el menú de pausa
        }

        Time.timeScale = 0f; // Congela el tiempo del juego
        juegoPausado = true;
    }

    // Método para el botón REINICIAR
    public void Reiniciar()
    {
        Time.timeScale = 1f; // ¡Esencial! Restaura el tiempo antes de recargar la escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Recarga el nivel actual
    }
}