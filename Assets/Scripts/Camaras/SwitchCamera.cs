using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchCamera : MonoBehaviour
{
    public CinemachineCamera camara1;
    public CinemachineCamera camara2;

    private void Start()
    {
        camara2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.digit1Key.IsPressed())
        {
            SwitchToCamera1();
        }
        else if (Keyboard.current.digit2Key.IsPressed())
        {
            SwitchToCamera2();
        }
    }

    public void SwitchToCamera1()
    {
        camara1.gameObject.SetActive(true);
        camara2.gameObject.SetActive(false);
    }

    public void SwitchToCamera2()
    {
        camara1.gameObject.SetActive(false);
        camara2.gameObject.SetActive(true);
    }
}
