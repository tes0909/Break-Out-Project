using System.Collections;
using UnityEngine;

public class MultiBall : IItemEffect
{
    private GameObject ball;
    public Color color { get; set; } = Color.white;
    public MultiBall()
    {
        ball = GameObject.Find("VectorBall");
    }
    public void Affect()
    {
        for(int i = 0 ; i < 2; i++)
        {
			GameObject ball1 = ResourceManager.Instantiate("VecterBall");
            Game.Instance.GameManager.Life++;
		}
    }
	public IEnumerator Applying(float delay)
	{
		yield return new WaitForSeconds(delay);
	}
}
