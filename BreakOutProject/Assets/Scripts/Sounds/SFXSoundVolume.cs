using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVolume
{
    public void UpdateSoundVolume(float volume);
}
public class SFXSoundVolume : MonoBehaviour, IVolume
{
    AudioSource audioSource;
    [Range(0f, 1f)]
    public float AudioVolume;
    private void Start()
    {
        AudioVolume = PlayerPrefs.GetFloat("SFXVolume", 1f); // ����� ���� ��������
        audioSource = GetComponent<AudioSource>();
        if(Game.Instance.SoundManager != null)
        {
			UpdateSoundVolume(AudioVolume);
        }
    }

	public void UpdateSoundVolume(float volume)
	{
		AudioVolume = volume; // �����̴� ������ AudioVolume ������Ʈ
		PlayerPrefs.SetFloat("SFXVolume", AudioVolume); // ���� ����
		audioSource.volume = AudioVolume; // AudioSource�� ���� ����
		Debug.Log(volume);
	}
}
