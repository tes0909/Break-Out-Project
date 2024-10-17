using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemType { get; private set; }
    public enum itemTypeEnum : int
    {
        powerBall = 0,
        multiBall = 1,
        longPaddle = 2,
        special = 3
    }
    public Sprite powerBallItemSprite;
    public Sprite multiBallItemSprite;
    public Sprite longPaddleItemSprite;
    public Sprite specialItemSprite;
    // Start is called before the first frame update
    public void SetItemType(itemTypeEnum settingItemType)
    {
        itemType = (int)settingItemType;
        switch (settingItemType)
        {
            case itemTypeEnum.powerBall:
                gameObject.GetComponent<SpriteRenderer>().sprite = powerBallItemSprite;
                break;

            case itemTypeEnum.multiBall:
                gameObject.GetComponent<SpriteRenderer>().sprite = multiBallItemSprite;
                break;

            case itemTypeEnum.longPaddle:
                gameObject.GetComponent<SpriteRenderer>().sprite = longPaddleItemSprite;
                break;

            case itemTypeEnum.special:
                gameObject.GetComponent<SpriteRenderer>().sprite = specialItemSprite;
                break;
        }
    }
}
