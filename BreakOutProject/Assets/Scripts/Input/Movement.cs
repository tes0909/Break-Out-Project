using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private PlayerController controller;
    private Rigidbody2D Rigidbody;
    private float movementDirection;
    [SerializeField] private float speed;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(float direction)
    {
        movementDirection = direction;
    }

    private void FixedUpdate()
    {
        ApplyMovement(movementDirection);
    }

    private void ApplyMovement(float direction)
    {
        direction = direction * 5;
        Rigidbody.velocity = new Vector2(direction * speed, 0);
    }
}
