using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Scripts instances")]
    [SerializeField] private PlayerMoveManager _playerMoveManager;
    [SerializeField] private PlayerJumpManager _playerJumpManager;
    [SerializeField] private PlayerAttackManager _playerAttackManager;
    [SerializeField] private PlayerParryManager _playerParryManager;

    [Header("Controller values")]
    private Vector2 movementInput;
    private Vector2 _contextInput;
    private Vector2 _attackMovementInput;
    private bool _downMovementBtn;

    private void Awake()
    {
        _downMovementBtn = false;
        movementInput = Vector2.zero;
        _attackMovementInput = movementInput;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _contextInput.Set(context.ReadValue<Vector2>().x, 0);

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
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_downMovementBtn)
                _playerAttackManager.PlayerAttackDown();
            else
                _playerAttackManager.PlayerAttackNormal(_attackMovementInput);
        }
    }

    public void OnParry(InputAction.CallbackContext context)
    {
        _playerParryManager.PlayerParry(context.ReadValueAsButton());
    }
}
