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
        for(int i = 0 ; i < 2; i++)
        {
			GameObject ball1 = ResourceManager.Instantiate("VectorBall");
            ball.transform.position = ball.transform.position;
		}
    }
	public IEnumerator Applying(float delay)
	{
		yield return new WaitForSeconds(delay);
	}
}
