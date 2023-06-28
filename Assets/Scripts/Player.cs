using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Rigidbody _rigidbody;
    [Range(0f, 10f)]
    [SerializeField] private float _speed = 5;
    [Range(0f, 5f)]
    [SerializeField] private float _cameraRotationSpeed = 5;

    private Vector2 _moveInput;

    void Update()
    {
        _moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 moveX = transform.right * _moveInput.x;
        Vector3 moveY = transform.forward * _moveInput.y;

        float mouseX = Input.GetAxis("Mouse X") * _cameraRotationSpeed;
        transform.Rotate(0f, mouseX, 0f);
        _rigidbody.velocity = (moveX + moveY) * _speed;

        CharacterController characterController = new();
    }
}