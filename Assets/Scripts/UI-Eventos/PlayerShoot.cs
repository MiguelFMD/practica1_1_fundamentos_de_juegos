using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject prefabProyectil; 

    public void InstanciarDisparo()
    {
        Instantiate(prefabProyectil, transform.position, transform.rotation);
    }
}