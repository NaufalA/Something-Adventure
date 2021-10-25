using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Transform _modelTransform;

    public Joystick joystick;
    
    [SerializeField] private float speed = 20f;
    private Transform _mainCamera;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _modelTransform = GetComponentInChildren<SpriteRenderer>().transform;
        _mainCamera = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
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
        
        TurnToCamera();
    }

    private void Move(float x, float y)
    {
        var right = _mainCamera.right;
        var forward = _mainCamera.forward;

        right.y = 0f;
        forward.y = 0f;
        
        right.Normalize();
        forward.Normalize();

        var direction = forward * y + right * x;
        
        Vector3 target = transform.position + direction * speed * Time.deltaTime;
        _rigidbody.MovePosition(target);
    }

    private void TurnToCamera()
    {
        var cameraPos = _mainCamera.transform.position;

        cameraPos.y = 0f;
        
        _modelTransform.LookAt(cameraPos);
    }
}
