using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    Rigidbody2D rb;

    private Vector2 moveDirection = new Vector2(1,0);

    public float playerAngle;
    public bool isCollision;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if(playerAngle >= 360)
        {
            playerAngle = 0;
        }

        Vector2 playerVector = Quaternion.Euler(0, 0, playerAngle) * Vector2.right;

        // Rigidbody2Dに移動ベクトルを適用
        rb.velocity = playerVector * moveSpeed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            if (!isCollision)
            {
                playerAngle += 90;
                isCollision = true;
            }
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isCollision = false;   
    }
}
