using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public GameObject objectToDestroy; // Inspector���� ������ ������Ʈ

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �浹�� ��� ������Ʈ�� �ı�
        Destroy(other.gameObject);
        Debug.Log(other.gameObject.name + " has been destroyed.");
    }
}
