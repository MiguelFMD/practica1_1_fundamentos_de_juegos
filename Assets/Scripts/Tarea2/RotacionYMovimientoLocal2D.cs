using UnityEngine;
using UnityEngine.InputSystem;

public class RotacionYMovimientoLocal2D : MonoBehaviour
{
    [SerializeField] private float velocidadNormal = 5f;
    [SerializeField] private float velocidadTurbo = 10f;

    // Velocidad de rotación (grados por segundo)
    [SerializeField] private float rotationSpeed = 180f;

    private Rigidbody2D rb2d;

    private float velocidadActual;

    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        velocidadActual = velocidadNormal;
    }

    public void CambiarModoTurbo(bool activo)
    {
        if (activo)
        {
            velocidadActual = velocidadTurbo;
            Debug.Log("Modo Turbo ACTIVADO: " + velocidadActual);
        }
        else
        {
            velocidadActual = velocidadNormal;
            Debug.Log("Modo Turbo DESACTIVADO: " + velocidadActual);
        }
    }

    void Update()
    {
        float left = (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) ? -1f : 0f;
        float right = (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) ? 1f : 0f;
        horizontalInput = left + right;

        float up = (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) ? 1f : 0f;
        float down = (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) ? -1f : 0f;
        verticalInput = up + down;
    }

    private void FixedUpdate()
    {
        if (rb2d != null)
        {
            float rotationDelta = horizontalInput * rotationSpeed * Time.fixedDeltaTime;

            
            float forwardDistance = verticalInput * velocidadActual * Time.fixedDeltaTime;

            // Rotación física
            float newRotation = rb2d.rotation - rotationDelta;
            rb2d.MoveRotation(newRotation);

            Vector2 forward = (Vector2)(Quaternion.Euler(0f, 0f, newRotation) * Vector2.up);

            Vector2 newPosition = rb2d.position + forward * forwardDistance;
            rb2d.MovePosition(newPosition);
        }
    }
}