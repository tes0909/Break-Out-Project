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
		_bgmSlider.onValueChanged.AddListener(SoundManager.SoundInstance.SetBGMVolume);
		_sfxSlider.onValueChanged.AddListener(SoundManager.SoundInstance.SetSFXVolume);
		_bgmOnImage.gameObject.SetActive(SoundManager.SoundInstance.BGMOnOff);
		_sfxOnImage.gameObject.SetActive(SoundManager.SoundInstance.SFXOnOff);
		_bgmOnOffButton.onClick.AddListener(BGMOnOff);
		_sfxOnOffButton.onClick.AddListener(SFXOnOff);
		CreateSoundSelectButton();
	}

	public void CreateSoundSelectButton()
	{
		int size = SoundManager.SoundInstance.BGM_Clips.Length;
		for(int i = 0; i < size; i++)
		{
			UI_SubItem item = UIManager.Instance.CreateSubItemUI("SoundSelectButton", _bgmSelectLayout);
			item.Init(i);
		}
	}
	public void BGMOnOff()
	{
		SoundManager.SoundInstance.SetBGMOnOff();
		_bgmOnImage.gameObject.SetActive(SoundManager.SoundInstance.BGMOnOff);
	}
	public void SFXOnOff()
	{
		SoundManager.SoundInstance.SetSFXOnOff();
		_sfxOnImage.gameObject.SetActive(SoundManager.SoundInstance.SFXOnOff);

	}

	public void CloseThisPopUp()
	{
		UIManager.Instance.ClosePopUpUI("MenuUI");
	}
	public void OpenGameQuitUI()
	{
		UIManager.Instance.OpenPopUpUI("GameQuitUI");
	}
	public override void Close()
	{
		base.Close();
	}
}
