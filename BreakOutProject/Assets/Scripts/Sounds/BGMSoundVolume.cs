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
        AudioVolume = PlayerPrefs.GetFloat("BGMVolume", 1f); // ����� ���� ��������
        audioSource = GetComponent<AudioSource>();
        if (SoundManager.SoundInstance != null)
        {
			UpdateSoundVolume(AudioVolume);
        }
    }

	public void UpdateSoundVolume(float volume)
	{
		AudioVolume = volume; // �����̴� ������ AudioVolume ������Ʈ
		PlayerPrefs.SetFloat("BGMVolume", AudioVolume); // ���� ����
		audioSource.volume = AudioVolume; // AudioSource�� ���� ����
		Debug.Log(volume);
	}
}
