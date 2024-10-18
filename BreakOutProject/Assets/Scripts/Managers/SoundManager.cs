using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [Header("Audio Sources")]
     AudioSource BGMSource; // ������� AudioSource
     AudioSource SFXSource; // ȿ������ AudioSource

    public AudioClip[] BGM_Clips; // �� ���� �´� ����� Ŭ�� �迭
    public AudioClip[] SFX_Clips; // �� ���� �´� ȿ���� Ŭ�� �迭
    AudioSource[] audioSources;

    private int CurrentBGMIndex = 0; // ���� ��� ���� ������� �ε���
    public bool BGMOnOff = true;
    public bool SFXOnOff = true;


    private void Awake()
    {
        // �ڽ� ������Ʈ���� AudioSource ��������
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
        SetBGMOnOff();//Ű��
        SetBGMOnOff();//����
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

    public void SetBGMVolume(float volume)
    {
        BGMSource.GetComponent<BGMSoundVolume>().UpdateSoundVolume(volume);
    }
    public void SetSFXVolume(float volume)
    {
        SFXSource.GetComponent<SFXSoundVolume>().UpdateSoundVolume(volume);
    }
}