using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_SelectScene : UI_Scene
{
	[SerializeField] private Transform _buttonLayout;
	[SerializeField] private Button _rankingButton;
	[SerializeField] private GameObject _menuButton;

	public void Awake()
	{
		CreateLevelButtons();
		_rankingButton.onClick.AddListener(OpenRankingUI);
	}

	public void CreateLevelButtons()
	{
		for(int i = 0; i < (int)difficultyLevel.end; i++)
		{
			UI_StageLevelButton button = UIManager.Instance.CreateSubItemUI("StageLevelButton", _buttonLayout) as UI_StageLevelButton;
			button.Init(i);
		}
	}

	public void OpenRankingUI()
	{
		UIManager.Instance.OpenPopUpUI("RankingBoardUI");
	}
}
