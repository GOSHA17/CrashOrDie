using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovable
{
    [SerializeField, Range(2,3f)] private float _moveSpeed = 0.5f;
    [SerializeField] private Joystick _joystickMove;

    private Vector2 _joystickInput => _joystickMove.Direction;
    private Vector3 _moveDirection;
    private Rigidbody _rigidbody;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateAnimatorState();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _moveDirection = new Vector3(_joystickInput.x, 0, _joystickInput.y) * _moveSpeed;
        _rigidbody.velocity = new Vector3(_moveDirection.x, _rigidbody.velocity.y, _moveDirection.z);
        RotateToDirection();
    }

    private void RotateToDirection()
    {
        if (_moveDirection.magnitude > 0 && _moveDirection != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(_moveDirection);
    }

    private void UpdateAnimatorState()
    {
        _animator.SetBool("isRunning", _moveDirection.magnitude > 0);
    }

    public bool IsMoving()
    {
        return _moveDirection.magnitude > 0;
    }
}
