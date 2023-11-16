using UnityEngine;

public class PlayerArmAttack : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private ParticleSystem _weaponHitParticule;

    [Header("Variables")]
    public Vector2 _attackDirection;
    private Vector3 _swordHitPosition;
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
            _swordHitPosition.Set(other.transform.position.x, other.transform.position.y + 0.6f, other.transform.position.z);
            _weaponHitParticule.transform.position = _swordHitPosition;
            _weaponHitParticule.Play();
            other.gameObject.GetComponent<PlayerController>().OnPlayerStunAction();
            _playerDamage = other.gameObject.GetComponent<PlayerInfos>().damagesPercent += 10;
            other.gameObject.GetComponent<Rigidbody>().AddForce(_attackDirection * (_playerDamage / 6), ForceMode.Impulse);
            _hasHit = true;
        }
    }
}
