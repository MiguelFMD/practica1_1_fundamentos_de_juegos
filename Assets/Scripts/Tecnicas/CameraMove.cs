using UnityEngine;

public class CameraMove : MonoBehaviour
{
    void Update() 
    { 
        transform.Translate(Vector3.right * 5f * Time.deltaTime); 
    }
}
