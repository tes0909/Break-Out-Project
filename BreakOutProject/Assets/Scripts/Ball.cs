using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D BallRigidbody;// ���� BallRigidbody.velocity
    [SerializeField] private int InputDirection;//�÷��̾ Ű�� �Է����� ��
    //[SerializeField] private BallStat ballStat;
    public BallMoveSO ballMoveSO;
    public BallPowerSO ballPowerSO;
    private float BallSpeed; //���� ���ǵ�
    private float BallRotation;//���� ȸ�� ��
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
        // Game.Instance.SoundManager.PlaySFX(Game.Instance.SoundManager.SFX_Clips[1]); ResourceManager�߰��� �߰�
        BallRigidbody = GetComponent<Rigidbody2D>();
        Vector2 bounceDirection = collision.contacts[0].normal;
        
        BallRigidbody.AddForce(bounceDirection * BallSpeed, ForceMode2D.Impulse);


        if (collision.collider.CompareTag("Player"))//�÷��̾� �����ױ�
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
                BallRotationEX = BallRotation;//�÷��̾� �ڵ鷯�� �������� �̵��� ��
                break;
            case 0f:
                int zeroRadom = Random.Range(-1, 2);
                BallRotationEX = (BallRotation * zeroRadom);//ȸ������ -1,0,1�� �ϳ��� ��
                break;
            case 1f:
                BallRotationEX = (-1f) * BallRotation;//�÷��̾� �ڵ鷯�� ���������� �̵��� ��
                break;
            default:
                break;
        }

        // �浹 �� ƨ��� ������ �����մϴ�.
        Vector2 bounceDirection = Quaternion.Euler(0, 0, BallRotationEX) *direction; // ���� ���⿡ ȸ������ ����
        BallRigidbody.velocity = bounceDirection * BallSpeed; // ȸ�� �������� �ӵ� ����
    }
    private void AddBallForce(Vector2 direction, float BallSpeed)//���� �����ݴϴ�.
    {
        float BallRotationEX = BallRotation;
        int zeroRadom = Random.Range(-1, 2);
        BallRotationEX = (BallRotation * zeroRadom);//ȸ������ -1,0,1�� �ϳ��� ��

        // �浹 �� ƨ��� ������ �����մϴ�.
        Vector2 bounceDirection = Quaternion.Euler(0, 0, BallRotationEX) * direction; // ���� ���⿡ ȸ������ ����
        BallRigidbody.velocity += bounceDirection * BallSpeed; // ȸ�� �������� �ӵ� ����
    }

    public void DestroyThis()
    {
        Game.Instance.GameManager.OnGameOver -= DestroyThis;
        Destroy(gameObject);
    }
}
