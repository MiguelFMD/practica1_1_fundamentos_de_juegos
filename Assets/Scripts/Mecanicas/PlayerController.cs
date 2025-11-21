using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float fuerzaSalto = 5f;
    private Rigidbody2D rb2D;
    private bool isJumping = false;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame && !isJumping)
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
}