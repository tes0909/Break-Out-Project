using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class ScoreData
{
    public int highScore;
    public List<int> scores = new List<int>();
}

public class ScoreboardManager
{
    private const string ScoreFileName = "Scoreboard.json";
    private ScoreData scoreData = new ScoreData();

    public static ScoreboardManager Instance;

    public int HighScore => scoreData.highScore;
    public List<int> Scores => scoreData.scores;

    private void Awake()
    {
        // 싱글톤
        if (Instance == null)
        {
            Instance = this;

            LoadScores();

            GameManager.Instance.OnScoreChanged += UpdateHighScore;
        }

    }

    private void UpdateHighScore(int newScore)
    {
        if(newScore > scoreData.highScore)
        {
            scoreData.highScore = newScore;
        }

        AddScore(newScore);
    }

    public void AddScore(int score)
    {
        scoreData.scores.Add(score);
        scoreData.scores.Sort((a,b) => b.CompareTo(a)); // 내림차순 정렬

        // 최고 점수 갱신
        if (score > scoreData.highScore)
        {
            scoreData.highScore = score;
        }

        SaveScores();
    }

    private void SaveScores()
    {
        string json = JsonUtility.ToJson(scoreData, true);
        string path = Path.Combine(Application.persistentDataPath, ScoreFileName);
        File.WriteAllText(path, json);
    }

    private void LoadScores()
    {
        string path = Path.Combine(Application.persistentDataPath, ScoreFileName);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            scoreData = JsonUtility.FromJson<ScoreData>(json);
        }
    }
}
