using UnityEngine;

public class Game:MonoBehaviour
{
    public static Game Instance { get; private set; }

    private GameManager _gameManager;
    private UIManager _uiManager;
    private SoundManager _soundManager;

    public GameManager GameManager => _gameManager;
    public UIManager UiManager => _uiManager;
    public SoundManager SoundManager => _soundManager;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            _uiManager = new UIManager();
            _soundManager = gameObject.AddComponent<SoundManager>();
            _gameManager = gameObject.AddComponent<GameManager>();

        }
        else
        {
            Destroy(gameObject);
        }
    }
}