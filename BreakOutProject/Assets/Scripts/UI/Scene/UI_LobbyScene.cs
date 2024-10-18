using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_LobbyScene : UI_Scene
{
	[SerializeField] private GameObject _background;

	private SceneChange sceneChange;
	private bool _isclicked;
    private void Awake()
	{
		_isclicked = false;
		sceneChange = GameObject.Find("@GameManager").GetComponent<SceneChange>();
		UI_ClickHandler backgroundClick = _background.AddComponent<UI_ClickHandler>();
		backgroundClick.OnClickEvent += LoadSelectScene;
	}

	private void LoadSelectScene(PointerEventData data)
	{
		if(_isclicked) return;
		_isclicked = true;
        sceneChange.ChangeScene(SceneName.SelectMode);
	}
}
