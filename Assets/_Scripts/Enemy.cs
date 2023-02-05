using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody _rb;

    GameObject _playerGameObject;

    [SerializeField]
    LayerMask _whatIsGround;

    [SerializeField]
    float _speed = 5f;
    [SerializeField]
    float _distanceFromGround = 1f;

    bool _isGround;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _playerGameObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        ProcessEnemyDeath();
    }

    private void FollowPlayer()
    {
        Vector3 moveDirection = (_playerGameObject.transform.position - transform.position).normalized;
        _rb.AddForce(moveDirection * _speed);
    }

    private void ProcessEnemyDeath()
    {
        _isGround = Physics.Raycast(transform.position, Vector3.down, _distanceFromGround, _whatIsGround);
        
        if (!_isGround)
            _rb.velocity = new Vector3(transform.position.x, -10f, transform.position.z);

        if (transform.position.y <= -5)
            Destroy(this.gameObject);
    }

    private void FixedUpdate()
    {
        
    }
}
