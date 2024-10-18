using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item : MonoBehaviour
{
    public enum itemTypeEnum : int
    {
        multiBall = 1,
        longPaddle = 2,
        screenControl = 3,
        timeControl = 4
    }
    public Sprite multiBallItemSprite;
    public Sprite longPaddleItemSprite;
    public Sprite timeControlSprite;
    public Sprite screenControlSprite;

    private ICommand command;
    // Start is called before the first frame update
    public void SetItemType(itemTypeEnum settingItemType)
    {
        switch (settingItemType)
        {
            case itemTypeEnum.multiBall:
                gameObject.GetComponent<SpriteRenderer>().sprite = multiBallItemSprite;
                command = new MultiBall();
                break;

            case itemTypeEnum.longPaddle:
                gameObject.GetComponent<SpriteRenderer>().sprite = longPaddleItemSprite;
                command = new LongPaddle();
                break;

            case itemTypeEnum.screenControl:
                gameObject.GetComponent<SpriteRenderer>().sprite = screenControlSprite;
                command = new ScreenControl();
                break;

            case itemTypeEnum.timeControl:
                gameObject.GetComponent<SpriteRenderer>().sprite = timeControlSprite;
                command = new TimeControl();
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            command.Affect();
        }
    }
}
