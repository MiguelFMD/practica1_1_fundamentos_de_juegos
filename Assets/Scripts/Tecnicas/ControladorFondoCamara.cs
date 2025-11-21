using UnityEngine;

public class ControladorFondoCamara : MonoBehaviour
{
    public Transform camara;
    public Transform[] fondos; 

    private float anchoSprite;
    private float anchoCamara;

    void Start()
    {
        if (fondos.Length == 0) return;

        SpriteRenderer sr = fondos[0].GetComponent<SpriteRenderer>();
        anchoSprite = sr.bounds.size.x;

        float altoCamara = Camera.main.orthographicSize;
        anchoCamara = altoCamara * Camera.main.aspect;
    }

    void Update()
    {
        foreach (var fondo in fondos)
        {
            if (fondo.position.x + (anchoSprite / 2) < camara.position.x - anchoCamara)
            {
                ReubicarFondo(fondo);
            }
        }
    }

    void ReubicarFondo(Transform fondoMover)
    {
        float xMasDerecha = -Mathf.Infinity;

        foreach (var f in fondos)
        {
            if (f.position.x > xMasDerecha)
            {
                xMasDerecha = f.position.x;
            }
        }

        Vector3 nuevaPos = fondoMover.position;
        nuevaPos.x = xMasDerecha + anchoSprite;
        fondoMover.position = nuevaPos;
    }
}