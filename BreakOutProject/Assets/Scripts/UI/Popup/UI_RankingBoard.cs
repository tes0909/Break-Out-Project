using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_RankingBoard : MonoBehaviour
{
	[SerializeField] private Button _background;
	[SerializeField] private Transform _RankingLayout;

	public void Awake()
	{
		_background.onClick.AddListener(CloseThisPopUP);

	}
	public void CreateRanking()
	{
	}

	private void CloseThisPopUP()
	{
		UIManager.Instance.ClosePopUpUI("RankingBoardUI");
	}
}
