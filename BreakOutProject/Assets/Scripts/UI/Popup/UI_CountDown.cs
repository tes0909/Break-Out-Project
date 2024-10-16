using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_CountDown : UI_Popup
{
	[SerializeField] private TMP_Text text;

	private const int START_DELAY =  3;
	private WaitForSeconds waittime = new WaitForSeconds(1f);

	public override void Init()
	{
		base.Init();
		StartCoroutine(StartCountdown());

	}
	private IEnumerator StartCountdown()
	{
		int remainTime = START_DELAY;
		while (remainTime > 0)
		{
			text.text = remainTime.ToString();
			yield return waittime;
			remainTime--;
		}
		UIManager.Instance.ClosePopUpUI();
	}
}
