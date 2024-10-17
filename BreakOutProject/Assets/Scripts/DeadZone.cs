using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �浹�� ��� ������Ʈ�� �ı�
        Destroy(other.gameObject);
        if (other.gameObject.CompareTag("Ball"))
        {
            GameManager.Instance.GameOver();
        }
        Debug.Log(other.gameObject.name + " has been destroyed.");
    }
}
