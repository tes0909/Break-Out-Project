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
    public Action OnResponseTime;
	//���� �ð� Ÿ�̸�
	public void Timer()
    {
        currentTime -= Time.deltaTime; //deltaTime�� ���������� ����ȯ�ϸ�, Ÿ�̸� �۵�����.
        if(Game.Instance.GameManager.currentState==GameState.Playing)
            OnChangeTime?.Invoke(currentTime);
        if(currentTime <= 0)
        {
            OnResponseTime?.Invoke();
        }
    }

    public void CountDown(float time, Action action)
    {
        currentTime = time;
        OnResponseTime = action;
    }

    public void StartTimer(int difficulty)
    {
        currentTime = maxTime;
    }

    private void FixedUpdate()
    {
        if (currentTime >= 0)
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
