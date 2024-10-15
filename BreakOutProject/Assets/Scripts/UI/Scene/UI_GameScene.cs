using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_GameScene : UI_Scene
{
	[SerializeField] private TMP_Text _timerText;
	[SerializeField] private TMP_Text _nowScoreText;
	[SerializeField] private TMP_Text _highScoreText;
	[SerializeField] private Transform _lifeLayout;

	private List<UI_LifeIcon> _lifeIcons;
	private int _lifeCount;

	public override void Init()
	{
		base.Init();
		CreateLife();
	}
	private void CreateLife()
	{
		//Todo gamemanager���� �ִ� hp��������
		_lifeCount = 3;
		if(_lifeIcons == null || _lifeIcons.Count == 0)
		{
			_lifeIcons = new List<UI_LifeIcon>();
			for (int i = 0; i < _lifeCount; i++)
			{
				_lifeIcons.Add((UI_LifeIcon)UIManager.Instance.CreateSubItemUI("LifeIcon", _lifeLayout));
			}
			return;
		}
		for(int i = 0; i < _lifeCount; ++i)
		{
			_lifeIcons[i].gameObject.SetActive(true);
		}

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
	public void UpdateLife()
	{
		_lifeIcons[_lifeCount].gameObject.SetActive(false);
		_lifeCount--;

	}

}
