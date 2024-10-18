using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action<float> OnMoveEvent;

    public void CallMoveEvent(float direction)
    {
        OnMoveEvent?.Invoke(direction);
    }
}
