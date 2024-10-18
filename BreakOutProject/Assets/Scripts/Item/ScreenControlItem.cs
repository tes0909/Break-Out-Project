using System.Collections;
using UnityEngine;

public class ScreenControlItem : test.Item
{
	private string[] BlackoutEffects = { "ItemEffect/BlackOutUI", "ItemEffect/HalfBlackOutUI" };
	private int index = -1;
	public override void Spawn(Vector2 position, float duration, float speed)
	{
		base.Spawn(position, duration, speed);
		index = Random.Range(0, BlackoutEffects.Length);
	}
	protected override void Affect()
	{
		index = Random.Range(0, BlackoutEffects.Length);
		Game.Instance.UiManager.OpenPopUpUI(BlackoutEffects[index]);;
		Invoke("Applying", _duration);
	}

	protected override void Applying()
	{
		Game.Instance.UiManager.ClosePopUpUI(BlackoutEffects[index]);
	}
}
