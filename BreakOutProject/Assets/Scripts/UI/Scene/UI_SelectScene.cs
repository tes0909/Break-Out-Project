using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_SelectScene : UI_Scene
{
	[SerializeField] private Transform _buttonLayout;
	[SerializeField] private GameObject _rankingButton;
	[SerializeField] private GameObject _menuButton;

	public void Awake()
	{
		CreateLevelButtons();
		UI_ClickHandler handler = _rankingButton.AddComponent<UI_ClickHandler>();
		handler.OnClickEvent += OpenRankingUI;
	}

	public void CreateLevelButtons()
	{
		for(int i = 0; i < (int)difficultyLevel.end; i++)
		{
			UI_StageLevelButton button = UIManager.Instance.CreateSubItemUI("StageLevelButton", _buttonLayout) as UI_StageLevelButton;
			button.Init(i);
		}
	}

	public void OpenRankingUI(PointerEventData data)
	{
		UIManager.Instance.OpenPopUpUI("RankingBoardUI");
	}
}
