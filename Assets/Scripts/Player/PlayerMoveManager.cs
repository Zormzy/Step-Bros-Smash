using UnityEngine;

public class PlayerMoveManager : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public Vector2 _playerMovementDirection;
    public Vector3 _playerMovement;
    public float _playerMovementSpeed;
    public bool _isMoving;

    private void Awake()
    {
        PlayerMovementInitialisation();
    }

    private void Update()
    {
        if (_isMoving)
            PlayerMovement();
    }

    public void PlayerMovement()
    {
        _playerMovement.Set(_playerMovementDirection.x, 0, _playerMovementDirection.y);
        _rigidbody.AddForce(_playerMovement * _playerMovementSpeed, ForceMode.Force);
    }

    private void PlayerMovementInitialisation()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerMovementDirection.Set(0, 0);
        _playerMovement.Set(0, 0, 0);
        _playerMovementSpeed = 5f;
        _isMoving = false;
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}
