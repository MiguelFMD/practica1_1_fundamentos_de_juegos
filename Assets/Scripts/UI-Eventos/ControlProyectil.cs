using UnityEngine;
using System.Collections; // Necesario para Corrutinas

public class ControlProyectil : MonoBehaviour
{
    private SpriteRenderer miRenderer;
    private Animator miAnimator;

    void Start()
    {
        miAnimator = GetComponent<Animator>();
        ActivarDisparo();
        Destroy(gameObject, 2.0f);
    }

    public void ActivarDisparo()
    {
        miAnimator.SetTrigger("Dispara");
    }
}