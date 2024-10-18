using UnityEngine;

public class ScreenControl : MonoBehaviour, ICommand
{
    private string[] BlackoutEffects = { "ItemEffect/BlackOutUI", "ItemEffect/HalfBlackOutUI" };
    private int index = -1;
    public float _duration = 5f;
    public void Awake()
    {
        index = Random.Range(0, BlackoutEffects.Length);
    }
    public void Affect()
    {
        index = Random.Range(0, BlackoutEffects.Length);
        Game.Instance.UiManager.OpenPopUpUI(BlackoutEffects[index]); ;
        Invoke("Applying", _duration);
    }

    public void Applying()
    {
        Game.Instance.UiManager.ClosePopUpUI(BlackoutEffects[index]);
    }
}
