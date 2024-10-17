using System;
using Unity.VisualScripting;
using UnityEngine;

public enum GameState
{
    playing,
    paused,
    GameOver,
    LevelCleared
}

public interface IGameManager
{
    GameState currentState { get; }
    int Score { get; set; }
    int Life { get; set; }
    void StartGame();
    void CountDownGameStart();
    void PauseGame();
    void GameOver();
    void QuitGame();
}

public class GameManager : MonoBehaviour, IGameManager
{
    public GameState currentState { get; private set; }
    public int DifficultyLevel { get; private set; }

    private int score; //점수
    private int life = 3; //임의로 목숨 3개

    public event Action<int> OnScoreChanged;
    public event Action<int> OnLifeChanged;
    public event Action OnGameOver;
    public event Action OnGameClear;
    public event Action<int> OnGameStart;

    private InGameScene inGameScene;


    public int Life
    {
        get => life;
        set
        {
            //라이프 값이 변하면
            if (life != value)
            {
                life = value;
                OnLifeChanged?.Invoke(life);
                if (life <= 0)
                {
                    GameOver();
                }
            }
        }
    }

    public int Score
    {
        get => score;
        set
        {
            if (score != value)
            {
                score = value;
                OnScoreChanged?.Invoke(score);

            }
        }
    }


    private void Awake()
    {
            DontDestroyOnLoad(gameObject);
            currentState = GameState.paused;
            OnGameOver += PauseGame;
    }

    public void StartGame()
    {
        currentState = GameState.playing;
        Time.timeScale = 1f;
        OnGameStart?.Invoke(DifficultyLevel);
        GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Ball"));

    }

    public void CountDownGameStart()
    {
        Time.timeScale = 1f;
        Game.Instance.UiManager.OpenPopUpUI("CountdownUI");
        Invoke("StartGame", 3f);
    }

    public void PauseGame()
    {
        currentState = GameState.paused;
        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        currentState = GameState.GameOver;
        UI_GameOver ui = Game.Instance.UiManager.OpenPopUpUI("GameOverUI") as UI_GameOver;
        ui.OnResponseEvent += CountDownGameStart;
        OnGameOver?.Invoke();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetDifficultyLevel(difficultyLevel difficultyLevel)
    {
        DifficultyLevel = (int)difficultyLevel;
    }
}
