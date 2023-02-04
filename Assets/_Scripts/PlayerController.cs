using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    PlayerInputActions _playerInputActions;
    Rigidbody _rb;

    [SerializeField]
    GameObject _focusPoint;

    [SerializeField]
    Image _timerFill;

    [SerializeField]
    float _speed = 5f;

    [SerializeField]
    float _powerupTimer = 7f;
    float _timeLeft;
    bool _hasPowerup = false;

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

    private void Update()
    {
        if (_timeLeft > 0 && _hasPowerup)
        {
            _timeLeft -= Time.deltaTime;
            _timerFill.fillAmount = _timeLeft / _powerupTimer;

            if (_timeLeft <= 0)
                _hasPowerup = false;
        }
    }

    private void FixedUpdate()
    {
        Vector2 actions = _playerInputActions.Player.Movement.ReadValue<Vector2>();
        _rb.AddForce(_focusPoint.transform.forward * actions.y *_speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Powerup>() != null)
        {
            _hasPowerup = true;
            Destroy(other.gameObject);
            _timeLeft = 7f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() && _hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 repelDirection = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(repelDirection * 10, ForceMode.Impulse);
        }
    }
}
