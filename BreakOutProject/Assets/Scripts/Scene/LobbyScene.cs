using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
	protected override void Awake()
	{
		base.Awake();
		InitGameManager();
		UIManager.Instance.OpenSceneUI("LobbySceneUI");
	}

	private void InitGameManager()
	{
		GameObject gameManager = new GameObject("@GameManager");
		gameManager.AddComponent<GameManager>();
		gameManager.AddComponent<SceneChange>();
	}

	protected override void Close()
	{
		
	}
}
