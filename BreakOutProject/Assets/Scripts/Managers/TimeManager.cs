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


    //���� �ð� Ÿ�̸�
    public void Timer()
    {
        currentTime -= Time.deltaTime; //deltaTime�� ���������� ����ȯ�ϸ�, Ÿ�̸� �۵�����.

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
