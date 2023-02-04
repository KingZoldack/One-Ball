using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody _rb;

    GameObject _playerGameObject;

    [SerializeField]
    float _speed = 5f;

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
        Vector3 moveDirection = (_playerGameObject.transform.position - transform.position).normalized;
        _rb.AddForce( moveDirection * _speed);
    }

    private void FixedUpdate()
    {
        
    }
}
