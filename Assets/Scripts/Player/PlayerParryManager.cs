using UnityEngine;

public class PlayerParryManager : MonoBehaviour
{
    [Header("Components")]
    private PlayerMoveManager _playerMoveManager;
    private PlayerJumpManager _playerJumpManager;
    private PlayerAttackManager _playerAttackManager;
    [SerializeField] private GameObject _parryBall;
    [SerializeField] private PlayerAnimatorController _playerAnimatorController;

    [Header("Parry variables")]
    private float _parryTime;
    private float _parryTimeCounter;
    private float _parryRecoveryTime;
    private float _parryRecoveryTimeCounter;

    [Header("Boolean")]
    private bool _canParry;
    private bool _isParryingBtnPressed;
    private bool _isParrying;

    private void Awake()
    {
        PlayerParryInitialization();
    }

    private void Update()
    {
        ParryTimer();
        PlayerParryAction();
    }

    public void PlayerParry(bool _pressed)
    {
        _isParryingBtnPressed = _pressed;
    }

    private void PlayerParryAction()
    {
        if (_isParryingBtnPressed && _canParry)
        {
            _parryBall.SetActive(true);
            _isParrying = true;
            _playerMoveManager._isParrying = true;
            _playerJumpManager._isParrying = true;
            _playerAttackManager._isParrying = true;
        }
        else
        {
            _parryBall.SetActive(false);
            _playerAnimatorController.AnimatorOnDefend(false);
            _isParrying = false;
            _playerMoveManager._isParrying = false;
            _playerJumpManager._isParrying = false;
            _playerAttackManager._isParrying = false;
        }
    }

    private void ParryTimer()
    {
        if (_isParrying)
        {
            _parryTimeCounter -= Time.deltaTime;
            _parryRecoveryTimeCounter = _parryRecoveryTime;
        }
        else if (_parryRecoveryTimeCounter > 0)
        {
            _parryTimeCounter = _parryTime;
            _parryRecoveryTimeCounter -= Time.deltaTime;
        }

        if (_parryTimeCounter <= 0 || _isParrying && !_isParryingBtnPressed)
            _canParry = false;
        else if (_parryRecoveryTimeCounter <= 0)
            _canParry = true;
    }

    private void PlayerParryInitialization()
    {
        _playerMoveManager = GetComponent<PlayerMoveManager>();
        _playerJumpManager = GetComponent<PlayerJumpManager>();
        _playerAttackManager = GetComponent<PlayerAttackManager>();
        _parryTime = 3f;
        _parryTimeCounter = 3f;
        _parryRecoveryTime = 3f;
        _parryRecoveryTimeCounter = 0f;
        _canParry = true;
        _isParryingBtnPressed = false;
        _isParrying = false;
    }
}
