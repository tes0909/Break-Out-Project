using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField][Range(1,120)] private int maxTime;
    private float currentTime;

    public TMP_Text TimerTxt;

    //게임 시간 타이머
    public void Timer()
    {
        currentTime -= Time.deltaTime; //deltaTime을 정수형으로 형변환하면, 타이머 작동안함.
        TimerTxt.text = currentTime.ToString("F2"); //소숫점 2자리까지 표시.

        if(currentTime <= 0)
        {
            GameManager.Instance.PauseGame();
        }
    }

    private void Start()
    {
        currentTime = maxTime;
    }

    private void FixedUpdate()
    {
        Timer();
    }
}
