using UnityEngine;

public class ParallaxOffset : MonoBehaviour
{
    public Renderer[] capasFondo;
    public float velocidadGeneral = 0.5f;
    private string nombrePropiedad = "_MainTex";

    void Start()
    {
        if (capasFondo.Length > 0)
        {
            if (capasFondo[0].material.HasProperty("_BaseMap"))
            {
                nombrePropiedad = "_BaseMap";
            }
        }
    }

    void Update()
    {
        for (int i = 0; i < capasFondo.Length; i++)
        {
            float factor = i + 1.0f;

            float offset = (Time.time * velocidadGeneral) / factor;
            capasFondo[i].material.SetTextureOffset(nombrePropiedad, new Vector2(offset, 0));
        }
    }
}