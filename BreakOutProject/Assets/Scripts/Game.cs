using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Game:MonoBehaviour
{
    public static Game Instance { get; private set; }

    private GameManager _gameManager;
    private UIManager _uiManager;
    private SoundManager _soundManager;

    public GameManager GameManager => _gameManager;
    public UIManager UiManager { get { return _uiManager; } }


    public SoundManager SoundManager
    {
        get { return _soundManager; }
        set { _soundManager = value; }
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            _uiManager = new UIManager();
			_uiManager.Init();
			_gameManager = new GameManager();

			_soundManager = GetComponent<SoundManager>();
			

        }
        else
        {
            Destroy(gameObject);
        }
    }
}