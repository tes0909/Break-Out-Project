using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int score; //����
    private int life = 3; //���Ƿ� ��� 3��

    public event Action<int> OnScoreChanged;
    public event Action<int> OnLifeChanged;

    public int Life
    {
        get => life;
        set
        {
            //������ ���� ���ϸ�
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
        //�̱���
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

    //�ΰ��� ���� ��, 3�� ī��Ʈ �ٿ� �� ���� ����
    public void CountDownGameStart()
    {
        Time.timeScale = 0;
        Invoke("GameStart", 3f);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    //��������
    public void GameQuit()
    {
        Application.Quit();
    }
}
