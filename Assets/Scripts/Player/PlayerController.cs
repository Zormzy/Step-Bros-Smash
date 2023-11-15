using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Scripts instances")]
    [SerializeField] private PlayerMoveManager _playerMoveManager;
    [SerializeField] private PlayerJumpManager _playerJumpManager;
    [SerializeField] private PlayerAttackManager _playerAttackManager;
    [SerializeField] private PlayerParryManager _playerParryManager;
    [SerializeField] private PlayerAnimatorController _playerAnimatorController;
    [SerializeField] private PlayerInput _playerInput;

    [Header("Controller values")]
    private Vector2 movementInput;
    private Vector2 _contextInput;
    private Vector2 _attackMovementInput;
    private bool _downMovementBtn;
    private bool _isStuned;
    private float _stunTimer;
    private float _stunTimerCounter;

    private void Awake()
    {
        _downMovementBtn = false;
        _isStuned = false;
        movementInput = Vector2.zero;
        _attackMovementInput = movementInput;
        _stunTimer = 0.2f;
        _stunTimerCounter = 0f;
    }

    private void Update()
    {
        OnPlayerStun();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.ReadValue<Vector2>().x > 0.2f)
        {
            _contextInput.Set(1, 0);
            _playerAnimatorController.AnimatorOnMove(true);
        }
        else if (context.ReadValue<Vector2>().x < -0.2f)
        {
            _contextInput.Set(-1, 0);
            _playerAnimatorController.AnimatorOnMove(true);
        }
        else
        {
            _contextInput.Set(0,0);
            _playerAnimatorController.AnimatorOnMove(false);
        }

        if (movementInput != _contextInput)
            movementInput = _contextInput;

        if (context.ReadValue<Vector2>().y == -1)
            _downMovementBtn = true;
        else
            _downMovementBtn = false;

        if (movementInput != Vector2.zero)
            _attackMovementInput = movementInput;

        _playerMoveManager._playerMovementDirection = movementInput;
        _playerMoveManager._isMoving = context.performed;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        _playerJumpManager._playerDirection = movementInput;
        _playerJumpManager.PlayerJumpBuffer(context.ReadValueAsButton());
        
        if (context.canceled)
            _playerAnimatorController.AnimatorOnJump(false);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _playerAnimatorController.AnimatorOnAttack();

            if (_downMovementBtn)
                _playerAttackManager.PlayerAttackDown();
            else
                _playerAttackManager.PlayerAttackNormal(_attackMovementInput);
        }
    }

    public void OnParry(InputAction.CallbackContext context)
    {
        _playerParryManager.PlayerParry(context.ReadValueAsButton());
        _playerAnimatorController.AnimatorOnDefend(context.ReadValueAsButton());
    }

    private void OnPlayerStun()
    {
        if (_isStuned)
            _stunTimerCounter -= Time.deltaTime;
        else if (_stunTimerCounter != _stunTimer)
            _stunTimerCounter = _stunTimer;

        if (_isStuned && _stunTimerCounter <= 0)
        {
            _playerInput.ActivateInput();
            _isStuned = false;
        }
    }

    public void OnPlayerStunAction()
    {
        _playerInput.DeactivateInput();
        _isStuned = true;
    }
}
