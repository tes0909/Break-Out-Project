using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSoundVolume : MonoBehaviour
{
    AudioSource audioSource;
    [Range(0f, 1f)]
    public float AudioVolume;
    private void Start()
    {
        AudioVolume = PlayerPrefs.GetFloat("Volume", 1f); // ����� ���� ��������
        audioSource = GetComponent<AudioSource>();
        if (SoundManager.SoundInstance != null)
        {
            BGMSlideChanged(SoundManager.SoundInstance.SFXSize);
        }
    }
    public void BGMSlideChanged(float value)
    {
        AudioVolume = value; // �����̴� ������ AudioVolume ������Ʈ
        PlayerPrefs.SetFloat("Volume", AudioVolume); // ���� ����
        audioSource.volume = AudioVolume; // AudioSource�� ���� ����
        SoundManager.SoundInstance.BGMSize = value;
        Debug.Log(SoundManager.SoundInstance.BGMSize);
    }
}
