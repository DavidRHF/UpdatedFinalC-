using UnityEngine;

public static class SaveSystem
{
    public static void Save(int score, bool win)
    {
        PlayerPrefs.SetInt("LastScore", score);
        PlayerPrefs.SetInt("LastWin", win ? 1 : 0);

        int high = PlayerPrefs.GetInt("HighScore", 0);
        if (score > high)
            PlayerPrefs.SetInt("HighScore", score);
    }
}