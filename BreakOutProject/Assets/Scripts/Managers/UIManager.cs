using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
	public void Init()
	{
		_popups = new Stack<UI_Popup>();
		_cache = new Dictionary<string, GameObject>();
	}

	private Stack<UI_Popup> _popups;
	private Dictionary<string, GameObject> _cache;
	private int _sort = 0;
	public UI_Popup OpenPopUpUI(string path, bool caching = true)
	{
		GameObject go;
		if (_cache.ContainsKey(path))
		{
			go = _cache[path].gameObject;
		}
		else
		{
			go = ResourceManager.Instantiate($"UI/Popup/{path}");
			if (caching)
				_cache.Add(path, go);
		}

		SetCanvas(go);
		go.SetActive(true);
		_popups.Push(go.GetComponent<UI_Popup>());
		return go.GetComponent<UI_Popup>();
	}

	public UI_Scene OpenSceneUI(string path)
	{
		GameObject go = ResourceManager.Instantiate($"UI/Scene/{path}");
		SetCanvas(go,false);
		return go.GetComponent<UI_Scene>();
	}

	public UI_SubItem CreateSubItemUI(string path,Transform parent=null)
	{
		GameObject go = ResourceManager.Instantiate($"UI/SubItem/{path}", parent);
		return go.GetComponent<UI_SubItem>() ;
	}

	public void ClosePopUpUI()
	{
		_popups.Pop().Close();
		_sort--;
	}
	public void CloseAllPopUp()
	{
		while(_popups.Count > 0)
		{
			_popups.Pop().Close();
			_sort--;
		}
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
		go.GetComponent<Canvas>().sortingOrder = sort ? ++_sort : 0;
	}


}
