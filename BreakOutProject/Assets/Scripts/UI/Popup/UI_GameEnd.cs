using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameEnd : UI_DefaultPopup
{
	[SerializeField] private TMP_Text _nowScroeText;
	[SerializeField] private TMP_Text _HighScoreText;

	public override void Awake()
	{
		base.Awake();
		_nowScroeText.text = Game.Instance.GameManager.Score.ToString();
		_HighScoreText.text = ScoreboardManager.Instance.HighScore.ToString();
	}

	public override void Reject()
	{
		base.Reject();
		Game.Instance.gameObject.GetComponent<SceneChange>().ChangeScene(SceneName.SelectMode);
		Debug.Log("À¸¿¨ ");
	}
	public override void Close()
	{
		base.Close();
	}
}
