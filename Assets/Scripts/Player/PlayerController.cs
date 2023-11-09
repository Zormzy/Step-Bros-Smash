using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Scripts instances")]
    [SerializeField] private PlayerMoveManager _playerMoveManager;
    [SerializeField] private PlayerJumpManager _playerJumpManager;

    public float speed = 5;
    private Vector2 movementInput;

    private void Awake()
    {

    }

    void Update()
    {
        transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (movementInput != context.ReadValue<Vector2>())
            movementInput = context.ReadValue<Vector2>();

        _playerMoveManager._playerMovementDirection = movementInput;
        _playerMoveManager.PlayerMovement();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        _playerJumpManager._playerDirection = movementInput;
        //_playerJumpManager.PlayerJump();
        _playerJumpManager.PlayerJumpBuffer(context.ReadValueAsButton()); ;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {

    }
}
