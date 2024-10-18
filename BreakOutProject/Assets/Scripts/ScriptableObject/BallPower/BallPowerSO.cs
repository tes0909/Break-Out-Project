using UnityEngine;

[CreateAssetMenu(fileName = "DefaultBallPowerSO", menuName = "Ball/Power/Default", order = 1)]
public class BallPowerSO : ScriptableObject
{
    [Header("Power Info")]
    public int changePower;
}
