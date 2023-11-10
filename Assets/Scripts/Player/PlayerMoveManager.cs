using UnityEngine;

public class PlayerMoveManager : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody _rigidbody;
    public Vector2 _playerMovementDirection;
    private Vector3 _playerMovement;

    [Header("Boolean")]
    public bool _isMoving;
    public bool _isParrying;

    [Header("Movement speed")]
    public float _currentSpeed;
    public float _playerMovementSpeed;
    public float _playerMovementMaxSpeed;

    private void Awake()
    {
        PlayerMovementInitialization();
    }

    private void Update()
    {
        _currentSpeed = _rigidbody.velocity.magnitude;

        if (_isMoving && !_isParrying)
            PlayerMovement();
    }

    public void PlayerMovement()
    {
        _playerMovement.Set(_playerMovementDirection.x, 0, _playerMovementDirection.y);
        _rigidbody.AddForce(_playerMovement * _playerMovementSpeed, ForceMode.Force);
        
        if (_currentSpeed > _playerMovementMaxSpeed)
            _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, _playerMovementMaxSpeed);
    }

    private void PlayerMovementInitialization()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerMovementDirection.Set(0, 0);
        _playerMovement.Set(0, 0, 0);
        _currentSpeed = _rigidbody.velocity.magnitude;
        _playerMovementSpeed = 15f;
        _playerMovementMaxSpeed = 10f;
        _isMoving = false;
        _isParrying = false;
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}
