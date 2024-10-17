using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager SoundInstance { get; private set; }

    [Header("Audio Sources")]
    private AudioSource BGMSource; // 배경음용 AudioSource
    private AudioSource SFXSource; // 효과음용 AudioSource

    public AudioClip[] BGM_Clips; // 각 씬에 맞는 배경음 클립 배열
    public AudioClip[] SFX_Clips; // 각 씬에 맞는 효과음 클립 배열

    private int CurrentBGMIndex = 0; // 현재 재생 중인 배경음의 인덱스
    private bool BGMOnOff = true;
    private bool SFXOnOff = true;
    [Range(0f, 1f)]
    public float BGMVolume = 1f; // 기본 볼륨 설정
    [Range(0f, 1f)]
    public float SFXVolume = 1f;

    private void Awake()
    {
        if (SoundInstance != null && SoundInstance != this)
        {
            Destroy(gameObject);
            return;
        }

        SoundInstance = this;
        DontDestroyOnLoad(gameObject);

        // 자식 오브젝트에서 AudioSource 가져오기
        AudioSource[] audioSources = GetComponentsInChildren<AudioSource>();
        BGMSource = audioSources[0];
        SFXSource = audioSources[1];
    }

    public void Start()
    {
        BGMVolume = PlayerPrefs.GetFloat("BGMVolume", 1f); // 저장된 BGM 볼륨 가져오기
        SFXVolume = PlayerPrefs.GetFloat("SFXVolume", 1f); // 저장된 SFX 볼륨 가져오기

        PlayBGM();
        PlaySFX(SFX_Clips[2]);
        PlaySFX(SFX_Clips[3]);

    }

    public void PlayBGM()
    {
        if (!BGMOnOff) return; // BGM이 꺼져 있으면 재생하지 않음

        if (BGMSource.isPlaying)
            BGMSource.Stop();
        BGMSource.clip = BGM_Clips[CurrentBGMIndex];
        BGMSource.Play();
    }

    public void SelectBGM(int index)
    {
        if (index >= 0 && index < BGM_Clips.Length)
        {
            CurrentBGMIndex = index; // 선택된 인덱스로 변경
        }
    }

    public void BGMLoopOnOff()
    {
        BGMSource.loop = !BGMSource.loop; // 루프 상태 전환
    }
    public void PlayBGMOnOff()
    {
        if(BGMOnOff== false)
        {
            BGMSource.Stop();
            BGMOnOff = true; // BGM 켜기
            PlayBGM();
        }
        else if(BGMOnOff == true)
        {
            BGMSource.Stop();
            BGMOnOff = false;
        }
    }
    public void PlaySFXOnOff()
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
    public void PlaySFX(AudioClip clip)
    {
        if (SFXOnOff)
        {
        SFXSource.PlayOneShot(clip); // 효과음 재생
        }
    }
    public void SlideBGMChanged(float value)
    {
        BGMVolume = value; // BGM 볼륨 설정
        PlayerPrefs.SetFloat("BGMVolume", BGMVolume); // 볼륨 저장
        
    }

    public void SlideSFXChanged(float value)
    {
        SFXVolume = value; // SFX 볼륨 설정
        PlayerPrefs.SetFloat("SFXVolume", SFXVolume); // 볼륨 저장

    }
}