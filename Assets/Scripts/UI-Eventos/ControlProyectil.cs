using UnityEngine;
using System.Collections; // Necesario para Corrutinas

public class ControlProyectil : MonoBehaviour
{
    private SpriteRenderer miRenderer;
    private Animator miAnimator;

    void Start()
    {
        miRenderer = GetComponent<SpriteRenderer>();
        miAnimator = GetComponent<Animator>();
        miRenderer.enabled = false;
    }

    public void ActivarDisparo()
    {
        miRenderer.enabled = true;
        miAnimator.SetTrigger("Dispara");

        // Iniciamos la cuenta atrás para ocultar
        StartCoroutine(OcultarAutomaticamente(1.0f)); // 1 segundo, ajusta a tu gusto
    }

    IEnumerator OcultarAutomaticamente(float tiempo)
    {
        // Espera X segundos
        yield return new WaitForSeconds(tiempo);

        // Oculta el sprite
        miRenderer.enabled = false;

        // Opcional: Resetear animación si fuera necesario, 
        // aunque el trigger se consume automáticamente.
    }
}