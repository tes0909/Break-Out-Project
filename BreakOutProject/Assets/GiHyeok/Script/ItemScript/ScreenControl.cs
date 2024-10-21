using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ScreenControl : IItemEffect
{
    private string[] BlackoutEffects = { "ItemEffect/BlackOutUI", "ItemEffect/HalfBlackOutUI" };
    private int index = -1;
    public float _duration = 5f;
    public Color color { get; set; } = Color.white;
    public ScreenControl()
    {
        index = Random.Range(0, BlackoutEffects.Length);
        switch (index) 
        {
            case 0:
                color = Color.red;
                break;

            case 1:
                color = Color.white;
                break;
        }
    }
    public void Affect()
    {
        index = Random.Range(0, BlackoutEffects.Length);
        Game.Instance.UiManager.OpenPopUpUI(BlackoutEffects[index]);
		Game.Instance.StartCoroutine(Applying(_duration));
	}
	public IEnumerator Applying(float delay)
	{
		yield return new WaitForSeconds(delay);
		Game.Instance.UiManager.ClosePopUpUI();
	}

}
