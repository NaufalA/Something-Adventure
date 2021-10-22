using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse Y") != 0)
        {
            RotateY(Input.GetAxis("Mouse Y"));
        }
    }

    private void RotateY(float y)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.y + y * 20f, 0));
    }
}