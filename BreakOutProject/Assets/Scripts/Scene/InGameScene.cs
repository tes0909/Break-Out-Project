using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameScene : BaseScene
{
	protected override void Awake()
	{
		base.Awake();
		UIManager.Instance.OpenSceneUI("GameSceneUI");
	}

	protected override void Close()
	{
		return;
	}
}
