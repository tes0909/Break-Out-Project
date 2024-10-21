using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
	multiBall = 0,
	longPaddle = 1,
	screenControl = 2,
	timeControl = 3,
	end
}

public class Item : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;


    private IItemEffect command;

	public void Awake()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void SetItemType(ItemType itemType)
    {
		command = ItemEffectFactory.CreateItem(itemType);
		_spriteRenderer.sprite = ResourceManager.Load<Sprite>($"Sprites/{itemType.ToString()}");
		_spriteRenderer.color = command.color;
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
