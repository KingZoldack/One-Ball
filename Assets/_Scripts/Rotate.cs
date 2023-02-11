using UnityEngine;

public class Rotate : MonoBehaviour
{
    private float _rotationSpeed = 10f;

    void Update() => transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
}
