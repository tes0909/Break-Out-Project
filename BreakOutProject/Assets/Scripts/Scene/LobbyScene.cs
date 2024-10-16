using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
	protected override void Awake()
	{
		base.Awake();
		UIManager.Instance.OpenSceneUI("LobbySceneUI");
	}
	protected override void Close()
	{
		
	}
}
