using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface ITimeManager
{
    float CurrentTime { get; }
    void StartTimer();
    void ResetTimer();
}

public class TimeManager : MonoBehaviour, ITimeManager
{
    [SerializeField][Range(1,120)] private int maxTime;
    private float currentTime;
    public float CurrentTime => currentTime;


    //게임 시간 타이머
    public void Timer()
    {
        currentTime -= Time.deltaTime; //deltaTime을 정수형으로 형변환하면, 타이머 작동안함.

        if(currentTime <= 0)
        {
            GameManager.Instance.GameOver();
        }
    }

    public void StartTimer()
    {
        currentTime = maxTime;

    }

    public void ResetTimer()
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


}
