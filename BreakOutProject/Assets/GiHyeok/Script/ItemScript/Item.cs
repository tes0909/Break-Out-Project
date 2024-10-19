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


    private ICommand command;

	// Start is called before the first frame update
	public void SetItemType(ItemType itemType)
    {
		command = ItemEffectFactory.CreateItem(itemType);
		_spriteRenderer.sprite = ResourceManager.Load<Sprite>($"Sprite/{itemType.ToString()}");
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
