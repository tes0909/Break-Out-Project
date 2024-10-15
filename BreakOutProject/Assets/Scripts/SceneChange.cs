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

    //�� �ҷ�����
    public void ChangeScene(int sceneIndex)
    {
        SceneName scene = (SceneName)sceneIndex; //�����ް� -> enum����
        string sceneName = scene.ToString(); //enum -> string
        SceneManager.LoadScene(sceneName);
    }

    //enum�� ����Ƽ UI��ư onclick�� �Ⱥ���. int,string,float�� �Ű������� ������ ����.
    public void ChangeScene2(SceneName sceneName)
    {
        SceneManager.LoadScene(sceneName.ToString());
    }
}