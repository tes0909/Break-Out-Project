using UnityEngine;

public class MultiBall : MonoBehaviour, ICommand
{
    private GameObject ball;
    public void Awake()
    {
        ball = GameObject.Find("Ball(Clone)");
    }
    public void Affect()
    {
        //공 갯수 여러개로 증가
        Instantiate(ball);
        Instantiate(ball);
    }

    public void Applying()
    {

    }
}
