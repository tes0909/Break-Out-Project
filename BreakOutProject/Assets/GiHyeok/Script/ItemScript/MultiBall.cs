using System.Collections;
using UnityEngine;

public class MultiBall : IItemEffect
{
    private GameObject ball;
    public Color color { get; set; } = Color.white;

    public void Affect()
    {
        ball = GameObject.Find("VectorBall");
        for (int i = 0 ; i < 2; i++)
        {
			GameObject ball1 = ResourceManager.Instantiate("VectorBall");
            Game.Instance.GameManager.Life++;
            ball1.transform.position = ball.transform.position;
		}
    }
	public IEnumerator Applying(float delay)
	{
		yield return new WaitForSeconds(delay);
	}
}
