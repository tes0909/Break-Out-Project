using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Audio Sources")]
    private AudioSource BGMSource; // 배경음용 AudioSource
    private AudioSource SFXSource; // 효과음용 AudioSource
    public AudioClip[] BGM_Clips; // 각 씬에 맞는 배경음 클립 배열
    public AudioClip[] SFX_Clips; // 각 씬에 맞는 배경음 클립 배열

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // AudioSource 컴포넌트 추가
        BGMSource = gameObject.AddComponent<AudioSource>();
        SFXSource = gameObject.AddComponent<AudioSource>();
    }
    public void PlayBGM(AudioClip clip)
    {
        if (BGMSource.isPlaying)
            BGMSource.Stop();

        BGMSource.clip = clip;
        BGMSource.loop = true; // 배경음은 반복 재생
        BGMSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip); // 효과음 재생
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // 씬이 로드될 때 호출될 메서드 등록
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // 씬 로드 시 등록 해제
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayBGMForCurrentScene(); // 씬이 로드될 때 배경음 재생
    }
    private void PlayBGMForCurrentScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (sceneIndex < BGM_Clips.Length && BGM_Clips[sceneIndex] != null)
        {
            PlayBGM(BGM_Clips[sceneIndex]);
        }
    }
}
