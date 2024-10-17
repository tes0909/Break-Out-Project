using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSoundVolume : MonoBehaviour
{
    AudioSource audioSource;
    [Range(0f, 1f)]
    public float AudioVolume;
    private void Start()
    {
        AudioVolume = PlayerPrefs.GetFloat("SFXVolume", 1f); // ����� ���� ��������
        audioSource = GetComponent<AudioSource>();
        if(SoundManager.SoundInstance!= null)
        {
            SFXSlideChanged(SoundManager.SoundInstance.SFXSize);
        }
    }
    public void SFXSlideChanged(float value)
    {
        AudioVolume = value; // �����̴� ������ AudioVolume ������Ʈ
        PlayerPrefs.SetFloat("SFXVolume", AudioVolume); // ���� ����
        audioSource.volume = AudioVolume; // AudioSource�� ���� ����
        SoundManager.SoundInstance.SFXSize = value;
        Debug.Log(SoundManager.SoundInstance.SFXSize);
    }
}
