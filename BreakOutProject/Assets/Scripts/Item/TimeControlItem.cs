using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControlItem : test.Item
{
	private float _controlTime;
	public override void Spawn(Vector2 position, float duration ,float speed)
	{
		base.Spawn(position, duration, speed);
		_controlTime = Random.Range(0f, 1.5f);
		if(_controlTime < 0.01f)
		{
			_controlTime = 0f;
			_spriteRenderer.color = Color.blue;
		}
		else if(_controlTime < 1f)
		{
			_spriteRenderer.color = Color.white;
		}
		else
		{
			_spriteRenderer.color = Color.red;
		}
	}
	// TimeManager에서 Queue로 시간 관리하게 변경
	protected override void Affect()
	{
		Time.timeScale = _controlTime;
		Invoke("Applying", _duration);
	}
	protected override void Applying()
	{
		Time.timeScale = 1f;
	}
}
