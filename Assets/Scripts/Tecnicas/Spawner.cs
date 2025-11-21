using UnityEngine;

public class Spawner : MonoBehaviour
{
    public ObjectPool pool;

    void Start()
    {
        InvokeRepeating(nameof(Spawnear), 1f, 2f);
    }

    void Spawnear()
    {
        GameObject obj = pool.GetPooledObject();
        if (obj != null)
        {
            obj.transform.position = transform.position;
            obj.SetActive(true);
        }
    }
}