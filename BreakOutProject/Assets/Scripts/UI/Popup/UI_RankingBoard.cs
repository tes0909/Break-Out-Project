using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_RankingBoard : UI_Popup
{
	[SerializeField] private Button _background;
	[SerializeField] private Transform _rankingLayout;

	public void Awake()
	{
		_background.onClick.AddListener(CloseThisPopUP);

	}
	public void CreateRanking()
	{
		int rankCount = ScoreboardManager.Instance.Scores.Count;
		for(int i = 0; i < rankCount; i++)
		{
			UI_SubItem ranking = Game.Instance.UiManager.CreateSubItemUI("Ranking", _rankingLayout);
			ranking.Init(i);
		}
	}

	private void CloseThisPopUP()
	{
		Game.Instance.UiManager.ClosePopUpUI();
	}
}
