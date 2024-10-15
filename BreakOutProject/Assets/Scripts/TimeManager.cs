using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField][Range(1,120)] private int maxTime;
    private float currentTime;

    public TMP_Text TimerTxt;

    //���� �ð� Ÿ�̸�
    public void Timer()
    {
        currentTime -= Time.deltaTime; //deltaTime�� ���������� ����ȯ�ϸ�, Ÿ�̸� �۵�����.
        TimerTxt.text = currentTime.ToString("F2"); //�Ҽ��� 2�ڸ����� ǥ��.

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
