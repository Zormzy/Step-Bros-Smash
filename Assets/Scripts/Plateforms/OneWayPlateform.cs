using UnityEngine;

public class OneWayPlateform : MonoBehaviour
{
    [SerializeField] private Vector3 entryDirection = Vector3.up;
    [SerializeField] private float penetrationDepthNeeded = 0.2f;

    private BoxCollider boxCollider;
    private BoxCollider checkCollision;

    public Vector3 PassthroughDirection => entryDirection.normalized;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();

        checkCollision = gameObject.AddComponent<BoxCollider>();
        checkCollision.size = new Vector3(boxCollider.size.x * 1.25f, boxCollider.size.y * 1.25f, boxCollider.size.z * 1.25f);
        checkCollision.center = boxCollider.center;
        checkCollision.isTrigger = true;
    }

    private void OnTriggerStay(Collider other)
    {
        TryIgnoreCollision(other);
    }

    public void TryIgnoreCollision(Collider other)
    {
        if (Physics.ComputePenetration(checkCollision, checkCollision.bounds.center, transform.rotation, other, other.bounds.center, other.transform.rotation, out Vector3 collisionDirection, out float penetrationDepth))
        {
            float dot = Vector3.Dot(PassthroughDirection, collisionDirection);

            if (dot < 0)
            {
                if (penetrationDepth < penetrationDepthNeeded)
                {
                    Physics.IgnoreCollision(boxCollider, other, false);
                }
            }
            else
            {
                Physics.IgnoreCollision(boxCollider, other, true);
            }
        }
    }
}