using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToHighScores()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("HighScoreScene");
    }
}