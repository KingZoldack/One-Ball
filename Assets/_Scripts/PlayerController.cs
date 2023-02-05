using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerController : MonoBehaviour
{
    PlayerInputActions _playerInputActions;
    Rigidbody _rb;
    int _currentScene;

    [SerializeField]
    GameObject _focusPoint;

    [SerializeField]
    Image _timerFill;

    [SerializeField]
    float _speed = 5f;
    [SerializeField]
    float _distanceFromGround = 1.5f;

    [SerializeField]
    float _powerupTimer = 7f;
    float _timeLeft;
    bool _hasPowerup = false;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _currentScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(_currentScene);
    }

    private void OnEnable() => _playerInputActions.Player.Movement.Enable();

    private void OnDisable() => _playerInputActions.Player.Movement.Disable();

    private void Update()
    {
        HandlePowerupCountdown();
        ProcessPlayerDeath();
    }

    private void HandlePowerupCountdown()
    {
        if (_timeLeft > 0 && _hasPowerup)
        {
            _timeLeft -= Time.deltaTime; //count down every second
            _timerFill.fillAmount = _timeLeft / _powerupTimer; //reduce fill amount every second

            if (_timeLeft <= 0)
                _hasPowerup = false; //turn off power up state
        }
    }
    private void ProcessPlayerDeath()
    {
        

        if (!Physics.Raycast(transform.position, Vector3.down, _distanceFromGround))
            _rb.velocity = new Vector3(transform.position.x, -10f, transform.position.z);

        if (transform.position.y <= -5)
            SceneManager.LoadScene(_currentScene);
    }

    private void FixedUpdate()
    {
        Vector2 playerInput = _playerInputActions.Player.Movement.ReadValue<Vector2>();
        _rb.AddForce(_focusPoint.transform.forward * playerInput.y * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        //turn on powerup state
        if (other.GetComponent<Powerup>() != null)
        {
            _hasPowerup = true;
            Destroy(other.gameObject);
            _timeLeft = _powerupTimer; //sets the timer for powerup duration
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //defines powerup ability
        if (collision.gameObject.GetComponent<Enemy>() && _hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 repelDirection = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(repelDirection * 10, ForceMode.Impulse);
        }
    }
}
