using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EnterHandler : MonoBehaviour, IPointerEnterHandler
{
	public event Action<PointerEventData> OnEnterEvent;

	public void OnPointerEnter(PointerEventData eventData)
	{
		OnEnterEvent?.Invoke(eventData);
	}
}
