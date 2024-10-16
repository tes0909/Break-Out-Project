using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
	private Rigidbody2D _rb2d;
	private bool _isSpawned = false;
	protected SpriteRenderer _spriteRenderer;
	protected float _duration = 1f;

	private void Awake()
	{
		_rb2d = GetComponent<Rigidbody2D>();
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}
	public virtual void Spawn(Vector2 position, float duration,  float speed)
	{
		_isSpawned = true;
		transform.position = position;
		_duration = duration;
		Drop(speed);
	}
	public void Drop(float speed)
	{
		_rb2d.velocity = Vector2.down * speed;
	}
	protected abstract void Affect();
	protected abstract void Applying();

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			gameObject.SetActive(false);
			Affect();
		}
	}
}
