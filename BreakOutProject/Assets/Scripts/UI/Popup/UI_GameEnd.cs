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
	}

	public void OnEnable()
	{
		_nowScroeText.text = Game.Instance.GameManager.Score.ToString();
		_HighScoreText.text = ScoreboardManager.Instance.Scores[0].ToString();
	}
    public override void Reject()
	{
		base.Reject();
		Game.Instance.gameObject.GetComponent<SceneChange>().ChangeScene(SceneName.SelectMode);
	}
}
