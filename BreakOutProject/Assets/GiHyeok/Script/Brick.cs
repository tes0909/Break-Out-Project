using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class Brick : MonoBehaviour
{
    private Color color = new Color(255f, 255f, 255f);
    private int maxDurability { get; set; }
    private int currentDurability { get; set; }

    public Sprite normalSprite;
    public Sprite hardSprite;
    public Sprite brokenSprite;

    // Start is called before the first frame update
    void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }

    public void SetDurability(int durability)
    {
        maxDurability = durability;
        currentDurability = durability;
        switch (durability)
        {
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = normalSprite;
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = hardSprite;
                break;
        }
    }

    public void GetDamage()//ball에서 구현해도 될듯
    {
        if (currentDurability == 1)
        {
            currentDurability--;
            //if (maxDurability == 2)
            //{
                DropItem();
            //}
            gameObject.SetActive(false);

            Game.Instance.GameManager.Score += 1;
            // clear check
            bool isLast = true;
            foreach(GameObject obj in GameObject.Find("BrickManager").GetComponent<PoolManager>().totalPool["brick"])
            {
                if (obj.activeSelf== true)
                {
                    isLast= false;
                    break;
                }
            }
            if(isLast)
            {
                Game.Instance.GameManager.GameClear();
            }
        }
        else if (currentDurability == 2)
        {
            currentDurability--;
            gameObject.GetComponent<SpriteRenderer>().sprite = brokenSprite;
        }
    }

    private void DropItem()
    {
        int itemDrop = Random.Range(0, (int)ItemType.end+1);
        if(itemDrop == (int)ItemType.end)
            return;

        GameObject item = GameObject.Find("BrickManager").GetComponent<PoolManager>().GetItem();
        item.SetActive(true);
        item.GetComponent<Item>().SetItemType((ItemType)itemDrop);
        item.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }
}
