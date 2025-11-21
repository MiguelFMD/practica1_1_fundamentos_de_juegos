using UnityEngine;

public class ParallaxPosicional : MonoBehaviour
{
    [System.Serializable]
    public class CapaParallax
    {
        public Transform objetoA;
        public Transform objetoB; 
        public float velocidad = 1f; 
    }

    public CapaParallax[] capas; 
    public float anchoSprite;    

    void Update()
    {
        foreach (var capa in capas)
        {
            MoverYReciclar(capa.objetoA, capa.velocidad);
            MoverYReciclar(capa.objetoB, capa.velocidad);
        }
    }

    void MoverYReciclar(Transform obj, float velocidadCapa)
    {
        obj.Translate(Vector3.left * velocidadCapa * Time.deltaTime);

        if (obj.position.x < -anchoSprite)
        {
            Vector3 nuevaPos = obj.position;
            nuevaPos.x += 2 * anchoSprite;
            obj.position = nuevaPos;
        }
    }
}