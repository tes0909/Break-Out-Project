using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BrickGenenrator : MonoBehaviour
{
    public float brickRangeXMin;
    public float brickRangeXMax;
    public float brickRangeYMin;
    public float brickRangeYMax;
    public enum difficultyLevel : int
    {
        easy=0,
        normal=1,
        hard=2,
        special=3
    }
    public BrickPool brickPool;
    // Start is called before the first frame update
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
        for (int i = 0; i < 15; i++)
        {
            GameObject obj = brickPool.GetBrick();
            obj.SetActive(true);
            obj.transform.position = new Vector2(Random.Range(brickRangeXMin, brickRangeXMax), Random.Range(brickRangeYMin, brickRangeYMax));
        }
    }

    private void GenerateEasy()
    {
        ResetBrick();
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = brickPool.GetBrick();
            obj.SetActive(true);
            obj.transform.position=new Vector2(Random.Range(brickRangeXMin,brickRangeXMax), Random.Range(brickRangeYMin,brickRangeYMax));
        }
    }

    public void ResetBrick()
    {
        brickPool.Reset();
    }
    // Update is called once per frame

}
