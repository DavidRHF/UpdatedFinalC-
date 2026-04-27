using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using System;

public class GameManager : NetworkBehaviour
{
    private bool isGameOver = false;
    public static GameManager Instance;

    public float totalTime = 120f;
    public NetworkVariable<int> score = new NetworkVariable<int>();
    public NetworkVariable<float> currentTime = new NetworkVariable<float>();

    public int puzzleIndex = 0;
    public int totalPuzzles = 2;

    public Action<int> OnScoreChanged;   
    public Action<float> OnTimeChanged;

    public AudioSource audioSource;

    public GameState currentState;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (IsServer)
        {
            currentTime.Value = totalTime;
            score.Value = PlayerPrefs.GetInt("LastScore", 0);
        }
    }

    void Update()
    {
        if (!IsServer) return;

        currentTime.Value -= Time.deltaTime;

        if (audioSource != null)
        {
            audioSource.pitch = 1 + (1 - currentTime.Value / totalTime);
        }

        OnTimeChanged?.Invoke(currentTime.Value);

        if (currentTime.Value <= 0 && !isGameOver)
            LoseGame();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        OnScoreChanged?.Invoke(score.Value);
        OnTimeChanged?.Invoke(currentTime.Value);
    }

    [ServerRpc]
    public void AddScoreServerRpc(int amount)
    {
        score.Value += amount;
        OnScoreChanged?.Invoke(score.Value);
    }

    void LoadNextScene()
    {
        puzzleIndex++;

        if (puzzleIndex == 1)
            NetworkManager.Singleton.SceneManager.LoadScene(
                "GameScene_Eraser",
                LoadSceneMode.Single
            );
        else if (puzzleIndex == 2)
            NetworkManager.Singleton.SceneManager.LoadScene(
                "GameScene_Word",
                LoadSceneMode.Single
            );
        else
            WinGame();
    }

    [ServerRpc]
    public void CompletePuzzleServerRpc()
    {
        LoadNextScene();
    }

    void WinGame()
    {
        SaveSystem.Save(score.Value, true);
        NetworkManager.Singleton.SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
    }

    void LoseGame()
    {
        if (isGameOver) return;

        isGameOver = true;

        Debug.Log("YOU LOST");

        NetworkManager.Singleton.SceneManager.LoadScene("LoseScene", LoadSceneMode.Single);
    }
}