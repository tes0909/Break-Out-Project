using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	#region singleton
	private static UIManager _instance;

	public static UIManager Instance { get { Init(); return _instance; } }

	public static void Init()
	{
		if(Instance == null)
		{
			_instance = new UIManager();
		}
	}
	#endregion

	public void OpenPopUpUI()
	{

	}
	public void OpenSceneUI()
	{

	}
	public void ClosePopUpUI()
	{

	}


}
