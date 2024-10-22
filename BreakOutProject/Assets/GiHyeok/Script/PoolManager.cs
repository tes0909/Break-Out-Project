using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] private GameObject brickPrefab;
    [SerializeField] public Dictionary<string,Queue<GameObject>> totalPool;
    public int maxbrick;

    [SerializeField] private GameObject itemPrefab;
    public int maxItem;
    private void Awake()
    {
        Queue<GameObject> brickPool = new Queue<GameObject>();
        for (int i = 0; i < maxbrick; i++)
        {
            GameObject obj = Instantiate(brickPrefab, this.transform);
            obj.SetActive(false);
            brickPool.Enqueue(obj);
        }

        Queue<GameObject> itemPool = new Queue<GameObject>();
        for (int i = 0; i < maxItem; i++)
        {
            GameObject obj = Instantiate(itemPrefab, this.transform);
            obj.SetActive(false);
            itemPool.Enqueue(obj);
        }
        totalPool= new Dictionary<string,Queue<GameObject>>();
        totalPool.Add("brick", brickPool);
        totalPool.Add("item", itemPool);
    }

    public GameObject GetBrick()
    {
        GameObject obj = totalPool["brick"].Dequeue();
        totalPool["brick"].Enqueue(obj);
        return obj;
    }

    public GameObject GetItem()
    {
        GameObject obj = totalPool["item"].Dequeue();
        totalPool["item"].Enqueue(obj);
        return obj;
    }

    internal void ResetBrick()
    {
        foreach (GameObject obj in totalPool["brick"])
        {
            obj.SetActive(false);
        }
    }
}
