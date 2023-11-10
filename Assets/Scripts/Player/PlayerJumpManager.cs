using UnityEngine;

public class PlayerJumpManager : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody _rigidbody;
    public Vector2 _playerDirection;
    public Vector3 _playerJumpMovement;

    [Header("Booleen")]
    public bool _isGrounded;
    private bool _isJumpBtnPressed;
    public bool _canJump;
    public bool _canDoubleJump;

    [Header("Jump force")]
    public float _jumpForce;
    public float _doubleJumpForce;

    [Header("Coyote time")]
    private float _coyoteTime;
    private float _coyoteTimeCounter;

    [Header("Jump buffer")]
    private float _jumpBufferTime;
    private float _jumpBufferTimeCounter;
    public float _jumpBoost;

    private void Awake()
    {
        PlayerJumpInitialisation();
    }

    private void Update()
    {
        PlayerJumpCoyoteTime();
        PlayerJump();
        PlayerDoubleJump();
        PlayerJumpVariable();
    }

    public void PlayerJump()
    {
        if (_canJump && _coyoteTimeCounter > 0f && _jumpBufferTimeCounter > 0f)
        {
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
            _playerJumpMovement.Set(_playerDirection.x, 1, _playerDirection.y);
            _rigidbody.AddForce(_playerJumpMovement * _jumpForce, ForceMode.Impulse);
            _jumpBufferTimeCounter = 0f;
            _canDoubleJump = false;
        }
    }

    private void PlayerJumpVariable()
    {
        if (_isJumpBtnPressed && _rigidbody.velocity.y > 0f)
            _rigidbody.AddForce(_playerJumpMovement * _jumpBoost, ForceMode.Force);
    }

    public void PlayerJumpBuffer(bool pressed)
    {
        _isJumpBtnPressed = pressed;

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
        _isJumpBtnPressed = false;
        _jumpForce = 20f;
        _doubleJumpForce = 5f;
        _jumpBoost = 1.5f;
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
            _isJumpBtnPressed = false;
            _canJump = true;
            _canDoubleJump = true;
        }
    }
}
