using UnityEngine;
using Unity.Cinemachine; 
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{
    public CinemachineCamera camara;
    public float velocidadZoom = 10f;
    public float minSize = 2f;
    public float maxSize = 15f;

    void Update()
    {
        if (camara == null) return;

        // Leer el tamaño actual
        float currentSize = camara.Lens.OrthographicSize;

        if (Keyboard.current.leftCtrlKey.isPressed)
        {
            currentSize -= velocidadZoom * Time.deltaTime; // Acercar
        }
        if (Keyboard.current.leftAltKey.isPressed)
        {
            currentSize += velocidadZoom * Time.deltaTime; // Alejar
        }

        // Limitar y aplicar
        camara.Lens.OrthographicSize = Mathf.Clamp(currentSize, minSize, maxSize);
    }
}