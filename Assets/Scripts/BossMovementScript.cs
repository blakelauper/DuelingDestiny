using UnityEngine;

public class BossMovementScript : MonoBehaviour
{
    public Transform target; // Player target
    public float moveSpeed = 3f;

    private void Update()
    {
        if (target != null)
        {
            MoveTowardsTarget();
        }
    }

    void MoveTowardsTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Vector3 movement = direction * moveSpeed * Time.deltaTime;

        // Move the boss in all directions (2D)
        transform.Translate(movement);

    }
}
