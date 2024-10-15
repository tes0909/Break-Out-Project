using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D BallRigidbody;
    [SerializeField]
    private float BallSpeed;
    [SerializeField]
    private float RotationTorque; // ȸ�� ���� ���� ����
    private int InputDirection;
    void Awake()
    {
        BallSpeed = 10f;
        RotationTorque = 5f; // ȸ�� ���� �⺻�� ����
    }

    void Start()
    {
        Rigidbody2D BallRigidbody = GetComponent<Rigidbody2D>();
        BallRigidbody.AddForce(Vector2.up * BallSpeed, ForceMode2D.Impulse);
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            InputDirection = -1; // ���� �̵�
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            InputDirection = 1; // ������ �̵�
        }
        else// �ȿ����̸�
        {
            InputDirection = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallRigidbody = GetComponent<Rigidbody2D>();
        Vector2 bounceDirection = collision.contacts[0].normal;
        BallRigidbody.AddForce(bounceDirection * BallSpeed, ForceMode2D.Impulse);

        if (collision.collider.CompareTag("Player"))
        {
            float rotationTorquePlayer = RotationTorque;
            if (InputDirection == -1)//�÷��̾� �ڵ鷯�� �������� �̵��� ��
            {
                rotationTorquePlayer *= -1f;
            }
            else if (InputDirection == 0)
            {
                rotationTorquePlayer = 0;
            }
            RotateArm(rotationTorquePlayer);
        }
    }
    private void RotateArm(float RotateLeftRight)
    {
        Vector2 direction = new Vector2(0, 0);
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0, 0, rotz);
    }
}
