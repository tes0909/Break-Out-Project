using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D BallRigidbody;// 공의 BallRigidbody.velocity
    [SerializeField]
    private float BallSpeed; //공의 스피드
    [SerializeField]
    private int InputDirection;//플레이어가 키를 입력했을 때
    [SerializeField]
    private float BallRotation;//공의 회전 값
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
            InputDirection = -1; // 왼쪽 이동
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            InputDirection = 1; // 오른쪽 이동
        }
        else// 안움직이면
        {
            InputDirection = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallRigidbody = GetComponent<Rigidbody2D>();
        Vector2 bounceDirection = collision.contacts[0].normal;
        BallRigidbody.AddForce(bounceDirection * BallSpeed, ForceMode2D.Impulse);

        if (collision.collider.CompareTag("Player"))//플레이어 네임테그
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
                BallRotationEX = BallRotation;//플레이어 핸들러가 왼쪽으로 이동할 때
                break;
            case 0:
                int zeroRadom = Random.Range(-1, 2);
                BallRotationEX = (BallRotation * zeroRadom);//회전값이 -1,0,1중 하나가 됨
                break;
            case 1:
                BallRotationEX = (-1f) * BallRotation;//플레이어 핸들러가 오른쪽으로 이동할 때
                break;
            default:
                break;
        }
        Debug.Log(BallRotationEX);
        //this.transform.rotation = Quaternion.Euler(0, 0, BallRotationEX);
        // 충돌 시 튕기는 방향을 수정합니다.
        Vector2 bounceDirection = Quaternion.Euler(0, 0, BallRotationEX) * Vector2.up; // 위쪽 방향에 회전값을 적용
        BallRigidbody.velocity = bounceDirection * BallSpeed; // 회전 방향으로 속도 설정
    }
}
