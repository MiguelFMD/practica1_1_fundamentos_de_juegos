using UnityEngine;

public class ControlProyectil : MonoBehaviour
{
    private SpriteRenderer miRenderer;
    private Animator miAnimator; // Nueva referencia

    void Start()
    {
        miRenderer = GetComponent<SpriteRenderer>();
        miAnimator = GetComponent<Animator>(); // Obtenemos el animator

        miRenderer.enabled = false;
    }

    public void ActivarDisparo()
    {
        miRenderer.enabled = true;
        // Activamos el trigger del animator
        miAnimator.SetTrigger("Dispara");
    }
}