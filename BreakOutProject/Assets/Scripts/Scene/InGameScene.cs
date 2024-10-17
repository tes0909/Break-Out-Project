using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameScene : BaseScene
{
	[SerializeField] private Vector3 _paddleInitPosition = new Vector3(0, -3, 0);
	protected override void Awake()
	{
		base.Awake();
		Game.Instance.UiManager.OpenSceneUI("GameSceneUI");
		GameObject paddle = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Paddle"));
		paddle.transform.position = _paddleInitPosition;

		GameObject brickManager = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Brick/BrickManager"));

		GameObject walls = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Walls"));
		GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Background2"));
	}

    private void Start()
    {
        Game.Instance.GameManager.CountDownGameStart();
    }

    protected override void Close()
	{
		return;
	}
}
