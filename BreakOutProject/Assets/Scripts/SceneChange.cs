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

    [SerializeField] private Image fadeImage;
    private float fadeDuration = 1.3f;

    public void ChangeScene(SceneName sceneName)
    {
		StartCoroutine(Trasition(sceneName));
		//SceneManager.LoadScene(sceneName.ToString());
    }

    private IEnumerator Trasition(SceneName sceneName)
    {
        //페이드아웃
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

    }

    //테스트
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