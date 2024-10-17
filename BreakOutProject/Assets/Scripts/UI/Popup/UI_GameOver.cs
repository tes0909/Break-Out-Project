using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameOver : UI_Popup
{
	[SerializeField] private TMP_Text _nowScroeText;
	[SerializeField] private TMP_Text _HighScoreText;
	[SerializeField] private Button _restartButton;

	public void Start()
	{
		_restartButton.onClick.AddListener(Restart);
	}
	public override void Init()
	{
		base.Init();
	}
	public void Restart()
	{
		UIManager.Instance.ClosePopUpUI("GameOverUI");
		Response();
	}
	public override void Close()
	{
		base.Close();
	}
}
