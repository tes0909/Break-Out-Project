using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
	multiBall = 1,
	longPaddle = 2,
	screenControl = 3,
	timeControl = 4,
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
        Debug.Log($"Sprites/{itemType.ToString()}");
		_spriteRenderer.sprite = ResourceManager.Load<Sprite>($"Sprites/{itemType.ToString()}");
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
