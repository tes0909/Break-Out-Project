using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Audio Sources")]
    public AudioSource bgmSource; // ������� AudioSource
    public AudioSource sfxSource; // ȿ������ AudioSource

    private void Awake()
    {
        if(Instance !=null && Instance !=this)//ù��°�� �̱����̰� �ι�°�� �ߺ����� ������
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayBGM(AudioClip audioClip)
    {
        if (bgmSource.isPlaying)
            bgmSource.Stop();

        bgmSource.clip = audioClip;
        bgmSource.loop = true; // ������� �ݺ� ���
        bgmSource.Play();
    }
    public void PlaySFX(AudioClip audioClip)
    {
        sfxSource.PlayOneShot(audioClip); // ȿ������ �� ���� ���
    }

    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
