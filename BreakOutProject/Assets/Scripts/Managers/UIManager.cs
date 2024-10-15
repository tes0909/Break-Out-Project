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

	private Stack<UI_Popup> _popups = new Stack<UI_Popup>();
	private Dictionary<string, UI_Popup> _cache = new Dictionary<string, UI_Popup>();
	private int _sort = 0;
	public void OpenPopUpUI(string path, bool caching = true)
	{
		if (_cache.ContainsKey(path))
		{
			SetCanvas(_cache[path].gameObject);
			_cache[path].gameObject.SetActive(true);
		}

		GameObject go = GameObject.Instantiate(Resources.Load<GameObject>($"Prefabs/UI/Popup/{path}"));
		SetCanvas(go);
		if (!caching)
			return;
		_popups.Push(go.GetComponent<UI_Popup>());
		_cache.Add(path, go.GetComponent<UI_Popup>());
	}
	public void OpenSceneUI()
	{

	}
	public void ClosePopUpUI()
	{
		_popups.Pop().Close();
		_sort--;
	}
	public void ClearCache()
	{
		foreach (var popup in _cache.Values)
		{
			if (popup != null && popup.gameObject != null)
			{
				Destroy(popup.gameObject);
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
