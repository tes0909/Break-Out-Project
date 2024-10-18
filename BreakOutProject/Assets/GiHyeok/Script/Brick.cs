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
            /*if (maxDurability == 2) 아이템 드랍
            {
                DropItem();
            }*/
            gameObject.SetActive(false);

            Game.Instance.GameManager.Score += 1;
            // clear check
            bool isLast = true;
            foreach(GameObject obj in GameObject.Find("BrickManager(Clone)").GetComponent<PoolManager>().totalPool["brick"])
            {
                if (obj.activeSelf== true)
                {
                    isLast= false;
                    break;
                }
            }
            if(isLast = true)
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
        int itemDrop = Random.Range(0, 100);
        GameObject item = GameObject.Find("PoolManager").GetComponent<PoolManager>().GetItem();
        item.SetActive(true);
        switch (itemDrop)
        {
            case <20: 
                item.GetComponent<Item>().SetItemType(Item.itemTypeEnum.multiBall);
                break;

            case < 40:
                item.GetComponent<Item>().SetItemType(Item.itemTypeEnum.longPaddle);
                break;

            case < 60:
                item.GetComponent<Item>().SetItemType(Item.itemTypeEnum.timeControl);
                break;

            case < 80:
                item.GetComponent<Item>().SetItemType(Item.itemTypeEnum.screenControl);
                break;
        }
        item.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }
}
