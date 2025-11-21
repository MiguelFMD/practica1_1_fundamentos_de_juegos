using UnityEngine;

public class ScrollInfinitoObjetos : MonoBehaviour
{
    public float velocidad = 2f;
    public float anchoSprite; 
    public float posInicialX; 

    void Start()
    {
        if (anchoSprite == 0)
            anchoSprite = GetComponent<SpriteRenderer>().bounds.size.x;

        
        posInicialX = -anchoSprite;
    }

    void Update()
    {
        transform.Translate(Vector3.left * velocidad * Time.deltaTime);

        
        if (transform.position.x < posInicialX)
        {
            Vector3 nuevaPos = transform.position;
            nuevaPos.x += 2 * anchoSprite;
            transform.position = nuevaPos;
        }
    }
}