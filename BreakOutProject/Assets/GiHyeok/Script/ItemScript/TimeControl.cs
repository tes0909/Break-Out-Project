using System.Collections;
using UnityEngine;

public class TimeControl : IItemEffect
{
	private float _controlTime;
	public float _duration=5f;
    public TimeControl()
    {
        _controlTime = Random.Range(0.5f, 1.5f);
    }
    public void Affect()
	{
        Time.timeScale = _controlTime;
		Game.Instance.StartCoroutine(Applying(_duration));
    }
	public IEnumerator Applying(float delay)
	{
		yield return new WaitForSeconds(delay);
		Time.timeScale = 1f;
	}
}
