using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
	protected override void Awake()
	{
		base.Awake();
		//InitGameManager();
		GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/@GameManager"));
		go.name = "@GameManager";
		UIManager.Instance.OpenSceneUI("LobbySceneUI");
	}

	private void InitGameManager()
	{
		GameObject gameManager = new GameObject("@GameManager");
		gameManager.AddComponent<GameManager>();
		gameManager.AddComponent<SceneChange>();
		gameManager.AddComponent<ScoreboardManager>();
	}

	protected override void Close()
	{
		
	}
}
