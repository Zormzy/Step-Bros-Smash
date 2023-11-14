using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    //TODO activer/ desactiver le collider du bras quand on attaque pour check la collision que a ce moment
    [Header("Components")]
    [SerializeField] private GameObject _arm;
    [SerializeField] private Rigidbody _armRigidbody;
    private PlayerArmAttack _playerArmAttack;

    [Header("Attack variables")]
    private Vector3 _armPosition;
    private Vector3 _armTargetPosition;
    private bool _isAttacking;
    private bool _isArmBackPosition;
    public float _attackForce;


    public BoxCollider armCollider;

    private void Awake() 
    {
        PlayerAttackInitialization();
    }

    private void FixedUpdate()
    {
        if (_isAttacking || !_isArmBackPosition)
            PlayerArmMovement();
    }

    public void PlayerAttack(Vector2 _direction)
    {
        _armPosition = _arm.transform.position;
        _armTargetPosition.Set(_armPosition.x + _direction.x, _armPosition.y, _armPosition.z);
        _isAttacking = true;
        _isArmBackPosition = false;
        _playerArmAttack._isAttacking = true;
        armCollider.enabled = true;
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

            _isArmBackPosition = true;
        }
    }

    private void PlayerAttackInitialization()
    {
        _armRigidbody = _arm.GetComponent<Rigidbody>();
        _playerArmAttack = _arm.GetComponent<PlayerArmAttack>();
        armCollider = _arm.GetComponentInChildren<BoxCollider>();
        _attackForce = 2f;
        _isAttacking = false;
        _isArmBackPosition = true;
    }
}
