using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPool : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] public Queue<GameObject> itemPool;
    public int maxItem;
    private void Awake()
    {
        itemPool = new Queue<GameObject>();
        for (int i = 0; i < maxItem; i++)
        {
            GameObject obj = Instantiate(itemPrefab);
            obj.SetActive(false);
            itemPool.Enqueue(obj);
        }
    }

    public GameObject GetItem()
    {
        GameObject obj = itemPool.Dequeue();
        itemPool.Enqueue(obj);
        return obj;
    }
}
