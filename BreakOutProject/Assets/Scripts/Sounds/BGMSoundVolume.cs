using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSoundVolume : MonoBehaviour, IVolume
{
    AudioSource audioSource;
    [Range(0f, 1f)]
    public float AudioVolume;
    private void Start()
    {
        AudioVolume = PlayerPrefs.GetFloat("BGMVolume", 1f); // 저장된 볼륨 가져오기
        audioSource = GetComponent<AudioSource>();
        if (SoundManager.SoundInstance != null)
        {
			UpdateSoundVolume(AudioVolume);
        }
    }

	public void UpdateSoundVolume(float volume)
	{
		AudioVolume = volume; // 슬라이더 값으로 AudioVolume 업데이트
		PlayerPrefs.SetFloat("BGMVolume", AudioVolume); // 볼륨 저장
		audioSource.volume = AudioVolume; // AudioSource의 볼륨 설정
		Debug.Log(volume);
	}
}
