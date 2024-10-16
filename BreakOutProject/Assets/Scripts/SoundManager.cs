using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Audio Sources")]
    private AudioSource BGMSource; // ������� AudioSource
    private AudioSource SFXSource; // ȿ������ AudioSource
    public AudioClip[] BGM_Clips; // �� ���� �´� ����� Ŭ�� �迭
    public AudioClip[] SFX_Clips; // �� ���� �´� ����� Ŭ�� �迭

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // AudioSource ������Ʈ �߰�
        BGMSource = gameObject.AddComponent<AudioSource>();
        SFXSource = gameObject.AddComponent<AudioSource>();
    }
    public void PlayBGM(AudioClip clip)
    {
        if (BGMSource.isPlaying)
            BGMSource.Stop();

        BGMSource.clip = clip;
        BGMSource.loop = true; // ������� �ݺ� ���
        BGMSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip); // ȿ���� ���
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // ���� �ε�� �� ȣ��� �޼��� ���
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // �� �ε� �� ��� ����
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayBGMForCurrentScene(); // ���� �ε�� �� ����� ���
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
