using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{

	public void Input()
	{
		GameManager.Instance.Score++;
	}
	public void Life()
	{
		GameManager.Instance.Life--;
	}
}
