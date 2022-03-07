using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    public GameManager GameManager;
    public GameObject Camera;
    
    public float Speed = 10.0f;
    public float PowerJump = 10.0f;
    public float SpeedDrop = 3.0f;
    public float SpeedRotate = 5.0f;

    private CharacterController _characterController;
    private Vector3 _vectorMove;
    
    private bool _move;
    
    void Start()
    {
        _vectorMove = Vector3.zero;
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
            InputKey();
            Move();
    }

    void InputKey()
    {
        _vectorMove = transform.forward * Input.GetAxis("Vertical");
        _vectorMove += transform.right * Input.GetAxis("Horizontal");
        
        if (Input.GetKeyDown("space")
            && _characterController.isGrounded)
        {
            _vectorMove += transform.up * PowerJump;
        }
    }

    void Move()
    {
        RotationAxis();
        _characterController.Move((_vectorMove + -Vector3.up * SpeedDrop) * Speed * Time.deltaTime);
    }

    void RotationAxis()
    {
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * SpeedRotate, Space.World);
        Camera.transform.Rotate(Vector3.right, Input.GetAxis("Mouse Y") * -SpeedRotate);
    }
}
