using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CharacterController))]
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; } = null;

    [Header("Movement")]
    [SerializeField] private Rigidbody _rigidbody;
    [Range(0f, 10f)]
    [SerializeField] private float _speed = 5;
    [Range(0f, 5f)]
    [SerializeField] private float _cameraRotationSpeed = 5;
    [SerializeField] private CharacterController _characterController;

    [Header("Shoot")]
    [SerializeField] private SpriteRenderer _shootPoint;
    [SerializeField] private float _shootDistance;
    private Vector2 _moveInput;

    void Update()
    {
        _moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 moveX = transform.right * _moveInput.x;
        Vector3 moveY = transform.forward * _moveInput.y;

        float mouseX = Input.GetAxis("Mouse X") * _cameraRotationSpeed;
        transform.Rotate(0f, mouseX, 0f);

        _characterController.SimpleMove((moveX + moveY) * _speed);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ViewportPointToRay(new(.5f, .5f, 0));

            if (Physics.Raycast(ray, out RaycastHit hit, _shootDistance))
            {
                _shootPoint.transform.position = hit.point;
                if (hit.transform.TryGetComponent(out Hitable hitable))
                {
                    hitable.GetDamage(50);
                }
                print(hit.transform);
            }
        }


    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}