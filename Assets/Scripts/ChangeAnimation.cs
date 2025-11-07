using UnityEngine;

public class ChangeAnimation : MonoBehaviour
{
    private Vector3 firstPosition;
    private Animator animator;
    private float distanceTraveled;
    [SerializeField] private float distanceToActivate = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firstPosition = transform.position;
        animator = GetComponent<Animator>();
        distanceTraveled = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceThisFrame = Vector3.Distance(firstPosition, transform.position);
        distanceTraveled += distanceThisFrame;
        firstPosition = transform.position;

        bool changeAnim = distanceTraveled >= distanceToActivate;
        animator.SetBool("walkLeft", changeAnim);
    }
}
