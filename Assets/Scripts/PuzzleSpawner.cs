using UnityEngine;

public class PuzzleSpawner : MonoBehaviour
{
    public GameObject[] puzzlePrefabs;

    private GameObject currentPuzzle;

    public Transform spawnParent;

    void Start()
    {
        SpawnPuzzle();
    }

    public void SpawnPuzzle()
    {
        if (currentPuzzle != null)
            Destroy(currentPuzzle);

        int index = GameManager.Instance.puzzleIndex;

        if (index >= puzzlePrefabs.Length)
            return;

        currentPuzzle = Instantiate(puzzlePrefabs[index], spawnParent);

        Debug.Log("Spawned puzzle: " + index);
    }
}