using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public float moveSpeed = 50f;
    private void Start()
    {
        PanelController controller = new PanelController();
    }
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal"); // A/D �Ǵ� �¿� ȭ��ǥ
        Vector2 move = new Vector2(moveInput, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(move);
    }
}