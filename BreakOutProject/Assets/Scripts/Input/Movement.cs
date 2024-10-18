using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private PlayerController controller;
    private Rigidbody2D Rigidbody;
    private Vector2 movementDirection = Vector2.zero;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void FixedUpdate()
    {
        ApplyMovement(movementDirection);
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 5;
        Rigidbody.velocity = direction;
    }
}
