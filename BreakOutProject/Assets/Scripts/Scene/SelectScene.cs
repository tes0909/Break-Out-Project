using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectScene : BaseScene
{
	protected override void Awake()
	{
		base.Awake();
		Game.Instance.UiManager.OpenSceneUI("SelectSceneUI");
	}
	protected override void Close()
	{
	}
}
