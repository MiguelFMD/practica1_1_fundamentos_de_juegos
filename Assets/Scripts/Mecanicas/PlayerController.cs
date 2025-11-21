using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float fuerzaSalto = 5f;
    private Rigidbody2D rb2D;
    [SerializeField]private bool isJumping = false;

    public int puntuacion = 0;
    public int puntosParaMejora = 30;
    public TMP_Text textoPuntuacion;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float inputX = 0;

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            inputX = -1;
        }
        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            inputX = 1;
        }
        rb2D.linearVelocity = new Vector2(inputX * velocidadMovimiento, rb2D.linearVelocity.y);

        if (inputX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (inputX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame && !isJumping)
        {
            rb2D.AddForce(transform.up * fuerzaSalto, ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isJumping = false;
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, 0);
        }

        if (collision.gameObject.CompareTag("PlataformaMovil"))
        {
            transform.SetParent(collision.transform);

            isJumping = false;
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("PlatInv"))
        {
            SpriteRenderer sr = collision.gameObject.GetComponent<SpriteRenderer>();
            if (sr != null) sr.enabled = true;

            
            isJumping = false;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlataformaMovil"))
        {
            transform.SetParent(null);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coleccionable"))
        {
            puntuacion += 10;

            if (textoPuntuacion != null)
                textoPuntuacion.text = "Puntos: " + puntuacion;

            if (puntuacion >= puntosParaMejora)
            {
                fuerzaSalto += 2f; 
                
                puntosParaMejora += 30;
            }

            
            Destroy(other.gameObject);
        }
    }
}