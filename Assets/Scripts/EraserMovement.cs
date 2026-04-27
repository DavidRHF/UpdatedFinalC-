using UnityEngine;

public class EraserMovement : MonoBehaviour
{
    public float speed = 5f;
    public EraserPuzzle puzzle;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(h, v) * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Eraseable"))
        {
            puzzle.EraseObject(other.gameObject);
        }
    }
}