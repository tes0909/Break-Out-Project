using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_GameScene : UI_Scene
{
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private TMP_Text _nowScoreText;
    [SerializeField] private TMP_Text _highScoreText;
    [SerializeField] private Transform _lifeLayout;

    private List<UI_LifeIcon> _lifeIcons;
    private int _lifeCount;

    private void Awake()
    {

        CreateLife();
        Game.Instance.GameManager.OnLifeChanged += UpdateLife;
        Game.Instance.GameManager.OnScoreChanged += NowScoreText;
        ScoreboardManager.Instance.OnHighScoreUpdated += UpdateHighScoreText;

        if (ScoreboardManager.Instance.Scores.Count > 0 && ScoreboardManager.Instance.Scores != null)
        {
            _highScoreText.text = ScoreboardManager.Instance.Scores[0].ToString();
        }
        else
        {
            _highScoreText.text = "0";
        }


        Game.Instance.gameObject.GetComponent<TimeManager>().OnChangeTime += UpdateTimerText;
    }

    private void UpdateHighScoreText(int newHighScore)
    {
        _highScoreText.text = newHighScore.ToString();
    }

    private void CreateLife()
    {
        _lifeCount = Game.Instance.GameManager.Life;
        if (_lifeIcons == null || _lifeIcons.Count == 0)
        {
            _lifeIcons = new List<UI_LifeIcon>();
            for (int i = 0; i < 10; i++)
            {
                _lifeIcons.Add((UI_LifeIcon)Game.Instance.UiManager.CreateSubItemUI("LifeIcon", _lifeLayout));
                _lifeIcons[i].gameObject.SetActive(false);
            }
        }
        for (int i = 0; i < _lifeCount; ++i)
        {
            _lifeIcons[i].gameObject.SetActive(true);
        }

    }

    public void UpdateTimerText(float time)
    {
        _timerText.text = time.ToString("F2");
    }

    public void NowScoreText(int score)
    {
        _nowScoreText.text = score.ToString();
    }

    public void UpdateLife(int life)
    {
        for(int i  = 0; i < life; i++)
        {
			_lifeIcons[i].gameObject.SetActive(true);
		}
        for(int i = life; i < 10; i++)
        {
			_lifeIcons[i].gameObject.SetActive(false);
		}

    }

}
