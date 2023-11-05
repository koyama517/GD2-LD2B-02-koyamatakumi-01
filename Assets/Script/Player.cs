using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    Rigidbody2D rb;

    private Vector2 moveDirection = new Vector2(1, 0);

    public float angle;
    public float angleNum;

    public bool isRevers;
    bool isTurn;
    bool isCollision;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //isRevers = false;
    }

    void Update()
    {
        SceneManegar mane;
        GameObject manegar = GameObject.Find("Main Camera");
        mane = manegar.GetComponent<SceneManegar>();
        if (mane != null)
        {
            if (mane.isStart)
            {
                if (isTurn && isCollision)
                {
                    if (angle + angleNum >= 360)
                    {
                        angleNum -= 360;
                        angle += angleNum;
                    }
                    else
                    {
                        angle += angleNum;
                    }
                    isTurn = false;
                }
                Vector2 playerVector = Quaternion.Euler(0, 0, angle) * Vector2.right;

                // Rigidbody2Dに移動ベクトルを適用
                rb.velocity = playerVector * moveSpeed;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            if (!isCollision)
            {
                if (!isRevers)
                {
                    angleNum = 90;
                }
                else
                {
                    angleNum = 270;
                }
                isTurn = true;
                isCollision = true;
            }
        }

        if (collision.gameObject.tag == "RePoint")
        {
            if (!isCollision)
            {
                if (!isRevers)
                {
                    angleNum = 270;
                }
                else
                {
                    angleNum = 90;
                }
                isTurn = true;
                isCollision = true;
            }
        }

        if (collision.gameObject.tag == "PPoint")
        {
            if (!isCollision)
            {
                if (!isRevers)
                {
                    isRevers = true;
                }
                else
                {
                    isRevers = false;
                }
                angleNum = 180;
                isTurn = true;
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
