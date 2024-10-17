using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVolume : MonoBehaviour
{
    AudioSource audioSource;
    [Range(0f, 1f)]
    public float AudioVolume = 1f; // �⺻ ���� ����
    private void Awake()
    {
        AudioVolume = PlayerPrefs.GetFloat("BGMVolume", 1f); // ����� BGM ���� ��������
        audioSource = GetComponent<AudioSource>();
    }
        public void SlideChanged(float value)
    {
        PlayerPrefs.SetFloat("BGMVolume", AudioVolume); // ���� ����
    }


}
