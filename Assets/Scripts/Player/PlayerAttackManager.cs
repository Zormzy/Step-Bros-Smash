using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject _arm;
    [SerializeField] private Rigidbody _armRigidbody;
    private PlayerArmAttack _playerArmAttack;
    private BoxCollider _armCollider;

    [Header("Attack variables")]
    private Vector3 _armPosition;
    private Vector3 _armTargetPosition;
    private bool _isAttacking;
    private bool _isArmBackPosition;
    public float _attackForce;

    private void Awake() 
    {
        PlayerAttackInitialization();
    }

    private void FixedUpdate()
    {
        if (_isAttacking || !_isArmBackPosition)
            PlayerArmMovement();
    }

    public void PlayerAttackNormal(Vector2 _direction)
    {
        _armPosition = _arm.transform.position;
        _armTargetPosition.Set(_armPosition.x + _direction.x, _armPosition.y, _armPosition.z);
        _isAttacking = true;
        _isArmBackPosition = false;
        _playerArmAttack._isAttacking = true;
        _playerArmAttack._attackDirection = _direction;
        _armCollider.enabled = true;
    }

    public void PlayerAttackDown()
    {
        _arm.transform.rotation = Quaternion.Euler(0,0,-90);
        _armPosition = _arm.transform.position;
        _armTargetPosition.Set(_armPosition.x, _armPosition.y - 1, _armPosition.z);
        _isAttacking = true;
        _isArmBackPosition = false;
        _playerArmAttack._isAttacking = true;
        _playerArmAttack._attackDirection = Vector2.down;
        _armCollider.enabled = true;
    }

    private void PlayerArmMovement()
    {
        if (_isAttacking)
        {
            _arm.transform.position = Vector3.MoveTowards(_armPosition, _armTargetPosition, _attackForce);
            _isAttacking = false;
        }
        else
        {
            if (!_isArmBackPosition)
                _arm.transform.position = Vector3.MoveTowards(_arm.transform.position, _armPosition, _attackForce);

            if (_arm.transform.rotation == Quaternion.Euler(0, 0, -90))
                _arm.transform.rotation = Quaternion.Euler(0, 0, 0);

            _isArmBackPosition = true;
            _armCollider.enabled = false;
            _playerArmAttack._hasHit = false;
        }
    }

    private void PlayerAttackInitialization()
    {
        _armRigidbody = _arm.GetComponent<Rigidbody>();
        _playerArmAttack = _arm.GetComponent<PlayerArmAttack>();
        _armCollider = _arm.GetComponentInChildren<BoxCollider>();
        _attackForce = 2f;
        _isAttacking = false;
        _isArmBackPosition = true;
    }
}
