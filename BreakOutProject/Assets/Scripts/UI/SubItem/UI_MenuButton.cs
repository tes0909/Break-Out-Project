using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_MenuButton : UI_SubItem
{
	public void Awake()
	{
		UI_ClickHandler handler = gameObject.AddComponent<UI_ClickHandler>();
		handler.OnClickEvent += OpenMenuUI;
	}
	public void OpenMenuUI(PointerEventData eventData)
	{
		UIManager.Instance.OpenPopUpUI("MenuUI");
	}
}
