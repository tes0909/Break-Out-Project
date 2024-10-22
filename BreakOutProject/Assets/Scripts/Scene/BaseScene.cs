using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseScene : MonoBehaviour
{
	protected virtual void Awake()
	{
		
	}
	protected abstract void Close();
}
