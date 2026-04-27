using UnityEngine;

public abstract class PuzzleBase : MonoBehaviour
{
    protected bool completed = false;

    public abstract void StartPuzzle();

    protected void Complete(int reward)
    {
        if (completed) return;

        completed = true;
        GameManager.Instance.AddScoreServerRpc(reward);
        GameManager.Instance.CompletePuzzleServerRpc();

        Destroy(gameObject);
    }

    protected void Fail(int penalty)
    {
        GameManager.Instance.AddScoreServerRpc(-penalty);
    }
}