using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_LobbyScene : UI_Scene
{
	[SerializeField] private GameObject _background;

	private SceneChange sceneChange;
    private void Awake()
	{
		sceneChange = GameObject.Find("@GameManager").GetComponent<SceneChange>();
		UI_ClickHandler backgroundClick = _background.AddComponent<UI_ClickHandler>();
		backgroundClick.OnClickEvent += LoadSelectScene;
	}

	private void LoadSelectScene(PointerEventData data)
	{
		Debug.Log("clicked");
        sceneChange.ChangeScene(SceneName.SelectMode);
	}
}
