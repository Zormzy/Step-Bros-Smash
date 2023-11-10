using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Scripts instances")]
    [SerializeField] private PlayerMoveManager _playerMoveManager;
    [SerializeField] private PlayerJumpManager _playerJumpManager;

    private Vector2 movementInput;

    public void OnMove(InputAction.CallbackContext context)
    {
        if (movementInput != context.ReadValue<Vector2>())
            movementInput = context.ReadValue<Vector2>();

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

    }
}
