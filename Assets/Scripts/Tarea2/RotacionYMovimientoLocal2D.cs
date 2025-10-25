using UnityEngine;
using UnityEngine.InputSystem;

public class RotacionYMovimientoLocal2D : MonoBehaviour
{
    // Variables ajustables en el Inspector
    // Velocidad de traslación hacia adelante (unidades por segundo)
    [SerializeField] private float speed = 5f;
    // Velocidad de rotación (grados por segundo)
    [SerializeField] private float rotationSpeed = 180f;

    private Rigidbody2D rb2d;
    // Entradas leídas en Update y aplicadas en FixedUpdate
    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
        // Usar Time.fixedDeltaTime en física
        float rotationDelta = horizontalInput * rotationSpeed * Time.fixedDeltaTime;
        float forwardDistance = verticalInput * speed * Time.fixedDeltaTime;

        if (rb2d != null)
        {
            // Rotación física: MoveRotation espera un ángulo absoluto (grados)
            float newRotation = rb2d.rotation - rotationDelta;
            rb2d.MoveRotation(newRotation);

            // Avance en dirección "adelante" según la nueva rotación
            float rad = newRotation * Mathf.Deg2Rad;
            Vector2 forward = new Vector2(Mathf.Sin(rad), Mathf.Cos(rad)); // equivalente a transform.up
            Vector2 newPosition = rb2d.position + forward * forwardDistance;
            rb2d.MovePosition(newPosition);
        }
    }
}
