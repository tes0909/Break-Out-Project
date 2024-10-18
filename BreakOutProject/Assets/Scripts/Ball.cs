using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D BallRigidbody;// 공의 BallRigidbody.velocity
    [SerializeField] private int InputDirection;//플레이어가 키를 입력했을 때
    //[SerializeField] private BallStat ballStat;
    public BallMoveSO ballMoveSO;
    public BallPowerSO ballPowerSO;
    private float BallSpeed; //공의 스피드
    private float BallRotation;//공의 회전 값
    InputManager inputManager;

    protected BallStatHandler ballStats { get; private set; }
    void Awake()
    {
        ballStats = GetComponent<BallStatHandler>();
        BallRigidbody = GetComponent<Rigidbody2D>();
        BallSpeed = ballMoveSO.changeSpeed;//BallSpeed = 10f;
        BallRotation = ballMoveSO.changeRotate;//BallRotation = 40f;
    }

    void Start()
    {
        inputManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InputManager>();
        BallRigidbody.velocity = new Vector2(Random.Range(-1f, 1f) * BallSpeed, BallSpeed);
        Game.Instance.GameManager.OnGameOver += DestroyThis;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Game.Instance.SoundManager.PlaySFX(Game.Instance.SoundManager.SFX_Clips[1]); ResourceManager추가후 추가
        BallRigidbody = GetComponent<Rigidbody2D>();
        Vector2 bounceDirection = collision.contacts[0].normal;
        
        BallRigidbody.AddForce(bounceDirection * BallSpeed, ForceMode2D.Impulse);


        if (collision.collider.CompareTag("Player"))//플레이어 네임테그
        {
        ForceTheBall(Vector2.up, BallSpeed, BallRotation);
        }
        if (collision.collider.CompareTag("Brick"))
        {
            collision.gameObject.GetComponent<Brick>().GetDamage();
        }
        if(collision.collider.CompareTag("SideWall"))
        {
            AddBallForce(Vector2.up, BallSpeed/2);
        }
        if (BallRigidbody.velocity.y == 0 && BallRigidbody.velocity.x == 0)
        {
            BallRigidbody.velocity = new Vector2(Random.Range(-1f, 1f) * BallSpeed, BallSpeed);
        }
    }
    private void ForceTheBall(Vector2 direction,float BallSpeed, float BallRotation)
    {
        direction.Normalize();
        float BallRotationEX = BallRotation;
        switch (inputManager.horizontal)
        {
            case -1f:
                BallRotationEX = BallRotation;//플레이어 핸들러가 왼쪽으로 이동할 때
                break;
            case 0f:
                int zeroRadom = Random.Range(-1, 2);
                BallRotationEX = (BallRotation * zeroRadom);//회전값이 -1,0,1중 하나가 됨
                break;
            case 1f:
                BallRotationEX = (-1f) * BallRotation;//플레이어 핸들러가 오른쪽으로 이동할 때
                break;
            default:
                break;
        }

        // 충돌 시 튕기는 방향을 수정합니다.
        Vector2 bounceDirection = Quaternion.Euler(0, 0, BallRotationEX) *direction; // 위쪽 방향에 회전값을 적용
        BallRigidbody.velocity = bounceDirection * BallSpeed; // 회전 방향으로 속도 설정
    }
    private void AddBallForce(Vector2 direction, float BallSpeed)//힘을 더해줍니다.
    {
        float BallRotationEX = BallRotation;
        int zeroRadom = Random.Range(-1, 2);
        BallRotationEX = (BallRotation * zeroRadom);//회전값이 -1,0,1중 하나가 됨

        // 충돌 시 튕기는 방향을 수정합니다.
        Vector2 bounceDirection = Quaternion.Euler(0, 0, BallRotationEX) * direction; // 위쪽 방향에 회전값을 적용
        BallRigidbody.velocity += bounceDirection * BallSpeed; // 회전 방향으로 속도 설정
    }

    public void DestroyThis()
    {
        Game.Instance.GameManager.OnGameOver -= DestroyThis;
        Destroy(gameObject);
    }
}
