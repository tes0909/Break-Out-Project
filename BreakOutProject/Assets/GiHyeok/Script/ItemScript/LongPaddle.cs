using UnityEngine;

public class LongPaddle : MonoBehaviour, ICommand
{
    public float _duration = 5f;
    private SpriteRenderer _spriteRenderer;
    private float[] lengthList = { 0.5f, 1.5f };
    private float length;
    private GameObject paddle;
    public void Awake()
    {
        paddle = GameObject.Find("Paddle(Clone)/Paddle");
        _spriteRenderer = GetComponent<SpriteRenderer>();
        length = lengthList[Random.Range(0, 1)];
        if (length == 0.5f)
        {
            _spriteRenderer.color = Color.red;
        }
        else
        {
            _spriteRenderer.color = Color.blue;
        }
    }
    public void Affect()
    {
        //패들 길이 증가or감소
        paddle.transform.localScale *= length;
        Invoke("Applying", _duration);
    }

    public void Applying()
    {
        //길이 복구
        paddle.transform.localScale /= length;
    }
}
