using UnityEngine;

public class PlayerJumpManager : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody _rigidbody;
    private PlayerAnimatorController _playerAnimatorController;
    [SerializeField] private ParticleSystem _jumpParticule;
    public Vector2 _playerDirection;
    private Vector3 _playerJumpMovement;

    [Header("Booleen")]
    private bool _isGrounded;
    private bool _isJumpBtnPressed;
    private bool _canJump;
    private bool _canDoubleJump;
    public bool _isParrying;

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
        PlayerJumpInitialization();
    }

    private void Update()
    {
        PlayerJumpCoyoteTime();
        PlayerJump();
        PlayerDoubleJump();
        PlayerJumpVariable();
    }

    private void PlayerJump()
    {
        if (!_isParrying && _canJump && _coyoteTimeCounter > 0f && _jumpBufferTimeCounter > 0f)
        {
            if (_playerDirection.x != 0f)
                _playerJumpMovement.Set(_playerDirection.x, 1.5f, _playerDirection.y);
            else
                _playerJumpMovement.Set(_playerDirection.x, 1f, _playerDirection.y);

            _playerAnimatorController.AnimatorOnJump(true);
            _jumpParticule.Play();
            _playerAnimatorController._isGrounded = false;
            _rigidbody.AddForce(_playerJumpMovement * _jumpForce, ForceMode.Impulse);
            _coyoteTimeCounter = 0f;
            _jumpBufferTimeCounter = 0f;
            _canJump = false;
        }
    }

    private void PlayerDoubleJump()
    {
        if (!_isParrying && !_canJump && _canDoubleJump && _jumpBufferTimeCounter > 0f)
        {
            _playerJumpMovement.Set(_playerDirection.x, 1, _playerDirection.y);
            _playerAnimatorController.AnimatorOnDoubleJump();
            _rigidbody.AddForce(_playerJumpMovement * _jumpForce, ForceMode.Impulse);
            _coyoteTimeCounter = 0f;
            _jumpBufferTimeCounter = 0f;
            _canDoubleJump = false;
        }
    }

    private void PlayerJumpVariable()
    {
        if (!_isParrying && _isJumpBtnPressed && _rigidbody.velocity.y > 0f)
            _rigidbody.AddForce(_playerJumpMovement * _jumpBoost, ForceMode.Force);
    }

    public void PlayerJumpBuffer(bool pressed)
    {
        _isJumpBtnPressed = pressed;

        if (!_isParrying && pressed && _canJump || !_isParrying && pressed && _canDoubleJump)
            _jumpBufferTimeCounter = _jumpBufferTime;
        else
            _jumpBufferTimeCounter -= Time.deltaTime;
    }

    private void PlayerJumpCoyoteTime()
    {
        if (!_isParrying && _isGrounded)
            _coyoteTimeCounter = _coyoteTime;
        else
            _coyoteTimeCounter -= Time.deltaTime;
    }

    private void PlayerJumpInitialization()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerAnimatorController = GetComponent<PlayerAnimatorController>();
        _playerDirection.Set(0, 0);
        _playerJumpMovement.Set(0, 0, 0);
        _isGrounded = false;
        _canJump = false;
        _canDoubleJump = false;
        _isJumpBtnPressed = false;
        _isParrying = false;
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
            _playerAnimatorController._isGrounded = true;
            _isJumpBtnPressed = false;
            _canJump = true;
            _canDoubleJump = true;
        }
    }
}
