using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_CountDown : UI_Popup
{
	[SerializeField] private TMP_Text text;

	private const int START_DELAY =  3;
	private WaitForSecondsRealtime waittime = new WaitForSecondsRealtime(1f);
	private void OnEnable()
	{
		StartCoroutine(StartCountdown());
	}
	private IEnumerator StartCountdown()
	{
		int remainTime = START_DELAY;
		while (remainTime > 0)
		{
			text.text = remainTime.ToString();
			yield return new WaitForSecondsRealtime(1f);
			remainTime--;
		}
		Game.Instance.UiManager.ClosePopUpUI();
	}
}
