/*
using System;
using System.IO;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    string path;

    void Start()
    {
        path = "URI=file:" + Application.persistentDataPath + "/game.db";

        using (var conn = new SqliteConnection(path))
        {
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText =
                "CREATE TABLE IF NOT EXISTS Scores (score INT, win INT);";
            cmd.ExecuteNonQuery();
        }
    }

    public void InsertScore(int score, int win)
    {
        using (var conn = new SqliteConnection(path))
        {
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText =
                "INSERT INTO Scores (score, win) VALUES (@s, @w)";

            cmd.Parameters.AddWithValue("@s", score);
            cmd.Parameters.AddWithValue("@w", win);

            cmd.ExecuteNonQuery();
        }
    }
    public void GetHighScores()
    {
        using (var conn = new SqliteConnection(path))
        {
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT score FROM Scores ORDER BY score DESC LIMIT 5";

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Debug.Log("Score: " + reader.GetInt32(0));
            }
        }
    }
}
*/