using UnityEngine;

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
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0f);
        transform.Translate(movement * speed * Time.deltaTime);

        
        if (spriteRenderer != null)
        {
            if (horizontalInput > 0f)
            {
                spriteRenderer.flipX = false;
            }
            else if (horizontalInput < 0f)
            {
                spriteRenderer.flipX = true;
            }
        }
    }
}
