using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject _arm;
    [SerializeField] private Rigidbody _armRigidbody;

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
    }

    private void PlayerAttackInitialization()
    {
        _armRigidbody = _arm.GetComponent<Rigidbody>();
        attackForce = 10f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("hit player");
        }
    }
}
