using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
	public void Init()
	{
		_popups = new Dictionary<string, UI_Popup>();
		_cache = new Dictionary<string, GameObject>();
	}

	private Dictionary<string, UI_Popup> _popups;
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
			go = GameObject.Instantiate(Resources.Load<GameObject>($"Prefabs/UI/Popup/{path}"));
			if (caching)
				_cache.Add(path, go);
		}

		SetCanvas(go);
		go.SetActive(true);
		_popups.Add(path, go.GetComponent<UI_Popup>());
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
		_popups.Remove(path);
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
		go.GetComponent<Canvas>().sortingOrder = sort ? ++_sort : 0;
	}


}
