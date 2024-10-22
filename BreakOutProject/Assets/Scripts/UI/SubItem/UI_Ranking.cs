using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Ranking : UI_SubItem
{
	[SerializeField] private TMP_Text _text;

	public override void Init(int index)
	{
		base.Init(index);
		if (ScoreboardManager.Instance.Scores.Count > index) { }
			_text.text = ScoreboardManager.Instance.Scores[index].ToString();
	}
}
