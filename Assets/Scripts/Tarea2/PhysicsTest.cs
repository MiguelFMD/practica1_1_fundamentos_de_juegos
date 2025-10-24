using UnityEngine;

public class PhysicalEventLogger : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col)
    {
        print($"{gameObject.name} OnCollisionEnter2D with {col.gameObject.name}");
    }

    void OnCollisionStay2D(Collision2D col)
    {
        print($"{gameObject.name} OnCollisionStay2D with {col.gameObject.name}");
    }

    void OnCollisionExit2D(Collision2D col)
    {
        print($"{gameObject.name} OnCollisionExit2D with {col.gameObject.name}");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        print($"{gameObject.name} OnTriggerEnter2D with {col.gameObject.name}");
    }

    void OnTriggerStay2D(Collider2D col)
    {
        print($"{gameObject.name} OnTriggerStay2D with {col.gameObject.name}");
    }

    void OnTriggerExit2D(Collider2D col)
    {
        print($"{gameObject.name} OnTriggerExit2D with {col.gameObject.name}");
    }
}
