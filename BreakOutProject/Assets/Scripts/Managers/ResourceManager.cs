using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{
	public static T Load<T>(string path) where T : Object
	{
		return Resources.Load<T>(path);
	}
	public static GameObject Instantiate(string path, Transform parent = null)
	{
		return Instantiate(Load<GameObject>($"Prefabs/{path}"), parent);

	}
	public static GameObject Instantiate(GameObject gameObject, Transform parent = null)
	{
		GameObject go =  GameObject.Instantiate(gameObject, parent);
		go.name = go.name.Replace("(Clone)", "");
		return go;
	}
}
