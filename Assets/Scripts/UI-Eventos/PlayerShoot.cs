using UnityEngine;
using System;

public class PlayerShoot : MonoBehaviour
{
    
    public static event Action OnColisionEspecial;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo")) 
        {
            OnColisionEspecial?.Invoke();
            Debug.Log("¡Evento lanzado!");
        }
    }
}