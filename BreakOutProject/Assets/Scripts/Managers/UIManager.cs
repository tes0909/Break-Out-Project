using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
	#region singleton
	private static UIManager _instance;

	public static UIManager Instance { get { Init(); return _instance; } }

	public static void Init()
	{

		if (_instance == null)
		{
			_instance = new UIManager();
			_instance._cache = new Dictionary<string, GameObject>();
			_instance._popups = new Dictionary<string, UI_Popup>();
		}
	}
	#endregion

	private Dictionary<string, UI_Popup> _popups;
	private Dictionary<string, GameObject> _cache;
	private int _sort = 0;
	public UI_Popup OpenPopUpUI(string path, bool caching = true)
	{
		if (_cache.ContainsKey(path))
		{
			SetCanvas(_cache[path].gameObject);
			_cache[path].SetActive(true);
		}

		GameObject go = GameObject.Instantiate(Resources.Load<GameObject>($"Prefabs/UI/Popup/{path}"));
		SetCanvas(go);
		_popups.Add(path, go.GetComponent<UI_Popup>());
		if (caching)
		{
			_cache.Add(path, go);
		}
		return go.GetComponent<UI_Popup>();
	}
	public UI_Scene OpenSceneUI(string path)
	{
		GameObject go = GameObject.Instantiate(Resources.Load<GameObject>($"Prefabs/UI/Scene/{path}"));
		SetCanvas(go,false);
		return go.GetComponent<UI_Scene>();
	}

	public UI_SubItem CreateSubItemUI(string path,Transform parent=null)
	{
		GameObject go = GameObject.Instantiate(Resources.Load<GameObject>($"Prefabs/UI/SubItem/{path}"), parent);
		return go.GetComponent<UI_SubItem>() ;
	}

	public void ClosePopUpUI(string path)
	{
		_popups[path].Close();
		_sort--;
	}
	public void ClearCache()
	{
		foreach (var popup in _cache.Values)
		{
			if (popup != null && popup.gameObject != null)
			{
				GameObject.Destroy(popup.gameObject);
			}
		}
		_cache.Clear();
		Resources.UnloadUnusedAssets();
	}
	private void SetCanvas(GameObject go, bool sort = true)
	{
		go.GetComponent<Canvas>().sortingOrder = sort ? _sort++ : 0;
	}


}
