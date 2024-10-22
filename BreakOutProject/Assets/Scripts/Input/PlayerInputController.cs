using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : PlayerController
{
    private Camera Camera;
    public float moveInput;
    private void Awake()
    {
        Camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<float>();
        CallMoveEvent(moveInput);
    }
}
