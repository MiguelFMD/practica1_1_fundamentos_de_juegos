using UnityEngine;
using Unity.Cinemachine; // Namespace obligatorio para Cinemachine 3

public class CambioCamaraZona : MonoBehaviour
{
    [Header("Configuración de Cámaras")]
    public CinemachineCamera camaraLibre;      // La cámara exterior
    public CinemachineCamera camaraConfinada;  // La cámara interior (con confiner)

    [Header("Prioridades")]
    // Definimos qué valor es "Alta prioridad" y cuál "Baja"
    private int prioridadAlta = 20;
    private int prioridadBaja = 10;

    private void Start()
    {
        // Nos aseguramos de empezar con la cámara libre activa
        camaraLibre.Priority = prioridadAlta;
        camaraConfinada.Priority = prioridadBaja;
    }

    // Se ejecuta cuando el Jugador ENTRA en el Trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificamos si es el jugador (asegúrate de que tu jugador tenga el Tag "Player")
        if (other.CompareTag("Player"))
        {
            // Activamos la confinada subiendo su prioridad
            camaraConfinada.Priority = prioridadAlta;
            camaraLibre.Priority = prioridadBaja;

            Debug.Log("Entrando en zona confinada - Cambio a Cámara Interior");
        }
    }

    // Se ejecuta cuando el Jugador SALE del Trigger
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Activamos la libre subiendo su prioridad
            camaraLibre.Priority = prioridadAlta;
            camaraConfinada.Priority = prioridadBaja;

            Debug.Log("Saliendo de zona confinada - Cambio a Cámara Exterior");
        }
    }
}