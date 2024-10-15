using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private Color color= new Color (255f,255f,255f);
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
        }
        else if(currentDurability == 2)
        {
            currentDurability--;
            gameObject.GetComponent<SpriteRenderer>().sprite = brokenSprite;
        }
    } 
}
