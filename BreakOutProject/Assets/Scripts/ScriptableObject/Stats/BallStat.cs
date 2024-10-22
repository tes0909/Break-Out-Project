using UnityEngine;
public enum StatsChangeType
{
    Add,
    Multiple,
    Override
}

[System.Serializable]
public class BallStat
{
    public StatsChangeType statsChangeType;
    public float currentRotate;
    public float currentSpeed;
    public int currentPower;
    public BallMoveSO ballMoveSO;
}
