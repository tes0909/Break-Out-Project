using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_GameQuit : UI_Popup
{
	[SerializeField] private Button _background;
	[SerializeField] private Button _yesButton;
	[SerializeField] private Button _noButton;

	public void Awake()
	{
		_background.onClick.AddListener(CloseThisUI);
		_yesButton.onClick.AddListener(QuitGame);
		_noButton.onClick.AddListener(CloseThisUI);
	}

	private void QuitGame()
	{
		GameManager.Instance.QuitGame();
	}

	private void CloseThisUI()
	{
		UIManager.Instance.ClosePopUpUI("GameQuitUI");
	}
}
