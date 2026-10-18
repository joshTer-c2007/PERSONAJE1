using UnityEngine;
using TMPro; // Usa "using UnityEngine.UI;" si usas texto normal de Unity

public class CoinUI : MonoBehaviour
{
    private TextMeshProUGUI textoMonedas;

    void Start()
    {
        // Obtiene el componente de texto del objeto actual
        textoMonedas = GetComponent<TextMeshProUGUI>();
        // Reinicia el contador al iniciar la escena
        Coin.totalMonedas = 0;
    }

    void Update()
    {
        // Actualiza el texto en pantalla en tiempo real
        textoMonedas.text = "Monedas: " + Coin.totalMonedas;
    }
}