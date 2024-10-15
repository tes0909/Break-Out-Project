using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int score; //점수
    private int life = 3; //임의로 목숨 3개

    public event Action<int> OnScoreChanged;
    public event Action<int> OnLifeChanged;

    public int Life
    {
        get => life;
        set
        {
            //라이프 값이 변하면
            if(life != value)
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
            if(score != value)
            {
                score = value;
                OnScoreChanged?.Invoke(score);
            }
        }
    }


    private void Awake()
    {
        //싱글톤
        if(Instance == null)
        { 
            Instance = this; 
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void GameStart()
    {
        Time.timeScale = 1f;
    }

    //인게임 입장 시, 3초 카운트 다운 후 게임 시작
    public void CountDownGameStart()
    {
        Time.timeScale = 0;
        Invoke("GameStart", 3f);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    //게임종료
    public void GameQuit()
    {
        Application.Quit();
    }
}
