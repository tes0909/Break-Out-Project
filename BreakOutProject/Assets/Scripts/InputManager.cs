using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class InputManager : MonoBehaviour
{
    Rigidbody2D rb;
    [Range(0f, 30f)] [SerializeField] private float speed;

    private const float LeftBoundary = -8.1f;
    private const float RightBoundary = 8.1f;
    public float horizontal;
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PaddleMovement();
        ConstrainPosition();
    }

    void PaddleMovement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
       
        Vector2 direction = new Vector2(horizontal, 0);
        direction = direction.normalized;

        rb.velocity = direction * speed;
    }

    void ConstrainPosition()
    {
        Vector2 position = transform.position;

        if (position.x < LeftBoundary)
            position.x = LeftBoundary;
        else if (position.x > RightBoundary)
            position.x = RightBoundary;

        transform.position = position; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "item")
        {
            int itemType=collision.transform.GetComponent<Item>().itemType;
            switch (itemType) 
            {
                case (int)Item.itemTypeEnum.powerBall:
                    //공이 장애물 관통?
                    break;

                case (int)Item.itemTypeEnum.multiBall:
                    //공 여러개로 분열
                    break;

                case (int)Item.itemTypeEnum.longPaddle:
                    //패들 길이 늘어남
                    break;

                case (int)Item.itemTypeEnum.special:
                    //미정
                    break;
            }

        }
        collision.gameObject.SetActive(false);
    }
}
