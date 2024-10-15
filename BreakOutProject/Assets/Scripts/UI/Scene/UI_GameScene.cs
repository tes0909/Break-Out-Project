using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_GameScene : UI_Scene
{
	[SerializeField] private TMP_Text _timerText;
	[SerializeField] private TMP_Text _nowScoreText;
	[SerializeField] private TMP_Text _highScoreText;

	public override void Init()
	{
		base.Init();
	}
	public void UpdateTimerText(float time)
	{
		_timerText.text = time.ToString("D2");
	}
	public void NowScoreText(int score)
	{
		_nowScoreText.text = score.ToString();
	}
	public void HighScoreText(int highscore)
	{
		_highScoreText.text = highscore.ToString();
	}
}
