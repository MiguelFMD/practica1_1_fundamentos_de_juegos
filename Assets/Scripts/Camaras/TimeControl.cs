using UnityEngine;

public class TimeControl : MonoBehaviour
{
    // Tarea 8: Slow Motion
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ZonaLenta")) // Crea un objeto con este Tag
        {
            Time.timeScale = 0.5f; // Mitad de velocidad
        }
        else if (other.CompareTag("ZonaRapida")) // Tarea 9
        {
            Time.timeScale = 2.0f; // Doble velocidad
        }
    }

    /*void OnTriggerExit2D(Collider2D other)
    {
        // Restablecer al salir
        if (other.CompareTag("ZonaLenta") || other.CompareTag("ZonaRapida"))
        {
            Time.timeScale = 1.0f;
        }
    }*/
}