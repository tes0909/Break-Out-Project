using System.Collections;
using UnityEngine;

public class LongPaddle : IItemEffect
{
    public float _duration = 5f;
    private float[] lengthList = { 0.5f, 1.5f };
    private float length;
    private Transform paddle;
    public LongPaddle()
    {
        paddle = GameObject.Find("Paddle").transform.GetChild(0).transform;
        length = lengthList[Random.Range(0, 1)];
    }
    public void Affect()
    {
        //패들 길이 증가or감소
        paddle.localScale *= length;
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
