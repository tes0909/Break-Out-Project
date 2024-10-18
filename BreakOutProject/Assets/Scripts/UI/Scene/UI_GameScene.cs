using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UI_GameScene : UI_Scene
{
	[SerializeField] private TMP_Text _timerText;
	[SerializeField] private TMP_Text _nowScoreText;
	[SerializeField] private TMP_Text _highScoreText;
	[SerializeField] private Transform _lifeLayout;

	private List<UI_LifeIcon> _lifeIcons;
	private int _lifeCount;

	private void Awake()
	{
		CreateLife();
		Game.Instance.GameManager.OnLifeChanged += UpdateLife;
		Game.Instance.GameManager.OnScoreChanged += NowScoreText;

		if(ScoreboardManager.Instance.Scores.Count > 0 && ScoreboardManager.Instance.Scores !=null)
			_highScoreText.text = ScoreboardManager.Instance.Scores[0].ToString();

		Game.Instance.gameObject.GetComponent<TimeManager>().OnChangeTime += UpdateTimerText;
	}

	private void CreateLife()
	{
		//Todo gamemanager에서 최대 hp가져오기
		int _lifeCount = Game.Instance.GameManager.Life;
		if(_lifeIcons == null || _lifeIcons.Count == 0)
		{
			_lifeIcons = new List<UI_LifeIcon>();
			for (int i = 0; i < _lifeCount; i++)
			{
				_lifeIcons.Add((UI_LifeIcon)Game.Instance.UiManager.CreateSubItemUI("LifeIcon", _lifeLayout));
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
		_timerText.text = time.ToString("F2");
	}

	public void NowScoreText(int score)
	{
		_nowScoreText.text = score.ToString();
	}

	public void UpdateLife(int life)
	{
		_lifeIcons[_lifeCount].gameObject.SetActive(false);
		_lifeCount = life;
	}

}
