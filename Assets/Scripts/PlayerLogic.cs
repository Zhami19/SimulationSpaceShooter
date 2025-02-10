using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;

    [SerializeField]
    private float _moveSpeed;

    [SerializeField]
    private Vector2 _moveDirection;

    [SerializeField]
    private GameObject _projectilePrefab;

    public InputActionReference move;
    public InputActionReference fire;

    

    private void OnEnable()
    {
        fire.action.started += Fire;
    }

    void Start()
    {
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();

        positioncCheck();

    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(_moveDirection.x * _moveSpeed, _moveDirection.y * _moveSpeed);
    }

    private void positioncCheck()
    {
        if (transform.position.x <= -10)
        {
            transform.position = new Vector3(9.6f, transform.position.y, 0);
        }

        else if (transform.position.x >= 10)
        {
            transform.position = new Vector3(-9.6f, transform.position.y, 0);
        }

        if (transform.position.y >= 6)
        {
            transform.position = new Vector3(transform.position.x, -5.6f, 0);
        }

        else if (transform.position.y <= -6)
        {
            transform.position = new Vector3(transform.position.x, 5.6f, 0);
        }
    }

    private void Fire(InputAction.CallbackContext obj)
    {

        Instantiate(_projectilePrefab, transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);
    }
}
