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

	//게임 시간 타이머
	public void Timer()
    {
        currentTime -= Time.deltaTime; //deltaTime을 정수형으로 형변환하면, 타이머 작동안함.
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
