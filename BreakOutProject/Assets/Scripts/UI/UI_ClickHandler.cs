using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_ClickHandler : MonoBehaviour, IPointerClickHandler
{
	public event Action<PointerEventData> OnClickEvent;
	public void OnPointerClick(PointerEventData eventData)
	{
		OnClickEvent?.Invoke(eventData);
	}
}
