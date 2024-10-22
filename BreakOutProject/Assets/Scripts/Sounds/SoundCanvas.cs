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
        Time.timeScale = 0; // 게임 멈춤
        isPaused = true; // 상태 업데이트
    }

    void ResumeGame()
    {
        Time.timeScale = 1; // 게임 재개
        isPaused = false; // 상태 업데이트
    }
}
