using UnityEngine;

public class TimeControl :  MonoBehaviour, ICommand
{
	private float _controlTime;
	private SpriteRenderer _spriteRenderer;
	public float _duration=5f;
    public void Awake()
    {
		_spriteRenderer = GetComponent<SpriteRenderer>();
        _controlTime = Random.Range(0f, 1.5f);
        if (_controlTime < 0.01f)
        {
            _controlTime = 0f;
            _spriteRenderer.color = Color.blue;
        }
        else if (_controlTime < 1f)
        {
            _spriteRenderer.color = Color.white;
        }
        else
        {
            _spriteRenderer.color = Color.red;
        }
    }
    public void Affect()
	{
        Time.timeScale = _controlTime;
        Invoke("Applying", _duration);
    }

	public void Applying()
	{
        Time.timeScale = 1f;
    }
}
