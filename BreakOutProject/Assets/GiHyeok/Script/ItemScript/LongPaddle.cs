using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class LongPaddle : IItemEffect
{
    public float _duration = 5f;
    private float[] lengthList = {1.5f, 2.0f };
    private float length;
    private Transform paddle;
    public Color color { get; set; } = Color.white;
    public LongPaddle()
    {
        paddle = GameObject.Find("Paddle").transform.GetChild(0).transform;
        length = lengthList[Random.Range(0, 1)];
        switch (length) 
        {
            case 1.5f:
                color = Color.white;
                break;

            case 2.0f:
                color = Color.blue;
                break;
        }
    }
    public void Affect()
    {
        //패들 길이 증가or감소
        paddle.localScale = new Vector3(paddle.localScale.x*length, paddle.localScale.y, paddle.localScale.z);
		Game.Instance.StartCoroutine(Applying(_duration));
	}

	public void Applying()
    {
        //길이 복구
        paddle.localScale /= length;
    }

	public IEnumerator Applying(float delay)
	{
		yield return new WaitForSeconds(delay);
		paddle.transform.localScale /= length;

	}
}
