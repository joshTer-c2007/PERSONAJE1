using UnityEngine;

public class CameraFlow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 5f;
    public Vector3 offset = new Vector3(0f, 1f, -10f);

    void LateUpdate()
    {
        if (player != null)
        {
            // Forzamos a que el eje Z sea siempre -10 para que no distorsione el fondo
            Vector3 desiredPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, -10f);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}