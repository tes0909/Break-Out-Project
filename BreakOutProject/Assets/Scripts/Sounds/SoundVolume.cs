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
        AudioVolume = PlayerPrefs.GetFloat("Volume", 1f); // 저장된 볼륨 가져오기
        audioSource = GetComponent<AudioSource>();
    }
        public void SlideChanged(float value)
    {
        AudioVolume = value; // 슬라이더 값으로 AudioVolume 업데이트
        PlayerPrefs.SetFloat("Volume", AudioVolume); // 볼륨 저장
        audioSource.volume = AudioVolume; // AudioSource의 볼륨 설정

    }
}
