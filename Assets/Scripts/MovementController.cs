using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public Joystick joystick;
    
    [SerializeField] private float speed = 20f;
    private Transform mainCamera;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        mainCamera = Camera.main.transform;
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0f ||Input.GetAxis("Vertical") != 0f)
        {
            Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
        if (joystick.Horizontal != 0f || joystick.Vertical != 0f)
        {
            Move(joystick.Horizontal, joystick.Vertical);
        }
    }

    private void Move(float x, float y)
    {
        var right = mainCamera.right;
        var forward = mainCamera.forward;

        right.y = 0f;
        forward.y = 0f;
        
        right.Normalize();
        forward.Normalize();

        var direction = forward * y + right * x;
        
        Vector3 target = transform.position + direction * speed * Time.deltaTime;
        _rigidbody.MovePosition(target);
    }
}
