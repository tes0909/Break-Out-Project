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
		Game.Instance.UiManager.ClosePopUpUI();
		OnResponseEvent?.Invoke();
		Debug.Log("왜 팝업이 안닫히는 거에요");
	}
	public virtual void Reject()
	{
		Game.Instance.UiManager.ClosePopUpUI();
		OnRejectEvent?.Invoke();
	}
	public virtual void Close()
	{
		gameObject.SetActive(false);
	}
}
