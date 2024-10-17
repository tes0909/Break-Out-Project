using System;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine;

public class UI_StageLevelButton : UI_SubItem
{
	[SerializeField] private TMP_Text _text;

	private SceneChange _sceneChanger;
	private difficultyLevel _difficultyLevel;
	public void Awake()
	{
		_sceneChanger = GameManager.Instance.gameObject.GetComponent<SceneChange>();
	}

	public void Start()
	{
		UI_ClickHandler click = gameObject.AddComponent<UI_ClickHandler>();
		click.OnClickEvent += OpenStage;
	}

	public override void Init(int index)
	{
		_difficultyLevel = (difficultyLevel)index;
		_text.text = _difficultyLevel.ToString();
	}

	private void OpenStage(PointerEventData data)
	{
		// TODO : GameManager등에 difficulty레벨을 설정해주는 함수
		_sceneChanger.ChangeScene(SceneName.InGame);
	}
}