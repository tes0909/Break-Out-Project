using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_LobbyScene : UI_Scene
{
	[SerializeField] private GameObject _background;

	private void Awake()
	{
		UI_ClickHandler backgroundClick = _background.AddComponent<UI_ClickHandler>();
		backgroundClick.OnClickEvent += LoadGameScene;
	}

	private void LoadGameScene(PointerEventData data)
	{
		Debug.Log("clicked");
		SceneChange.ChangeScene(SceneName.InGame);
	}
}
