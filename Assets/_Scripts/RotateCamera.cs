using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateCamera : MonoBehaviour
{
    PlayerInputActions _playerInputAction;

    [SerializeField]
    float _speed = 5f;

    private void Awake()
    {
        _playerInputAction = new PlayerInputActions();
        _playerInputAction.Camera.Enable();
        //_playerInputAction.Camera.Movement.performed += RotateMainCamera;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(Vector3.up * 5 * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        Vector2 playerInput = _playerInputAction.Camera.Movement.ReadValue<Vector2>();
        transform.Rotate(new Vector3(0, playerInput.x, 0) * _speed);
    }

//    void RotateMainCamera(InputAction.CallbackContext context)
//    {
//        if (context.performed)
//        {
//            Vector2 playerInput = context.ReadValue<Vector2>();
//            transform.Rotate(new Vector3(0, playerInput.x, 0) * _speed);
//        }
//    }
}
