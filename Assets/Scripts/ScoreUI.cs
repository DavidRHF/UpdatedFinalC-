using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        UpdateScore(0);
    }

    void Update()
    {
        scoreText.text = "Score: " + gm.score;
    }

    void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }
}