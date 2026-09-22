using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int score = 0;
    public TMP_Text scoreText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        Score();
    }

    public void AddScore(int amount)
    {
        score += amount;

        Debug.Log("Score: " + score);

        Score();
    }

    private void Score()
    {
        scoreText.text = "Score: " + score;
    }
}
