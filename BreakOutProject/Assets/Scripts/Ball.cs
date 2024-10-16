using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D BallRigidbody;// ���� BallRigidbody.velocity
    [SerializeField]
    private float BallSpeed; //���� ���ǵ�
    [SerializeField]
    private int InputDirection;//�÷��̾ Ű�� �Է����� ��
    [SerializeField]
    private float BallRotation;//���� ȸ�� ��
    void Awake()
    {
        BallSpeed = 10f;
        BallRotation = 40f;

    }

    void Start()
    {
        Rigidbody2D BallRigidbody = GetComponent<Rigidbody2D>();
        BallRigidbody.velocity = new Vector2(Random.Range(-1f, 1f) * BallSpeed, BallSpeed);
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

        if (collision.collider.CompareTag("Player"))//�÷��̾� �����ױ�
        {
            RotateArm();
        }
    }
    private void RotateArm()
    {
        float BallRotationEX = BallRotation;
        switch (InputDirection)
        {
            case -1:
                BallRotationEX = BallRotation;//�÷��̾� �ڵ鷯�� �������� �̵��� ��
                break;
            case 0:
                int zeroRadom = Random.Range(-1, 2);
                BallRotationEX = (BallRotation * zeroRadom);//ȸ������ -1,0,1�� �ϳ��� ��
                break;
            case 1:
                BallRotationEX = (-1f) * BallRotation;//�÷��̾� �ڵ鷯�� ���������� �̵��� ��
                break;
            default:
                break;
        }
        Debug.Log(BallRotationEX);
        //this.transform.rotation = Quaternion.Euler(0, 0, BallRotationEX);
        // �浹 �� ƨ��� ������ �����մϴ�.
        Vector2 bounceDirection = Quaternion.Euler(0, 0, BallRotationEX) * Vector2.up; // ���� ���⿡ ȸ������ ����
        BallRigidbody.velocity = bounceDirection * BallSpeed; // ȸ�� �������� �ӵ� ����
    }
}
