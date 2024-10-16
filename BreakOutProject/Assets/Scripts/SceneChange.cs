using UnityEngine;
using UnityEngine.SceneManagement;
using static SceneChange;

public enum SceneName
{
    Lobby,
    SelectMode,
    InGame
}

public interface ISceneChange
{
    void ChangeScene(SceneName sceneName);
}

public class SceneChange:MonoBehaviour, ISceneChange
{
    //�� �ҷ�����

    //enum�� ����Ƽ UI��ư onclick�� �Ⱥ���. int,string,float�� �Ű������� ������ ����.
    public void ChangeScene(SceneName sceneName)
    {
        SceneManager.LoadScene(sceneName.ToString());
    }

    //�׽�Ʈ
    public void LoadInGameScene()
    {
        ChangeScene(SceneName.InGame);
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