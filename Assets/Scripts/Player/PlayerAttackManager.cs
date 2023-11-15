using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    [Header("Components")]
    //[SerializeField] private GameObject _arm;
    //[SerializeField] private Rigidbody _armRigidbody;
    //private Animator _animator;
    [SerializeField] private PlayerArmAttack _playerArmAttack;
    [SerializeField] private BoxCollider _weaponCollider;

    [Header("Attack variables")]
    //private Vector3 _armPosition;
    //private Vector3 _armTargetPosition;
    //private bool _isAttacking;
    //private bool _isArmBackPosition;
    //public float _attackForce;
    public bool _isParrying;

    //[SerializeField] private GameObject armPositionOnBody;

    private void Awake() 
    {
        PlayerAttackInitialization();
    }

    private void FixedUpdate()
    {
        //if (_isAttacking || !_isArmBackPosition)
        //    PlayerArmMovement();
    }

    public void PlayerAttackNormal(Vector2 _direction)
    {
        if (!_isParrying)
        {
            //_armPosition = _arm.transform.position;
            //_armTargetPosition.Set(_armPosition.x + _direction.x, _armPosition.y, _armPosition.z);
            //_isAttacking = true;
            //_isArmBackPosition = false;
            //_playerArmAttack._isAttacking = true;
            _playerArmAttack._attackDirection = _direction;
            _weaponCollider.enabled = true;
        }
    }

    public void PlayerAttackDown()
    {
        if (!_isParrying)
        {
            //_arm.transform.rotation = Quaternion.Euler(0, 0, -90);
            //_armPosition = _arm.transform.position;
            //_armTargetPosition.Set(_armPosition.x, _armPosition.y - 1, _armPosition.z);
            //_isAttacking = true;
            //_isArmBackPosition = false;
            //_playerArmAttack._isAttacking = true;
            _playerArmAttack._attackDirection = Vector2.down;
            _weaponCollider.enabled = true;
        }
    }

    //private void PlayerArmMovement()
    //{
    //    if (_isAttacking)
    //    {
    //        //_arm.transform.position = Vector3.MoveTowards(_armPosition, _armTargetPosition, _attackForce);
            
    //        _isAttacking = false;
    //    }
    //    else
    //    {
    //        //if (!_isArmBackPosition)
    //        //    _arm.transform.position = Vector3.MoveTowards(_arm.transform.position, armPositionOnBody.transform.position, _attackForce);

    //        //if (_arm.transform.rotation == Quaternion.Euler(0, 0, -90))
    //        //    _arm.transform.rotation = Quaternion.Euler(0, 0, 0);

    //        _isArmBackPosition = true;
    //        _weaponCollider.enabled = false;
    //        //_playerArmAttack._hasHit = false;
    //    }
    //}

    public void PlayerAttackEnd()
    {
        //_isAttacking = false;
        _weaponCollider.enabled = false;
        _playerArmAttack._hasHit = false;
    }

    private void PlayerAttackInitialization()
    {
        //_armRigidbody = _arm.GetComponent<Rigidbody>();
        //_playerArmAttack = _arm.GetComponent<PlayerArmAttack>();
        //_armCollider = _arm.GetComponentInChildren<BoxCollider>();
        //_animator = GetComponent<Animator>();
        //_attackForce = 2f;
        //_isAttacking = false;
        _isParrying = false;
        //_isArmBackPosition = true;
    }
}
