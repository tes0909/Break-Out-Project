using System.Collections;
using UnityEngine;

public class TimeControl : IItemEffect
{
	private float _controlTime;
	public float _duration=5f;
    public Color color { get; set; } = Color.white;
    public TimeControl()
    {
        _controlTime = Random.Range(0.5f, 1.5f);

		switch(_controlTime)
		{
			case <1f:
				color = Color.blue;
				break;

            case >= 1f:
				color = Color.red;
                break;
        }
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
