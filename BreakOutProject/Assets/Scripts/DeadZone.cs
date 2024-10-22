using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{

	private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
			Game.Instance.GameManager.Life--;
        }
        Debug.Log(other.gameObject.name + " has been destroyed.");
    }
}
