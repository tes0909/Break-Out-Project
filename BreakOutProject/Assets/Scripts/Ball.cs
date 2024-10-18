using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D BallRigidbody;// ???? BallRigidbody.velocity
    [SerializeField] private int InputDirection;//?¡À???? ??? ??????? ??
    //[SerializeField] private BallStat ballStat;
    public BallMoveSO ballMoveSO;
    public BallPowerSO ballPowerSO;
    private float BallSpeed; //???? ?????
    private float BallRotation;//???? ??? ??
    PlayerInputController inputController;

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
        inputController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputController>();
        BallRigidbody = GetComponent<Rigidbody2D>();
        BallRigidbody.velocity = new Vector2(Random.Range(-1f, 1f) * BallSpeed, BallSpeed);
        Game.Instance.GameManager.OnGameOver += DestroyThis;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //SoundManager.SoundInstance.PlaySFX(SoundManager.SoundInstance.SFX_Clips[1]);

        Vector2 bounceDirection = collision.contacts[0].normal;
        
        BallRigidbody.AddForce(bounceDirection * BallSpeed, ForceMode2D.Impulse);


        if (collision.collider.CompareTag("Player"))//?¡À???? ???????
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
        switch (inputController.moveInput)
        {
            case -1f:
                BallRotationEX = BallRotation;//?¡À???? ????? ???????? ????? ??
                break;
            case 0f:
                int zeroRadom = Random.Range(-1, 2);
                BallRotationEX = (BallRotation * zeroRadom);//??????? -1,0,1?? ????? ??
                break;
            case 1f:
                BallRotationEX = (-1f) * BallRotation;//?¡À???? ????? ?????????? ????? ??
                break;
            default:
                break;
        }

        // ?úô ?? ???? ?????? ????????.
        Vector2 bounceDirection = Quaternion.Euler(0, 0, BallRotationEX) *direction; // ???? ???? ??????? ????
        BallRigidbody.velocity = bounceDirection * BallSpeed; // ??? ???????? ??? ????
    }
    private void AddBallForce(Vector2 direction, float BallSpeed)//???? ????????.
    {
        float BallRotationEX = BallRotation;
        int zeroRadom = Random.Range(-1, 2);
        BallRotationEX = (BallRotation * zeroRadom);//??????? -1,0,1?? ????? ??

        // ?úô ?? ???? ?????? ????????.
        Vector2 bounceDirection = Quaternion.Euler(0, 0, BallRotationEX) * direction; // ???? ???? ??????? ????
        BallRigidbody.velocity += bounceDirection * BallSpeed; // ??? ???????? ??? ????
    }

    public void DestroyThis()
    {
        Game.Instance.GameManager.OnGameOver -= DestroyThis;
        Destroy(gameObject);
    }
}
