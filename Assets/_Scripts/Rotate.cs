using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float _rotationSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
    }
}
