using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInputActions _playerInputActions;
    Rigidbody _rb;

    [SerializeField]
    GameObject _focusPoint;

    [SerializeField]
    float _speed = 5f;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        _playerInputActions.Player.Movement.Enable();
    }

    private void OnDisable()
    {
        _playerInputActions.Player.Movement.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 actions = _playerInputActions.Player.Movement.ReadValue<Vector2>();
        _rb.AddForce(_focusPoint.transform.forward * actions.y *_speed);

    }
}
