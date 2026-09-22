using UnityEngine;

public class clicked : MonoBehaviour
{
        private void OnMouseDown()
    {
        Debug.Log("Drone clicked");
        GameManager.Instance.AddScore(10);
        Destroy(gameObject);
    }
}
