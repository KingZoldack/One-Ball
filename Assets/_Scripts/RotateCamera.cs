using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    PlayerInputActions _playerInputAction;

    [SerializeField]
    float _speed = 2f;

    private void Awake()
    {
        _playerInputAction = new PlayerInputActions();
    }

    private void OnEnable()
    {
        _playerInputAction.Camera.Enable();
    }

    private void OnDisable()
    {
        _playerInputAction.Camera.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 playerInput = _playerInputAction.Camera.Movement.ReadValue<Vector2>();
        Vector3 rot = new Vector3(0, playerInput.x, 0);
        transform.Rotate(rot * _speed);
    }
}
