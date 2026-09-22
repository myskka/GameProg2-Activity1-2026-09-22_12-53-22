using UnityEngine;

public class OrbitalTarget : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float moveSpeed = 1f;

    private float progress = 0f;
    private bool movingForward = true;

    private void OnEnable()
    {
        Debug.Log("Drone enable");
    }

    private void OnDisable()
    {
        Debug.Log("Drone DISABLED");
    }

    private void Update()
    {
        if (movingForward)
            progress += moveSpeed * Time.deltaTime;
        else
            progress -= moveSpeed * Time.deltaTime;

        progress = Mathf.Clamp01(progress);

        transform.position = Vector3.Lerp(
            pointA.position,
            pointB.position,
            progress
        );

        if (progress >= 1f)
            movingForward = false;

        if (progress <= 0f)
            movingForward = true;
    }

    private void OnMouseDown()
    {
        Debug.Log("Drone clicked");

        GameManager.Instance.AddScore(10);

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HazardZone"))
        {
            Debug.Log("hazard zone");

            GameManager.Instance.AddScore(-5);
        }
    }
}
