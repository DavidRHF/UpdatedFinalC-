using UnityEngine;

public class EraserPuzzle : PuzzleBase
{
    public Transform eraser;
    public float speed = 5f;

    int remaining = 0;

    void Start()
    {
        remaining = GameObject.FindGameObjectsWithTag("Eraseable").Length;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Eraseable"))
        {
            Destroy(other.gameObject);
            remaining--;

            if (remaining <= 0)
            {
                Complete(100);
            }
        }
    }

    public override void StartPuzzle() { }
}