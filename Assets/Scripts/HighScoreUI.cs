using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreUI : MonoBehaviour
{
    public TMPro.TMP_Text text;

    void Start()
    {
        text.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}