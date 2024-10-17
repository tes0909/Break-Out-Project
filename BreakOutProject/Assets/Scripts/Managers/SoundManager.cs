using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager SoundInstance { get; private set; }

    [Header("Audio Sources")]
    private AudioSource BGMSource; // ������� AudioSource
    private AudioSource SFXSource; // ȿ������ AudioSource

    public AudioClip[] BGM_Clips; // �� ���� �´� ����� Ŭ�� �迭
    public AudioClip[] SFX_Clips; // �� ���� �´� ȿ���� Ŭ�� �迭

    private int CurrentBGMIndex = 0; // ���� ��� ���� ������� �ε���
    private bool BGMOnOff = true;
    private bool SFXOnOff = true;
    [Range(0f, 1f)]
    public float BGMVolume = 1f; // �⺻ ���� ����
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

        // �ڽ� ������Ʈ���� AudioSource ��������
        AudioSource[] audioSources = GetComponentsInChildren<AudioSource>();
        BGMSource = audioSources[0];
        SFXSource = audioSources[1];
    }

    public void Start()
    {
        BGMVolume = PlayerPrefs.GetFloat("BGMVolume", 1f); // ����� BGM ���� ��������
        SFXVolume = PlayerPrefs.GetFloat("SFXVolume", 1f); // ����� SFX ���� ��������

        PlayBGM();
        PlaySFX(SFX_Clips[2]);
        PlaySFX(SFX_Clips[3]);

    }

    public void PlayBGM()
    {
        if (!BGMOnOff) return; // BGM�� ���� ������ ������� ����

        if (BGMSource.isPlaying)
            BGMSource.Stop();
        BGMSource.clip = BGM_Clips[CurrentBGMIndex];
        BGMSource.Play();
    }

    public void SelectBGM(int index)
    {
        if (index >= 0 && index < BGM_Clips.Length)
        {
            CurrentBGMIndex = index; // ���õ� �ε����� ����
        }
    }

    public void BGMLoopOnOff()
    {
        BGMSource.loop = !BGMSource.loop; // ���� ���� ��ȯ
    }
    public void PlayBGMOnOff()
    {
        if(BGMOnOff== false)
        {
            BGMSource.Stop();
            BGMOnOff = true; // BGM �ѱ�
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
        SFXSource.PlayOneShot(clip); // ȿ���� ���
        }
    }
    public void SlideBGMChanged(float value)
    {
        BGMVolume = value; // BGM ���� ����
        PlayerPrefs.SetFloat("BGMVolume", BGMVolume); // ���� ����
        
    }

    public void SlideSFXChanged(float value)
    {
        SFXVolume = value; // SFX ���� ����
        PlayerPrefs.SetFloat("SFXVolume", SFXVolume); // ���� ����

    }
}