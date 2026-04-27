using UnityEngine;

public class EraserPuzzle : MonoBehaviour
{
    int remaining;

    void Start()
    {
        remaining = GameObject.FindGameObjectsWithTag("Eraseable").Length;
        Debug.Log("Total eraseable: " + remaining);
    }

    public void EraseObject(GameObject obj)
    {
        Destroy(obj);
        remaining--;

        Debug.Log("Remaining: " + remaining);

        if (remaining <= 0)
        {
            Debug.Log("ALL ERASED → WIN");
            Win();
        }
    }

    void Win()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("WinScene");
    }
}