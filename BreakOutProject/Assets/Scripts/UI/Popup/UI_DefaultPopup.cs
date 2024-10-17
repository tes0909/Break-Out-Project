using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_DefaultPopup : UI_Popup
{
	[SerializeField] private TMP_Text _text;
	[SerializeField] private Button _background;
	[SerializeField] private Button _yesButton;
	[SerializeField] private Button _noButton;

	public void Awake()
	{
		_background.onClick.AddListener(CloseThisUI);
		_yesButton.onClick.AddListener(Response);
		_noButton.onClick.AddListener(CloseThisUI);
	}

	public void Init(string text,Action action)
	{
		base.Init(action);
		_text.text = text;
	}

	private void CloseThisUI()
	{
		UIManager.Instance.ClosePopUpUI("GameQuitUI");
	}
}
