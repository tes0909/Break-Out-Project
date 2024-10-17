using System;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class UI_StageLevelButton : UI_SubItem
{
	[SerializeField] private TMP_Text _text;

	private SceneChange _sceneChanger;
	private difficultyLevel _difficultyLevel;
	private bool _isclicked;
	public void Awake()
	{
		_sceneChanger = GameManager.Instance.gameObject.GetComponent<SceneChange>();
	}

	public void Start()
	{
		_isclicked = false;
		Button click = gameObject.GetComponent<Button>();
		click.onClick.AddListener(OpenStage);
	}

	public override void Init(int index)
	{
		_difficultyLevel = (difficultyLevel)index;
		_text.text = _difficultyLevel.ToString();
	}

	private void OpenStage()
	{
		if (!_isclicked)
		{
			_isclicked = true;
			GameManager.Instance.SetDifficultyLevel(_difficultyLevel);
			_sceneChanger.ChangeScene(SceneName.InGame);
		}
	}
}