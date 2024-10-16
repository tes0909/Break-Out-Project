using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Audio Sources")]
    public AudioSource bgmSource; // 배경음용 AudioSource
    public AudioSource sfxSource; // 효과음용 AudioSource

    private void Awake()
    {
        if(Instance !=null && Instance !=this)//첫번째는 싱글톤이고 두번째는 중복생성 방지용
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
        bgmSource.loop = true; // 배경음은 반복 재생
        bgmSource.Play();
    }
    public void PlaySFX(AudioClip audioClip)
    {
        sfxSource.PlayOneShot(audioClip); // 효과음은 한 번만 재생
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
