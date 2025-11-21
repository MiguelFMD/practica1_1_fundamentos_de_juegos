using UnityEngine;

public class ScrollTextura : MonoBehaviour
{
    public float velocidadScroll = 0.5f;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * velocidadScroll;
        rend.material.mainTextureOffset = new Vector2(offset, 0);
    }
}