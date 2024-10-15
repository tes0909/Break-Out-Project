using UnityEngine;
using UnityEngine.SceneManagement;
using static SceneChange;

public class SceneChange:MonoBehaviour
{
    public enum SceneName
    {
        Lobby,
        SelectMode,
        InGame
    }

    //씬 불러오기
    public void ChangeScene(int sceneIndex)
    {
        SceneName scene = (SceneName)sceneIndex; //정수받고 -> enum으로
        string sceneName = scene.ToString(); //enum -> string
        SceneManager.LoadScene(sceneName);
    }

    //enum은 유니티 UI버튼 onclick에 안보임. int,string,float만 매개변수로 받을수 있음.
    public void ChangeScene2(SceneName sceneName)
    {
        SceneManager.LoadScene(sceneName.ToString());
    }
}