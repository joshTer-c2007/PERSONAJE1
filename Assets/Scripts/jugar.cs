using UnityEngine;
using UnityEngine.SceneManagement;

public class jugar : MonoBehaviour
{
    // Método para el botón EMPEZAR
    public void EmpezarJuego()
    {
        // Carga la siguiente escena en la lista de Build Settings
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Método para el botón SALIDA
    public void SalirJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit(); // Cierra la aplicación (funciona cuando exportes el juego)
    }
}