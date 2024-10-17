using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TimeManager : MonoBehaviour
{
    [SerializeField][Range(1,120)] private int maxTime;
    private float currentTime;
    public float CurrentTime => currentTime;
    
    public event Action<float> OnChangeTime;


	public void Start()
	{
        GameManager.Instance.OnGameStart += StartTimer;
	}

	//���� �ð� Ÿ�̸�
	public void Timer()
    {
        currentTime -= Time.deltaTime; //deltaTime�� ���������� ����ȯ�ϸ�, Ÿ�̸� �۵�����.
        OnChangeTime(currentTime);
        if(currentTime <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }

    public void StartTimer(int difficulty)
    {
        currentTime = maxTime;
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.currentState == GameState.playing)
        {
            Timer();
        }
    }

    public void SetMaxTime(int time)
    {
        if(0<time && time < 121)
        {
			maxTime = time;
		}
    }


}
