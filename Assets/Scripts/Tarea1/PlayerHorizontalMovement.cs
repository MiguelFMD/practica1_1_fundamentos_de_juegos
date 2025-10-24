using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHorizontalMovement : MonoBehaviour
{
    //Declarar la velocidad de tipo float
    [SerializeField] private float speed = 50f;
    //Declarar la variable que representa el SpriteRenderer
    private SpriteRenderer spriteRenderer;
    //Declarar la variable que representa el Rigidbody2D
    private Rigidbody2D rb2d;

    [SerializeField] private float distanceToActivate = 3f;
    private Animator animator;


    private Vector3 firstPosition;
    private float distanceTraveled;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Obtengo las referencias a los componentes
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        

        firstPosition = transform.position;
        distanceTraveled = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Obtengo el input horizontal (uso el Input System de Unity)
        float horizontalInput = 0f;
        float left = Keyboard.current.aKey.isPressed ? -1f : 0f;
        float right = Keyboard.current.dKey.isPressed ? 1f : 0f;
        horizontalInput = left + right;


        //En vez de con el transform, muevo el personaje con el Rigidbody2D
        //así detecta mejor las físicas
        Vector2 movement = new Vector2(horizontalInput, 0f);
        rb2d.MovePosition(rb2d.position + movement * speed * Time.deltaTime);

        //Altero el flip del sprite según la dirección
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
