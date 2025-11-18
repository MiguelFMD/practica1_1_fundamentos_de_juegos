using UnityEngine;

public class ControlProyectil : MonoBehaviour
{
    private SpriteRenderer miRenderer;

    void Start()
    {
        miRenderer = GetComponent<SpriteRenderer>();
        // Ocultar al iniciar
        miRenderer.enabled = false;
    }

    // Función pública para llamar desde el botón
    public void ActivarDisparo()
    {
        miRenderer.enabled = true;
    }
}