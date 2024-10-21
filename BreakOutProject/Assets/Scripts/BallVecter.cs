using UnityEngine;

public class BounceBall : MonoBehaviour
{
    public BallMoveSO ballMoveSO;
    public BallPowerSO ballPowerSO;
    private Vector2 direction;
    PlayerInputController inputController;
    float rand;

    protected BallStatHandler ballStats { get; private set; }
    void Start()
    {
        ballStats = GetComponent<BallStatHandler>();
        inputController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInputController>();
        direction = new Vector2(Random.Range(-1f,2f), 1).normalized; // 초기 방향
    }

    void Update()
    {
        transform.Translate(direction * ballMoveSO.changeSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 벽에 부딪혔을 때 반사
        if (collision.collider.CompareTag("Wall") || collision.collider.CompareTag("SideWall"))
        {
            direction = Vector2.Reflect(direction, collision.contacts[0].normal);
        }
        else if(collision.collider.CompareTag("TopWall"))
        {
            rand = Random.Range(-1f, 2f);
            direction.x *= rand;
            direction = new Vector2(rand, -1).normalized;
        }
        else if(collision.collider.CompareTag("Player"))
        {
            if(inputController.moveInput ==0)
            {
                rand = Random.Range(-1f, 2f);
            }
            else
            {
                rand = inputController.moveInput;
            }
            direction = new Vector2(rand, 1).normalized;
        }
        else if (collision.collider.CompareTag("Brick"))
        {
            direction = Vector2.Reflect(direction, collision.contacts[0].normal);
            collision.gameObject.GetComponent<Brick>().GetDamage();
        }
    }
    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}