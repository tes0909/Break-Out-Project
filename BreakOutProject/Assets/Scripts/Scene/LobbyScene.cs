using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
	protected override void Awake()
	{
		base.Awake();
		//InitGameManager();
		GameObject go = ResourceManager.Instantiate("@GameManager");
		go.name = "@GameManager";
		Game.Instance.UiManager.OpenSceneUI("LobbySceneUI");
	}

	protected override void Close()
	{
		
	}
}
