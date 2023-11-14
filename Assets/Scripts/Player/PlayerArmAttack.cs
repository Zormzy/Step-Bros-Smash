using UnityEngine;

public class PlayerArmAttack : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody _armRigidbody;

    [Header("Variables")]
    public bool _isAttacking;
    public Vector2 _attackDirection;
    private float _playerDamage;
    public bool _hasHit;

    private void Awake()
    {
        ArmAttackInitialization();
    }

    private void Update()
    {
        if (_isAttacking)
            ArmAttackCheck();
    }

    private void ArmAttackCheck()
    {
        if (_armRigidbody.velocity.x <= 0)
            _isAttacking = false;
    }

    private void ArmAttackInitialization()
    {
        _armRigidbody = GetComponent<Rigidbody>();
        _isAttacking = false;
        _hasHit = false;
        _playerDamage = 0f;
        _attackDirection = Vector2.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Parry") && !_hasHit)
            _hasHit = true;

        if (other.CompareTag("Player") && !_hasHit)
        {
            other.gameObject.GetComponent<PlayerController>().OnPlayerStunAction();
            _playerDamage = other.gameObject.GetComponent<PlayerInfos>().damagesPercent += 10;
            other.gameObject.GetComponent<Rigidbody>().AddForce(_attackDirection * (_playerDamage / 10), ForceMode.Impulse);
            _hasHit = true;
        }
    }
}
