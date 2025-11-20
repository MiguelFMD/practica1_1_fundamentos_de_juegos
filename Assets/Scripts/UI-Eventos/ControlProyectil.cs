using UnityEngine;

public class ControlProyectil : MonoBehaviour
{
    private SpriteRenderer miRenderer;

    private void OnEnable()
    {
        PlayerShoot.OnColisionEspecial += DispararPorEvento;
    }

    private void OnDisable()
    {
        PlayerShoot.OnColisionEspecial -= DispararPorEvento;
    }

    void Start()
    {
        miRenderer = GetComponent<SpriteRenderer>();
        miRenderer.enabled = false;
    }

    void DispararPorEvento()
    {
        miRenderer.enabled = true;
    }
}