using UnityEngine;

public class TurretTracker : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 5f;

    private void Update()
    {
        Vector3 directionToTarget =
            (target.position - transform.position).normalized;

        Quaternion targetRotation =
            Quaternion.LookRotation(directionToTarget);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );

        float alignment =
            Vector3.Dot(transform.forward, directionToTarget);

        if (alignment > 0.98f)
        {
            Debug.DrawLine(
                transform.position,
                target.position,
                Color.green
            );
        }
    }
}
