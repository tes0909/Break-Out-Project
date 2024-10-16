using UnityEngine;
using UnityEngine.SceneManagement;
using static SceneChange;

public enum SceneName
{
    Lobby,
    SelectMode,
    InGame
}

//public interface ISceneChange
//{
//    void ChangeScene(SceneName sceneName);
//}

public class SceneChange:MonoBehaviour//, ISceneChange
{
    IGameManager gameManaer;
    //씬 불러오기

    //enum은 유니티 UI버튼 onclick에 안보임. int,string,float만 매개변수로 받을수 있음.
    public static void ChangeScene(SceneName sceneName)
    {
        SceneManager.LoadScene(sceneName.ToString());
    }

    //테스트
    public void LoadInGameScene()
    {
        gameManaer.StartGame();
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