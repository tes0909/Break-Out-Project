using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCanvas : MonoBehaviour
{
    GameObject soundCanvas;
    private bool isPaused = false;
    private void Awake()
    {
        soundCanvas = gameObject;
        PauseGame();
    }
    public void OnSoundCanvas()
    {
        PauseGame();
        soundCanvas.SetActive(true);
    }
    public void OffSoundCanvas()
    {
        ResumeGame();
        soundCanvas.SetActive(false);
    }
    void PauseGame()
    {
        Time.timeScale = 0; // ���� ����
        isPaused = true; // ���� ������Ʈ
    }

    void ResumeGame()
    {
        Time.timeScale = 1; // ���� �簳
        isPaused = false; // ���� ������Ʈ
    }
}
