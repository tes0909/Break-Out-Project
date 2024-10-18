using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SoundSelectButton : UI_SubItem
{
	[SerializeField] private TMP_Text _text;
	[SerializeField] private Button _button;

	private int _index;
	public override void Init(int index)
	{
		base.Init(index);
		_text.text = $"{index}¹ø BGM";
		_index = index;
		_button.onClick.AddListener(SelectBGM);
	}
	public void SelectBGM()
	{
		Game.Instance.SoundManager.SelectBGM(_index);
		Game.Instance.SoundManager.PlayBGM();
	}
}
