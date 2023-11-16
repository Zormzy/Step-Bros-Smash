using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private PlayerArmAttack _playerArmAttack;
    [SerializeField] private BoxCollider _weaponCollider;

    public bool _isParrying;

    private void Awake() 
    {
        PlayerAttackInitialization();
    }

    public void PlayerAttackNormal(Vector2 _direction)
    {
        if (!_isParrying)
        {
            _playerArmAttack._attackDirection = _direction;
            _weaponCollider.enabled = true;
        }
    }

    public void PlayerAttackDown()
    {
        if (!_isParrying)
        {
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
    }
}
