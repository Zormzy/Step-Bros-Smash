using UnityEngine;

public class PlayerArmAttack : MonoBehaviour
{
    [Header("Variables")]
    public Vector2 _attackDirection;
    private float _playerDamage;
    public bool _hasHit;

    private void Awake()
    {
        ArmAttackInitialization();
    }

    private void ArmAttackInitialization()
    {
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
            other.gameObject.GetComponent<Rigidbody>().AddForce(_attackDirection * (_playerDamage / 8), ForceMode.Impulse);
            _hasHit = true;
        }
    }
}
