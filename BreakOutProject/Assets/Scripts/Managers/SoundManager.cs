using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [Header("Audio Sources")]
     AudioSource BGMSource; // 배경음용 AudioSource
     AudioSource SFXSource; // 효과음용 AudioSource

    public AudioClip[] BGM_Clips; // 각 씬에 맞는 배경음 클립 배열
    public AudioClip[] SFX_Clips; // 각 씬에 맞는 효과음 클립 배열
    AudioSource[] audioSources;

    private int CurrentBGMIndex = 0; // 현재 재생 중인 배경음의 인덱스
    public bool BGMOnOff = true;
    public bool SFXOnOff = true;


    private void Awake()
    {
        // 자식 오브젝트에서 AudioSource 가져오기
        audioSources = GetComponentsInChildren<AudioSource>();
        BGMSource = audioSources[0];
        SFXSource = audioSources[1];
    }
    public void Start()
    {
        PlayBGM();
    }

    public void PlayBGM()
    {
        if (!BGMOnOff) return; // BGM이 꺼져 있으면 재생하지 않음

        if (BGMSource.isPlaying)
            BGMSource.Stop();
        BGMSource.clip = BGM_Clips[CurrentBGMIndex];
        BGMSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (SFXOnOff)
        {
        SFXSource.PlayOneShot(clip); // 효과음 재생
        }
    }

    public void SelectBGM(int index)
    {
        if (index >= 0 && index < BGM_Clips.Length)
        {
            CurrentBGMIndex = index; // 선택된 인덱스로 변경
        }
        SetBGMOnOff();//키고
        SetBGMOnOff();//끄기
    }
    public void SetBGMOnOff()
    {
        if (BGMOnOff == false)
        {
            BGMSource.Stop();
            BGMOnOff = true; // BGM 켜기
           PlayBGM();
        }
        else if (BGMOnOff == true)
        {
           BGMSource.Stop();
            BGMOnOff = false;
        }
    }
    public void SetSFXOnOff()
    {
        if (SFXOnOff == false)
        {
            SFXOnOff = true;
        }
        else if (SFXOnOff == true)
        {
            SFXOnOff = false;
        }
    }

    public void SetBGMVolume(float volume)
    {
        BGMSource.GetComponent<BGMSoundVolume>().UpdateSoundVolume(volume);
    }
    public void SetSFXVolume(float volume)
    {
        SFXSource.GetComponent<SFXSoundVolume>().UpdateSoundVolume(volume);
    }
}