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
            _soundManager = new SoundManager();
            _gameManager = new GameManager();

            _uiManager.Init();

        }
        else
        {
            Destroy(gameObject);
        }
    }
}