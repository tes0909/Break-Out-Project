using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameScene : BaseScene
{
	[SerializeField] private Vector3 _paddleInitPosition = new Vector3(0, -3, 0);
	protected override void Awake()
	{
		base.Awake();
		UIManager.Instance.OpenSceneUI("GameSceneUI");
	}

    private void Start()
    {
        if (GameManager.Instance.currentState == GameState.playing)
        {
            GameObject paddle = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Paddle"));
            paddle.transform.position = _paddleInitPosition;

            GameObject brickManager = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Brick/BrickManager"));
        }
    }


    protected override void Close()
	{
		return;
	}
}
