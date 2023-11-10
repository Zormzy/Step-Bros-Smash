using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject _arm;
    [SerializeField] private Rigidbody _armRigidbody;
    private PlayerArmAttack _playerArmAttack;
    private bool _isAttacking;

    [Header("Attack variables")]
    public float attackForce;

    private void Awake()
    {
        PlayerAttackInitialization();
    }

    public void PlayerAttack(Vector2 _direction)
    {
        Debug.Log("attack");
        _armRigidbody.AddForce(_direction * attackForce, ForceMode.Impulse);
        _playerArmAttack._isAttacking = true;
    }

    private void PlayerAttackInitialization()
    {
        _armRigidbody = _arm.GetComponent<Rigidbody>();
        _playerArmAttack = _arm.GetComponent<PlayerArmAttack>();
        attackForce = 10f;
        _isAttacking = false;
    }
}
