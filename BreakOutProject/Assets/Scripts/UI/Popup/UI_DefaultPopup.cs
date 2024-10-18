using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UI_DefaultPopup : UI_Popup
{
	[SerializeField] protected TMP_Text _text;
	[SerializeField] protected Button _background;
	[SerializeField] protected Button _yesButton;
	[SerializeField] protected Button _noButton;

	public virtual void Awake()
	{
		_yesButton.onClick.AddListener(Response);
		_background.onClick.AddListener(Reject);
		_noButton.onClick.AddListener(Reject);
	}
	public virtual void Init(string text, Action Yesaction)
	{
		base.Init(Yesaction);
		_text.text = text;
	}

	public virtual void Init(string text,Action Yesaction, Action NoAction)
	{
		base.Init(Yesaction, NoAction);
		_text.text = text;
	}
}
