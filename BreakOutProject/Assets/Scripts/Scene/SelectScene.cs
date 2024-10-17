using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectScene : BaseScene
{
	protected override void Awake()
	{
		base.Awake();
		GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI/Scene/SelectSceneUI"));
	}
	protected override void Close()
	{
	}
}
