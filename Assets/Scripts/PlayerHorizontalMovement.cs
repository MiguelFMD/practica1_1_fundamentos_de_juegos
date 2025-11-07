using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHorizontalMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private SpriteRenderer spriteRenderer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = 0f;

        float left = Keyboard.current.aKey.isPressed ? -1f : 0f;
        float right = Keyboard.current.dKey.isPressed ? 1f : 0f;
        horizontalInput = left + right;
        Vector2 movement = new Vector2(horizontalInput, 0f);
        transform.Translate(movement * speed * Time.deltaTime);

        if (horizontalInput > 0f)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput < 0f)
        {
            spriteRenderer.flipX = false;
        }
    }
}
