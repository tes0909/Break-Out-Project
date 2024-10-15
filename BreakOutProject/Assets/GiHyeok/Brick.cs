using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private Color color= new Color (255f,255f,255f);
    private int maxDurability { get; set; }
    private int currentDurability { get; set; }


    // Start is called before the first frame update
    void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }
}
