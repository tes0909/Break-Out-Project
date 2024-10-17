using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundVolume : MonoBehaviour
{
    AudioSource audioSource;
    [Range(0f, 1f)]
    public float AudioVolume = 1f; // 기본 볼륨 설정
    private void Awake()
    {
        AudioVolume = PlayerPrefs.GetFloat("BGMVolume", 1f); // 저장된 BGM 볼륨 가져오기
        audioSource = GetComponent<AudioSource>();
    }
        public void SlideChanged(float value)
    {
        PlayerPrefs.SetFloat("BGMVolume", AudioVolume); // 볼륨 저장
    }


}
