using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public Image timerBar;

    void Start()
    {
        if (GameManager.Instance == null) return;

        GameManager.Instance.OnTimeChanged += UpdateTimer;
        UpdateTimer(GameManager.Instance.currentTime.Value);
    }

    void UpdateTimer(float time)
    {
        float max = GameManager.Instance.totalTime;
        float percent = time / max;

        timerBar.fillAmount = percent;

        if (percent > 0.5f)
            timerBar.color = Color.green;
        else if (percent > 0.25f)
            timerBar.color = Color.yellow;
        else
            timerBar.color = Color.red;
    }

    void OnDestroy()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnTimeChanged -= UpdateTimer;
    }

}