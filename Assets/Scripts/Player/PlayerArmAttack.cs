using UnityEngine;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (_isAttacking)
        {
            if (collision.collider.gameObject.CompareTag("Player"))
            {
                Debug.Log("hit player");
            }
        }
    }
}
