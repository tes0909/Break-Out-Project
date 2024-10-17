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
            gameObject.SetActive(false);
            GameManager.Instance.Score += 1;
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
        GameObject item = GameObject.Find("ItemPool").GetComponent<ItemPool>().GetItem();
        item.SetActive(true);
        switch (itemDrop)
        {
            case <20: 
                item.GetComponent<Item>().SetItemType(Item.itemTypeEnum.powerBall);
                break;

            case < 40:
                item.GetComponent<Item>().SetItemType(Item.itemTypeEnum.powerBall);
                break;

            case < 60:
                item.GetComponent<Item>().SetItemType(Item.itemTypeEnum.powerBall);
                break;

            case < 80:
                item.GetComponent<Item>().SetItemType(Item.itemTypeEnum.powerBall);
                break;
        }
        item.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }
}
