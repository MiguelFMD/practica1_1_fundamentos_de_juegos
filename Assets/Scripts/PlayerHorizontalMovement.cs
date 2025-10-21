using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHorizontalMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float distanceToActivate = 3f;
    private Animator animator;


    private Vector3 firstPosition;
    private float distanceTraveled;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        firstPosition = transform.position;
        distanceTraveled = 0f;
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

        float distanceThisFrame = Vector3.Distance(firstPosition, transform.position);
        distanceTraveled += distanceThisFrame;
        firstPosition = transform.position;

        bool changeAnim = distanceTraveled >= distanceToActivate;
        animator.SetBool("walkLeft", changeAnim);
    }
}
