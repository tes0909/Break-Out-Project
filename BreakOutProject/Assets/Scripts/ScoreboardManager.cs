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

public class ScoreboardManager : MonoBehaviour
{
    private const string ScoreFileName = "Scoreboard.json";
    private ScoreData scoreData = new ScoreData();

    public static ScoreboardManager Instance;
    public event Action<int> OnHighScoreUpdated;

    public int HighScore => scoreData.highScore;
    public List<int> Scores => scoreData.scores;

    private void Awake()
    {
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
			LoadScores();
		}
		else
		{
			Destroy(gameObject);
		}

	}
	private void Start()
	{
        if(Game.Instance != null)
		{
            Game.Instance.GameManager.OnScoreChanged += UpdateHighScore; 
        }

	}

	private void UpdateHighScore(int newScore)
    {
        if (newScore > scoreData.highScore)
        {
            scoreData.highScore = newScore;
            OnHighScoreUpdated?.Invoke(newScore);
        }
        if (GameState.GameOver == Game.Instance.GameManager.currentState ||
            GameState.LevelCleared == Game.Instance.GameManager.currentState)
        {
            AddScore(newScore);
        }

    }

    public void AddScore(int score)
    {
        scoreData.scores.Add(score);
        scoreData.scores.Sort((a, b) => b.CompareTo(a)); // 내림차순 정렬

        if (Scores.Count > 10) //리스트 10개 초과 시
        {
            Scores.RemoveAt(10); //가장 낮은 수 제거
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
