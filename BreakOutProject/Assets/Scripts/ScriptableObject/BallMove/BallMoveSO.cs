using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DefaultBallMoveSO", menuName = "Ball/Move/Default", order = 0)]
public class BallMoveSO : ScriptableObject
{
    [Header("Move Info")]
    public float changeRotate;
    public float changeSpeed;
}
