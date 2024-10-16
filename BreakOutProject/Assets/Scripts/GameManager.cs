using System;
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
    void PauseGame();
    void GameOver();
    void QuitGame();
}

public class GameManager : MonoBehaviour, IGameManager
{
    public static GameManager Instance;
    public GameState currentState { get; private set; }

    private int score; //점수
    private int life = 3; //임의로 목숨 3개

    public event Action<int> OnScoreChanged;
    public event Action<int> OnLifeChanged;
    public event Action OnGameOver;

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
                if(life <= 0)
                {
                    GameOver();
                }
            }
        }
    }


    private void Awake()
    {
        //싱글톤
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            OnGameOver += PauseGame;
        }
        else Destroy(gameObject);
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
    }

    //인게임 입장 시, 3초 카운트 다운 후 게임 시작
    public void CountDownGameStart()
    {
        Time.timeScale = 0;
        UIManager.Instance.OpenPopUpUI("Countdown");
        Invoke("GameStart", 3f);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        currentState = GameState.GameOver;
        UI_GameOver ui = UIManager.Instance.OpenPopUpUI("GameOverUI") as UI_GameOver;
        ui.OnResponseEvent += CountDownGameStart;
        OnGameOver?.Invoke();
    }

    //게임종료
    public void QuitGame()
    {
        Application.Quit();
    }
}
