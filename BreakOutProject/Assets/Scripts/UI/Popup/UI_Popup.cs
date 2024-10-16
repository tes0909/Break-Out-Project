using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UI_Popup : MonoBehaviour
{
	public event Action OnResponseEvent;
	public virtual void Init() { }

	public virtual void Response() 
	{
		OnResponseEvent?.Invoke();
	}
	public virtual void Close()
	{
		gameObject.SetActive(false);
	}
}
