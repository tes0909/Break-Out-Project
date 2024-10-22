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
		GameObject paddle = ResourceManager.Instantiate("Paddle");
		paddle.transform.position = _paddleInitPosition;

		ResourceManager.Instantiate("Brick/BrickManager");
		ResourceManager.Instantiate("Background2");
		ResourceManager.Instantiate("Walls");
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
