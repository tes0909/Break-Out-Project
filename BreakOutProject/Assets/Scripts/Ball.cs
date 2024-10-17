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
    InputManager inputManager;

    protected BallStatHandler ballStats { get; private set; }
    void Awake()
    {
        ballStats = GetComponent<BallStatHandler>();
        //BallSpeed = 10f;
        BallSpeed = ballStats.CurrentStat.currentSpeed;
        //BallRotation = 40f;
        BallRotation = ballStats.CurrentStat.currentRotate;
    }

    void Start()
    {
        inputManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InputManager>();
        Rigidbody2D BallRigidbody = GetComponent<Rigidbody2D>();
        BallRigidbody.velocity = new Vector2(Random.Range(-1f, 1f) * BallSpeed, BallSpeed);
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundManager.SoundInstance.PlaySFX(SoundManager.SoundInstance.SFX_Clips[1]);
        BallRigidbody = GetComponent<Rigidbody2D>();
        Vector2 bounceDirection = collision.contacts[0].normal;
        BallRigidbody.AddForce(bounceDirection * BallSpeed, ForceMode2D.Impulse);

        if (collision.collider.CompareTag("Player"))//�÷��̾� �����ױ�
        {
            RotateArm();
        }
        if (collision.collider.CompareTag("Brick"))
        {
            collision.gameObject.GetComponent<Brick>().GetDamage();
        }
    }
    private void RotateArm()
    {
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
        Debug.Log(BallRotationEX);
        //this.transform.rotation = Quaternion.Euler(0, 0, BallRotationEX);
        // �浹 �� ƨ��� ������ �����մϴ�.
        Vector2 bounceDirection = Quaternion.Euler(0, 0, BallRotationEX) * Vector2.up; // ���� ���⿡ ȸ������ ����
        BallRigidbody.velocity = bounceDirection * BallSpeed; // ȸ�� �������� �ӵ� ����
    }
}
