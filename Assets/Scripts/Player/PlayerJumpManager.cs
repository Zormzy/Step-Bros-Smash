using UnityEngine;

public class PlayerJumpManager : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public Vector2 _playerDirection;
    public Vector3 _playerJumpMovement;
    public bool _isGrounded;
    public bool _canJump;
    public bool _canDoubleJump;
    public float _jumpForce;
    public float _doubleJumpForce;

    [Header("Coyote time")]
    private float _coyoteTime;
    private float _coyoteTimeCounter;

    [Header("Jump buffer")]
    private float _jumpBufferTime;
    private float _jumpBufferTimeCounter;

    private void Awake()
    {
        PlayerJumpInitialisation();
    }

    private void Update()
    {
        PlayerJumpCoyoteTime();
        PlayerJump();
        PlayerDoubleJump();
    }

    public void PlayerJump()
    {
        if (_canJump && _coyoteTimeCounter > 0f && _jumpBufferTimeCounter > 0f)
        {
            Debug.Log("jump");
            _playerJumpMovement.Set(_playerDirection.x, 1, _playerDirection.y);
            _rigidbody.AddForce(_playerJumpMovement * _jumpForce, ForceMode.Impulse);
            _coyoteTimeCounter = 0f;
            _jumpBufferTimeCounter = 0f;
            _canJump = false;
        }
    }

    public void PlayerDoubleJump()
    {
        if (!_canJump && _canDoubleJump && _jumpBufferTimeCounter > 0f)
        {
            Debug.Log("double jump");
            _playerJumpMovement.Set(_playerDirection.x, 1, _playerDirection.y);
            _rigidbody.AddForce(_playerJumpMovement * _jumpForce, ForceMode.Impulse);
            _canDoubleJump = false;
        }
    }

    public void PlayerJumpBuffer(bool pressed)
    {
        if (pressed)
            _jumpBufferTimeCounter = _jumpBufferTime;
        else
            _jumpBufferTimeCounter -= Time.deltaTime;
    }

    private void PlayerJumpCoyoteTime()
    {
        if (_isGrounded)
            _coyoteTimeCounter = _coyoteTime;
        else
            _coyoteTimeCounter -= Time.deltaTime;
    }

    private void PlayerJumpInitialisation()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerDirection.Set(0, 0);
        _playerJumpMovement.Set(0, 0, 0);
        _isGrounded = false;
        _canJump = false;
        _canDoubleJump = false;
        _jumpForce = 5f;
        _doubleJumpForce = 2f;
        _coyoteTime = 0.5f;
        _coyoteTimeCounter = 0f;
        _jumpBufferTime = 0.2f;
        _jumpBufferTimeCounter = 0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            _isGrounded = true;
            _canJump = true;
            _canDoubleJump = true;
        }
    }
}
