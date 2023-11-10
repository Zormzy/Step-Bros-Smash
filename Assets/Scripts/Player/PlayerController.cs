using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Scripts instances")]
    [SerializeField] private PlayerMoveManager _playerMoveManager;
    [SerializeField] private PlayerJumpManager _playerJumpManager;

    [Header("Controller values")]
    private string _controllerName;
    private Vector2 movementInput;
    private Vector2 _contextInput;

    private void Awake()
    {
        _controllerName = null;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (_controllerName == null)
            _controllerName = context.control.device.displayName;

        if (_controllerName == "Keyboard")
        {
            if (movementInput != context.ReadValue<Vector2>())
                movementInput = context.ReadValue<Vector2>();
        }
        else
        {
            _contextInput.Set(context.ReadValue<Vector2>().x, 0);

            if (movementInput != _contextInput)
                movementInput = _contextInput;
        }

        _playerMoveManager._playerMovementDirection = movementInput;
        _playerMoveManager._isMoving = context.performed;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (_controllerName == null)
            _controllerName = context.control.device.displayName;

        _playerJumpManager._playerDirection = movementInput;
        _playerJumpManager.PlayerJumpBuffer(context.ReadValueAsButton());
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (_controllerName == null)
            _controllerName = context.control.device.displayName;


    }
}
