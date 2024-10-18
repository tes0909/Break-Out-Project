using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum difficultyLevel : int
{
	easy = 0,
	normal = 1,
	hard = 2,
	special = 3,
    end,
}
public class BrickGenenrator : MonoBehaviour
{
    public float brickRangeXMin;
    public float brickRangeYTop;

    public float brickSizeX;
    public float brickSizeY;

    public float brickIntervalX;
    public float brickIntervalY;

    public PoolManager poolManager;

    private int[,] brickPattern;
	// Start is called before the first frame update
	private void Awake()
	{
        GameManager.Instance.OnGameStart += GenenrateBrick;
	}

	public void GenenrateBrick(int difficulty)
    {
        difficultyLevel currentDifficulty = (difficultyLevel)difficulty;
        switch (currentDifficulty)
        {
            case difficultyLevel.easy:
                GenerateEasy();
                break;

            case difficultyLevel.normal:
                GenerateNormal();
                break;

            case difficultyLevel.hard:
                GenerateHard();
                break;

            case difficultyLevel.special:
                GenerateSpecial();
                break;
        }
    }

    private void GenerateSpecial()
    {
        throw new NotImplementedException();
    }

    private void GenerateHard()
    {
        throw new NotImplementedException();
    }

    private void GenerateNormal()
    {
        ResetBrick();

        brickPattern = new int[5, 8] {{ 1, 1, 1, 1, 1, 1, 1, 1},
                                      { 1, 2, 1, 2, 2, 1, 2, 1},
                                      { 1, 1, 1, 1, 1, 1, 1, 1},
                                      { 0, 0, 0, 0, 0, 0, 0, 0},
                                      { 0, 0, 0, 0, 0, 0, 0, 0}};
        GenerateBrickByPattern();
    }

    private void GenerateEasy()
    {
        ResetBrick();
        brickPattern = new int[5, 8] {{ 1, 0, 1, 0, 1, 0, 1, 0},
                                      { 0, 1, 0, 1, 0, 1, 0, 1},
                                      { 1, 0, 1, 0, 1, 0, 1, 0},
                                      { 0, 0, 0, 0, 0, 0, 0, 0},
                                      { 0, 0, 0, 0, 0, 0, 0, 0}};

        GenerateBrickByPattern(); 
    }

    private void GenerateBrickByPattern()
    {
        for (int y = 0; y < brickPattern.GetLength(0); y++)
        {
            for(int x = 0; x < brickPattern.GetLength(1); x++)
            {
                if (brickPattern[y, x] > 0)
                {
                    GameObject obj = poolManager.GetBrick();
                    obj.SetActive(true);
                    obj.transform.position = new Vector2(brickRangeXMin + brickSizeX * x + brickIntervalX * x, brickRangeYTop - brickSizeY * y - brickIntervalY * y);
                    obj.GetComponent<Brick>().SetDurability(brickPattern[y,x]);
                }
            }
        }
    }

    public void ResetBrick()
    {
        poolManager.ResetBrick();
    }
    // Update is called once per frame

}
