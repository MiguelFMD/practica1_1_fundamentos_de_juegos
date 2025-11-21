using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject objetoPrefab;
    public int cantidadInicial = 10; 
    private List<GameObject> poolObjetos;

    void Start()
    {
        poolObjetos = new List<GameObject>();

        for (int i = 0; i < cantidadInicial; i++)
        {
            GameObject obj = Instantiate(objetoPrefab);
            obj.SetActive(false);
            poolObjetos.Add(obj);
        }
    }


    public GameObject GetPooledObject()
    {
        for (int i = 0; i < poolObjetos.Count; i++)
        {
            if (!poolObjetos[i].activeInHierarchy)
            {
                return poolObjetos[i];
            }
        }

        return null;
    }
}