using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PlayerArmAttack _playerArmAttack;
    [SerializeField] private BoxCollider _weaponCollider;
    private PlayerAudioManager _playerAudioManager;

    [Header("Variables")]
    public bool _isParrying;
    private Vector3 _weaponColliderLateralPosition;
    private Vector3 _weaponColliderLateralSize;
    private Vector3 _weaponColliderDownPosition;
    private Vector3 _weaponColliderDownSize;

    private void Awake()
    {
        PlayerAttackInitialization();
    }

    public void PlayerAttackNormal(Vector2 _direction)
    {
        if (!_isParrying)
        {
            _playerAudioManager.AudioSFXOnAttack();
            _weaponCollider.center = _weaponColliderLateralPosition;
            _weaponCollider.size = _weaponColliderLateralSize;
            _playerArmAttack._attackDirection = _direction;
            _weaponCollider.enabled = true;
        }
    }

    public void PlayerAttackSFX()
    {
        _playerAudioManager.AudioSFXOnAttack();
    }

    public void PlayerAttackDown()
    {
        if (!_isParrying)
        {
            _playerAudioManager.AudioSFXOnAttack();
            _weaponCollider.center = _weaponColliderDownPosition;
            _weaponCollider.size = _weaponColliderDownSize;
            _playerArmAttack._attackDirection = Vector2.down;
            _weaponCollider.enabled = true;
        }
    }

    public void PlayerAttackEnd()
    {
        _weaponCollider.enabled = false;
        _playerArmAttack._hasHit = false;
    }

    private void PlayerAttackInitialization()
    {
        _isParrying = false;
        _playerAudioManager = GetComponent<PlayerAudioManager>();
        _weaponColliderLateralPosition.Set(-5.596428e-15f, 0.2f, 1.606186f);
        _weaponColliderLateralSize.Set(1.2f, 1.45f, 1.092372f);
        _weaponColliderDownPosition.Set(2.863879e-15f, -0.8949271f, 0.7015275f);
        _weaponColliderDownSize.Set(1.2f, 1.059226f, 1.523259f);
    }
}
