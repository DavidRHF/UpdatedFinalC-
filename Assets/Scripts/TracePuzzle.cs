using UnityEngine;

public class TracePuzzle : PuzzleBase
{
    float progress = 0;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Path"))
        {
            progress += Time.deltaTime;

            if (progress > 3f)
                Complete(100);
        }
        else
        {
            Fail(5);
        }
    }

    public override void StartPuzzle() { }
}