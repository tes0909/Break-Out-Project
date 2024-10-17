using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public GameObject objectToDestroy; // Inspector에서 지정할 오브젝트

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 충돌한 모든 오브젝트를 파괴
        Destroy(other.gameObject);
        Debug.Log(other.gameObject.name + " has been destroyed.");
    }
}
