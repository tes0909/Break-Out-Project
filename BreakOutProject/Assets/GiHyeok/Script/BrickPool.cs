using System;
using System.Collections.Generic;
using UnityEngine;

public class BrickPool : MonoBehaviour
{
    [SerializeField] private GameObject brickPrefab;
    [SerializeField] public Queue<GameObject> brickPool;
    public int maxbrick;
    private void Awake()
    {
        brickPool = new Queue<GameObject>();
        for (int i = 0; i < maxbrick; i++)
        {
            GameObject obj = Instantiate(brickPrefab);
            obj.SetActive(false);
            brickPool.Enqueue(obj);
        }
    }

    public GameObject GetBrick()
    {
        GameObject obj = brickPool.Dequeue();
        brickPool.Enqueue(obj);
        return obj;
    }

    internal void Reset()
    {
        foreach (GameObject obj in brickPool)
        {
            obj.SetActive(false);
        }
    }
}
