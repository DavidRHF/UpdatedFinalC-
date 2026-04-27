using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject panel;

    bool paused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused) Resume();
            else Pause();
        }
    }

    public void Pause()
    {
        panel.SetActive(true);
        Time.timeScale = 0;
        paused = true;
    }

    public void Resume()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }

    public void SetVolume(float v)
    {
        AudioListener.volume = v;
    }

    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}