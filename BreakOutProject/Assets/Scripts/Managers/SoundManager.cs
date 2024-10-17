using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager SoundInstance { get; set; }

    [Header("Audio Sources")]
    public AudioSource BGMSource; // ������� AudioSource
    public AudioSource SFXSource; // ȿ������ AudioSource

    public AudioClip[] BGM_Clips; // �� ���� �´� ����� Ŭ�� �迭
    public AudioClip[] SFX_Clips; // �� ���� �´� ȿ���� Ŭ�� �迭
    AudioSource[] audioSources;

    private int CurrentBGMIndex = 0; // ���� ��� ���� ������� �ε���
    public bool BGMOnOff = true;
    public bool SFXOnOff = true;

    private void Awake()
    {
        if (SoundInstance != null && SoundInstance != this)
        {
            Destroy(gameObject);
            return;

        }

        SoundInstance = this;
        DontDestroyOnLoad(gameObject);

        // �ڽ� ������Ʈ���� AudioSource ��������
        audioSources = GetComponentsInChildren<AudioSource>();
        BGMSource = audioSources[0];
        SFXSource = audioSources[1];
    }
    public void SetBGMVolume(float volume)
    {
        if (audioSources.Length > 0)
        {
            audioSources[0].volume = Mathf.Clamp01(volume); // BGM ���� ����
        }
    }

    public void SetSFXVolume(float volume)
    {
        if (audioSources.Length > 1)
        {
            audioSources[1].volume = Mathf.Clamp01(volume); // SFX ���� ����
        }
    }
    public void Start()
    {
        PlayBGM();
    }

    public void PlayBGM()
    {
        if (!BGMOnOff) return; // BGM�� ���� ������ ������� ����

        if (BGMSource.isPlaying)
            BGMSource.Stop();
        BGMSource.clip = BGM_Clips[CurrentBGMIndex];
        BGMSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (SFXOnOff)
        {
        SFXSource.PlayOneShot(clip); // ȿ���� ���
        }
    }

    public void SelectBGM(int index)
    {
        if (index >= 0 && index < BGM_Clips.Length)
        {
            CurrentBGMIndex = index; // ���õ� �ε����� ����
        }
    }
    public void SetBGMOnOff()
    {
        if (BGMOnOff == false)
        {
            BGMSource.Stop();
            BGMOnOff = true; // BGM �ѱ�
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
}