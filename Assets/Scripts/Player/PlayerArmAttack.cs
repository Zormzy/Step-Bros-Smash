using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerArmAttack : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody _armRigidbody;

    [Header("Boolean")]
    public bool _isAttacking;

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
    }

    [SerializeField] Transform respawnPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerInfos>().damagesPercent += 10;
            Debug.Log("PlayerTouché: " + other.gameObject.GetComponent<PlayerInfos>().playerID + "   " + other.gameObject.GetComponent<PlayerInfos>().damagesPercent + "%");
        }
    }
}
