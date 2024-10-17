using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStatHandler : MonoBehaviour
{
    // 기본스텟과 추가 스텟들을 계산해서 최종 스텟을 계산하는 로직이 있음
    // 근데 지금은 그냥 기본스텟만

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
