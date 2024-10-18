using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVolume : MonoBehaviour
{
    AudioSource audioSource;
    [Range(0f, 1f)]
    public float AudioVolume;
    private void Awake()
    {
        AudioVolume = PlayerPrefs.GetFloat("Volume", 1f); // ����� ���� ��������
        audioSource = GetComponent<AudioSource>();
    }
        public void SlideChanged(float value)
    {
        AudioVolume = value; // �����̴� ������ AudioVolume ������Ʈ
        PlayerPrefs.SetFloat("Volume", AudioVolume); // ���� ����
        audioSource.volume = AudioVolume; // AudioSource�� ���� ����

    }
}
