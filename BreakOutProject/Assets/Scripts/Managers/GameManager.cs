using System;
using Unity.VisualScripting;
using UnityEngine;

public enum GameState
{
    Idle = 0,
    Playing = 1,
    Paused = 2,
    GameOver,
	LevelCleared
}

public interface ITimeHandler
{
    public void HandleTime();
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

public class GameManager: IGameManager
{
    public GameState currentState { get; private set; }
    public int DifficultyLevel { get; private set; }

    private int score; //����
    private int life = 3; //���Ƿ� ��� 3��

    public event Action<int> OnScoreChanged;
    public event Action<int> OnLifeChanged;

    public event Action OnGameOver;
    public event Action OnGameClear;
    public event Action<int> OnGameStart;

    private InGameScene inGameScene;
    private TimeManager timeManager;


    public int Life
    {
        get => life;
        set
        {
            //������ ���� ���ϸ�
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
    public GameManager()
    {
		currentState = GameState.Idle;
        DifficultyLevel = 0;
		timeManager = Game.Instance.gameObject.GetComponent<TimeManager>();
	}

    public void StartGame()
    {
        score = 0;
        currentState = GameState.Playing;
        Time.timeScale = 1f;
        timeManager.CountDown(30, GameOver);
        OnGameStart?.Invoke(DifficultyLevel);
        ResourceManager.Instantiate("VecterBall");
        //GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Ball"));
    }

    public void CountDownGameStart()
    {
        Game.Instance.UiManager.OpenPopUpUI("CountdownUI");
		timeManager.CountDown(3, StartGame);
    }

    public void PauseGame()
    {
        currentState = GameState.Paused;
        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        Game.Instance.StopAllCoroutines();
        Game.Instance.UiManager.CloseAllPopUp();
        currentState = GameState.Idle;
        UI_DefaultPopup ui = Game.Instance.UiManager.OpenPopUpUI("GameEndUI") as UI_DefaultPopup;
        ui.Init("GameOver", CountDownGameStart);
        if (score > ScoreboardManager.Instance.HighScore)
        {
            ScoreboardManager.Instance.AddScore(score);
        }
        OnGameOver?.Invoke();
    }

    public void GameClear()
    {
		Game.Instance.StopAllCoroutines();
		Game.Instance.UiManager.CloseAllPopUp();

		currentState = GameState.LevelCleared;
        Debug.Log("���� Ŭ����");
        if(score > ScoreboardManager.Instance.HighScore)
        {
            ScoreboardManager.Instance.AddScore(score);
        }
		UI_DefaultPopup ui = Game.Instance.UiManager.OpenPopUpUI("GameEndUI") as UI_DefaultPopup;
		ui.Init("GameClear", CountDownGameStart);
		Debug.Log("���� Ŭ����");
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
