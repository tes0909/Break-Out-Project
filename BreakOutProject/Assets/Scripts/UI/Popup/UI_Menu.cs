using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Menu : UI_Popup
{
	[SerializeField] private Button _background;
	[SerializeField] private Button _gameQuitButton;

	public void Awake()
	{
		_background.onClick.AddListener(CloseThisPopUp);
		_gameQuitButton.onClick.AddListener(OpenGameQuitUI);
	}
	
	public void CloseThisPopUp()
	{
		UIManager.Instance.ClosePopUpUI("MenuUI");
	}
	public void OpenGameQuitUI()
	{
		UIManager.Instance.OpenPopUpUI("GameQuitUI");
	}
	public override void Close()
	{
		base.Close();
	}
}
