using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum SceneName
{
    Lobby,
    SelectMode,
    InGame
}

public class SceneChange : MonoBehaviour//, ISceneChange
{
    IGameManager gameManaer;

    [SerializeField]private Image fadeImage;
    private float fadeDuration = 1.3f;

    public void ChangeScene(SceneName sceneName)
    {
        StartCoroutine(Trasition(sceneName));
        Debug.Log("�ڷ�ƾ����");
    }

    private IEnumerator Trasition(SceneName sceneName)
    {
        //���̵���
        float elapsed = 0f;
        Color color = fadeImage.color;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, elapsed / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        SceneManager.LoadScene(sceneName.ToString());

        ////���̵�ƿ�
        //elapsed = 0f;
        //while(elapsed < fadeDuration)
        //{
        //    elapsed += Time.deltaTime;
        //    color.a = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
        //    fadeImage.color = color;
        //    yield return null;
        //}

    }

    //�׽�Ʈ
    public void LoadInGameScene()
    {
        ChangeScene(SceneName.InGame);
        gameManaer.CountDownGameStart();

    }
    public void LoadLobbyScene()
    {
        ChangeScene(SceneName.Lobby);
    }
    public void LoadSelectModeScene()
    {
        ChangeScene(SceneName.SelectMode);
    }
}