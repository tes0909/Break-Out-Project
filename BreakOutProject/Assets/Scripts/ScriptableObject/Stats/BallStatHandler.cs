using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStatHandler : MonoBehaviour
{
    // �⺻���ݰ� �߰� ���ݵ��� ����ؼ� ���� ������ ����ϴ� ������ ����
    // �ٵ� ������ �׳� �⺻���ݸ�

    [SerializeField] private BallStat baseStat;
    public BallStat CurrentStat { get; private set; }

    public List<BallStat> statModifiers = new List<BallStat>();

    private void Awake()
    {
        UpdateBallStat();
    }

    private void UpdateBallStat()
    {
        BallMoveSO ballSO = null;
        if(baseStat.ballMoveSO !=null)
        {
            ballSO = Instantiate(baseStat.ballMoveSO);
            CurrentStat.statsChangeType = baseStat.statsChangeType;
            CurrentStat.currentPower = baseStat.currentPower;
            CurrentStat.currentSpeed = baseStat.currentSpeed;
            CurrentStat.currentRotate = baseStat.currentRotate;

        }

    }
}
