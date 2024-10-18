using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Popup : MonoBehaviour
{
	public event Action OnResponseEvent;
	public event Action OnRejectEvent;

	public virtual void Init(Action action)
	{
		OnResponseEvent += action;
	}
	public virtual void Init(Action action, Action rejectAction)
	{
		OnResponseEvent += action;
		OnRejectEvent += rejectAction;
	}

	public virtual void Response() 
	{
		OnResponseEvent?.Invoke();
		Game.Instance.UiManager.ClosePopUpUI();
	}
	public virtual void Reject()
	{
		OnRejectEvent?.Invoke();
		Game.Instance.UiManager.ClosePopUpUI();
	}
	public virtual void Close()
	{
		gameObject.SetActive(false);
	}
}
