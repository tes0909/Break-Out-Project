using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_LobbyScene : UI_Scene
{
	[SerializeField] private GameObject _background;

	public override void Init()
	{
		base.Init();
		UI_ClickHandler backgroundClick = _background.AddComponent<UI_ClickHandler>();
		backgroundClick.OnClickEvent += LoadGameScene;

	}

	private void LoadGameScene(PointerEventData data)
	{
		// TODO. Scene Manager를 참조하여 GameScene으로 넘어가도록
	}

}
