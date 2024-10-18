using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Menu : UI_Popup
{
	[SerializeField] private Button _background;
	[SerializeField] private Button _gameQuitButton;
	[SerializeField] private Slider _bgmSlider;
	[SerializeField] private Slider _sfxSlider;
	[SerializeField] private Button _bgmOnOffButton;
	[SerializeField] private Image _bgmOnImage;
	[SerializeField] private Button _sfxOnOffButton;
	[SerializeField] private Image _sfxOnImage;
	[SerializeField] private Transform _bgmSelectLayout;


	public void Awake()
	{
		_background.onClick.AddListener(CloseThisPopUp);
		_gameQuitButton.onClick.AddListener(OpenGameQuitUI);
		_bgmSlider.onValueChanged.AddListener(Game.Instance.SoundManager.SetBGMVolume);
		_sfxSlider.onValueChanged.AddListener(Game.Instance.SoundManager.SetSFXVolume);
		_bgmOnImage.gameObject.SetActive(Game.Instance.SoundManager.BGMOnOff);
		_sfxOnImage.gameObject.SetActive(Game.Instance.SoundManager.SFXOnOff);
		_bgmOnOffButton.onClick.AddListener(BGMOnOff);
		_sfxOnOffButton.onClick.AddListener(SFXOnOff);
		CreateSoundSelectButton();
	}

	public void CreateSoundSelectButton()
	{
		int size = Game.Instance.SoundManager.BGM_Clips.Length;
		for(int i = 0; i < size; i++)
		{
			UI_SubItem item = Game.Instance.UiManager.CreateSubItemUI("SoundSelectButton", _bgmSelectLayout);
			item.Init(i);
		}
	}
	public void BGMOnOff()
	{
		Game.Instance.SoundManager.SetBGMOnOff();
		_bgmOnImage.gameObject.SetActive(Game.Instance.SoundManager.BGMOnOff);
	}
	public void SFXOnOff()
	{
		Game.Instance.SoundManager.SetSFXOnOff();
		_sfxOnImage.gameObject.SetActive(Game.Instance.SoundManager.SFXOnOff);

	}

	public void CloseThisPopUp()
	{
		Game.Instance.UiManager.ClosePopUpUI("MenuUI");
	}
	public void OpenGameQuitUI()
	{
		Game.Instance.UiManager.OpenPopUpUI("GameQuitUI");
	}
	public override void Close()
	{
		base.Close();
	}
}
