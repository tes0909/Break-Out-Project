using System.Collections;
using UnityEngine;

public class MultiBall : IItemEffect
{
    private GameObject ball;
    public MultiBall()
    {
        ball = GameObject.Find("VectorBall");
    }
    public void Affect()
    {
        GameObject.Instantiate(ball);
		GameObject.Instantiate(ball);
    }
	public IEnumerator Applying(float delay)
	{
		yield return new WaitForSeconds(delay);
	}
}
